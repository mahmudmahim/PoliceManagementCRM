using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProjectCodeFirstApproch.Models.JunctionForAllClass;
using FinalProjectCodeFirstApproch.Models.Police_Management;
using FinalProjectCodeFirstApproch.Models.Police_Management.ViewModels;

namespace FinalProjectCodeFirstApproch.Controllers.PoliceManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseInfoesController : ControllerBase
    {
        private readonly PoliceStationManagementDbContext _context;

        public CaseInfoesController(PoliceStationManagementDbContext context)
        {
            _context = context;
        }

        // GET CaseInfoes
        [HttpGet]
        public async Task<IActionResult> GetCaseInfos()
        {
            try
            {
                var caseInfo = await _context.CaseInfos.ToListAsync();
                return Ok(caseInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // GET CaseInfoes by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<CaseInfo>> GetCaseInfo(int id)
        {
          if (_context.CaseInfos == null)
          {
              return NotFound();
          }
            var caseInfo = await _context.CaseInfos.FindAsync(id);

            if (caseInfo == null)
            {
                return NotFound();
            }

            return caseInfo;
        }

        // PUT CaseInfoes
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCaseInfo(int id, [FromForm] CaseInfo formData)
        {
            var caseInfo = await _context.CaseInfos.FindAsync(id);
            if (caseInfo == null)
            {
                return NotFound("Case Info not found");
            }
            caseInfo.Status = formData.Status;
            caseInfo.PoliceId = formData.PoliceId;
            caseInfo.SuspectId = formData.SuspectId;
            caseInfo.VictimId = formData.VictimId;
            caseInfo.WitnessId = formData.WitnessId;

            _context.Entry(caseInfo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok("Update Successfull....!!");

        }

        // POST CaseInfoes

        [HttpPost]
        public async Task<ActionResult<CaseInfo>> PostCaseInfo([FromForm] caseInfoVM formData)
        {

            var policeUser = _context.PoliceUsers.FirstOrDefault(x => x.PoliceUserId == formData.PoliceId);

            var suspectInfo = _context.SuspectInfos.FirstOrDefault(x => x.SuspectInfoId == formData.SuspectId);

            var victimInfo = _context.VictimsCaseApplies.FirstOrDefault(x => x.VictimCaseApplyId == formData.VictimId);

            var witnessInfo = _context.WitnessInfos.FirstOrDefault(x => x.WitnessInfoId == formData.WitnessId);

            try
            {
                var caseInfo = new CaseInfo
                {
                    Status = formData.Status,
                    PoliceId = policeUser.PoliceUserId,
                    SuspectId = suspectInfo.SuspectInfoId,
                    VictimId = victimInfo.VictimCaseApplyId,
                    WitnessId = witnessInfo.WitnessInfoId
                };

                _context.CaseInfos.Add(caseInfo);
                await _context.SaveChangesAsync();
                return Ok("Case Information Insert successfully...!!");
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE CaseInfoes

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCaseInfo(int id)
        {
            try
            {
                var caseInfoDelete = await _context.CaseInfos.FindAsync(id);
                if (caseInfoDelete == null)
                {
                    return NotFound("Station Not Found");
                }

                _context.CaseInfos.Remove(caseInfoDelete);
                await _context.SaveChangesAsync();
                return Ok("Station Deleted Successfully..!!");

            }
            catch(Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        private bool CaseInfoExists(int id)
        {
            return (_context.CaseInfos?.Any(e => e.CaseInfoId == id)).GetValueOrDefault();
        }
    }
}
