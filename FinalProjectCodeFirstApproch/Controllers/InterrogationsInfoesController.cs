using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProjectCodeFirstApproch.Models.JunctionForAllClass;
using FinalProjectCodeFirstApproch.Models.Suspect_Management;
using FinalProjectCodeFirstApproch.Models.Suspect_Management.ViewModels;

namespace FinalProjectCodeFirstApproch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterrogationsInfoesController : ControllerBase
    {
        private readonly PoliceStationManagementDbContext _context;

        public InterrogationsInfoesController(PoliceStationManagementDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InterrogationsInfo>>> GetInterrogationsInfos()
        {
            try
            {
                var interrogation = await _context.InterrogationsInfos.ToListAsync();
                return Ok(interrogation);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InterrogationsInfo>> GetInterrogationsInfoById(int id)
        {
          if (_context.InterrogationsInfos == null)
          {
              return NotFound();
          }
            var interrogationsInfo = await _context.InterrogationsInfos.FindAsync(id);

            if (interrogationsInfo == null)
            {
                return NotFound();
            }

            return interrogationsInfo;
        }

        [HttpPost]
        public async Task<ActionResult<InterrogationsInfo>> CreateInterrogationsInfo([FromForm] InterrogationVM formData)
        {
            var caseInfo = _context.CaseInfos.FirstOrDefault(x => x.CaseInfoId == formData.CaseId);
            if (caseInfo == null)
            {
                return NotFound();
            }

            var police = _context.PoliceUsers.FirstOrDefault(x => x.PoliceUserId == formData.OfficerId);
            if(police == null)
            {
                return NotFound();
            }

            var suspect = _context.SuspectInfos.FirstOrDefault(x => x.SuspectInfoId == formData.SuspectId);
            if (suspect == null)
            {
                return NotFound();
            }

            try
            {
                var interrogationInfo = new InterrogationsInfo
                {
                    Date = formData.Date,
                    Details = formData.Details,
                    CaseId = caseInfo.CaseInfoId,
                    OfficerId = police.PoliceUserId,
                    SuspectId = suspect.SuspectInfoId
                };
                _context.InterrogationsInfos.Add(interrogationInfo);
                await _context.SaveChangesAsync();
                return Ok("Interrogation information created successfully!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInterrogationsInfo(int id, [FromForm] InterrogationVM formData)
        {
            var interrogationInfo = await _context.InterrogationsInfos.FindAsync(id);
            if(interrogationInfo == null)
            {
                return NotFound();
            }

            interrogationInfo.Date = formData.Date;
            interrogationInfo.Details = formData.Details;
            interrogationInfo.CaseId = formData.CaseId;
            interrogationInfo.OfficerId = formData.OfficerId;
            interrogationInfo.SuspectId = formData.SuspectId;

            _context.Entry(interrogationInfo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok("Interrogation information updated successfully!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInterrogationsInfo(int id)
        {
            try
            {
                var interrogationDelete = await _context.InterrogationsInfos.FindAsync(id);
                if(interrogationDelete == null)
                {
                    return NotFound("Interrogation not fount!");
                }
                _context.InterrogationsInfos.Remove(interrogationDelete);
                await _context.SaveChangesAsync();
                return Ok("Interrogation information deleted successfully!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        private bool InterrogationsInfoExists(int id)
        {
            return (_context.InterrogationsInfos?.Any(e => e.InterrogationsInfoId == id)).GetValueOrDefault();
        }
    }
}
