using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProjectCodeFirstApproch.Models.Investigation_Management;
using FinalProjectCodeFirstApproch.Models.JunctionForAllClass;
using FinalProjectCodeFirstApproch.Models.DTO.Investigation_Section;
using FinalProjectCodeFirstApproch.Models.Weapon_Management;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.CodeAnalysis;


namespace FinalProjectCodeFirstApproch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestigationsController : ControllerBase
    {
        private readonly PoliceStationManagementDbContext db;

        public InvestigationsController(PoliceStationManagementDbContext db)
        {
            this.db = db;
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<InvestigationInfo>>> GetInvestigationInfos()
        //{
        //    if (db.InvestigationInfos == null)
        //    {
        //        return NotFound();
        //    }
        //    return await db.InvestigationInfos.ToListAsync();
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvestigationInfo>>> GetInvestigationInfos()
        {
            if (db.InvestigationInfos == null)
            {
                return NotFound();
            }
            var investigation = await db.InvestigationInfos.Include(x => x.PoliceUser)
                .Select(x => new GetInvestigationDTO
                {
                    InvestigationInfoId=x.InvestigationInfoId,
                    StartDate=x.StartDate,
                    EndDate=x.EndDate,
                    Status=x.Status,
                    Location=x.Location,
                    Details=x.Details,
                    CaseId=x.CaseId,
                    OfficerName=x.PoliceUser.FirstName
                }).ToListAsync();
            return Ok(investigation);
        }


        //[HttpGet("{id}")]
        //public async Task<ActionResult<InvestigationInfo>> GetInvestigationInfo(int id)
        //{
        //    if (db.InvestigationInfos == null)
        //    {
        //        return NotFound();
        //    }
        //    var investigationInfo = await db.InvestigationInfos.FindAsync(id);

        //    if (investigationInfo == null)
        //    {
        //        return NotFound();
        //    }
        //    return investigationInfo;
        //}
        
        [HttpGet("{id}")]
        public async Task<ActionResult<InvestigationInfo>> GetInvestigationInfo(int id)
        {
            if (db.InvestigationInfos == null)
            {
                return NotFound();
            }
            var investigationInfo = await db.InvestigationInfos.Include(x=>x.PoliceUser).FirstAsync(x=>x.InvestigationInfoId==id);

            if (investigationInfo == null)
            {
                return NotFound();
            }
            var investigation = new GetInvestigationDTO()
            {
                InvestigationInfoId = investigationInfo.InvestigationInfoId,
                StartDate = investigationInfo.StartDate,
                EndDate = investigationInfo.EndDate,
                Status = investigationInfo.Status,
                Location = investigationInfo.Location,
                Details = investigationInfo.Details,
                CaseId = investigationInfo.CaseId,
                OfficerName = investigationInfo.PoliceUser.FirstName
            };
            return Ok(investigation);
        }

        [HttpPost]
        public async Task<ActionResult<InvestigationInfo>> PostInvestigationInfo([FromForm] InvestigationInfoDTO investigationDTO)
        {
            InvestigationInfo investigationInfo = new InvestigationInfo()
            {
                StartDate = investigationDTO.StartDate,
                EndDate = investigationDTO.EndDate,
                Status = investigationDTO.Status,
                Location = investigationDTO.Location,
                Details = investigationDTO.Details,
                CaseId = investigationDTO.CaseId,
                OfficerId = investigationDTO.OfficerId
            };
            db.InvestigationInfos.Add(investigationInfo);
            await db.SaveChangesAsync();

            return Ok(investigationInfo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvestigationInfo(int id, [FromForm]InvestigationInfoDTO model)
        {
            var investigationInfo = await db.InvestigationInfos.FindAsync(id);
            if (investigationInfo == null)
            {
                return NotFound();
            }
            investigationInfo.StartDate = model.StartDate;
            investigationInfo.EndDate = model.EndDate;
            investigationInfo.Status = model.Status;
            investigationInfo.Location = model.Location;
            investigationInfo.Details = model.Details;
            investigationInfo.CaseId = model.CaseId;
            investigationInfo.OfficerId = model.OfficerId;

            db.Entry(investigationInfo).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return Ok(investigationInfo);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvestigationInfo(int id)
        {
            if (db.InvestigationInfos == null)
            {
                return NotFound();
            }
            var investigationInfo = await db.InvestigationInfos.FindAsync(id);
            if (investigationInfo == null)
            {
                return NotFound();
            }

            db.InvestigationInfos.Remove(investigationInfo);
            await db.SaveChangesAsync();

            return Ok("Succesfull Removed InvestigationInfo With Id : " + investigationInfo.InvestigationInfoId);
        }

        private bool InvestigationInfoExists(int id)
        {
            return (db.InvestigationInfos?.Any(e => e.InvestigationInfoId == id)).GetValueOrDefault();
        }
    }
}
