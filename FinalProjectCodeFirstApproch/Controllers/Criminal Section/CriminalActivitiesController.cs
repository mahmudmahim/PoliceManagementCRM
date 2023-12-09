using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProjectCodeFirstApproch.Models.Criminal_Management;
using FinalProjectCodeFirstApproch.Models.JunctionForAllClass;
using FinalProjectCodeFirstApproch.Models.DTO.Criminal_Section;

namespace FinalProjectCodeFirstApproch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CriminalActivitiesController : ControllerBase
    {
        private readonly PoliceStationManagementDbContext db;

        public CriminalActivitiesController(PoliceStationManagementDbContext db)
        {
            this.db = db;
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<CriminalActivity>>> GetCriminalActivities()
        //{
        //  if (db.CriminalActivities == null)
        //  {
        //      return NotFound();
        //  }
        //    return await db.CriminalActivities.ToListAsync();
        //}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CriminalActivity>>> GetCriminalActivities()
        {
            if (db.CriminalActivities == null)
            {
                return NotFound();
            }
            var criminalActivities = await db.CriminalActivities.Include(x => x.CriminalInfo)
                .Select(x => new GetCriminalActivityDTO
                {
                    CriminalActivityId=x.CriminalActivityId,
                    Type=x.Type,
                    Description=x.Description,
                    CriminalName=x.CriminalInfo.Name
                }).ToListAsync();
            return Ok(criminalActivities);
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult<CriminalActivity>> GetCriminalActivity(int id)
        //{
        //  if (db.CriminalActivities == null)
        //  {
        //      return NotFound();
        //  }
        //    var criminalActivity = await db.CriminalActivities.FindAsync(id);

        //    if (criminalActivity == null)
        //    {
        //        return NotFound();
        //    }

        //    return criminalActivity;
        //}



        [HttpGet("{id}")]
        public async Task<ActionResult<CriminalActivity>> GetCriminalActivity(int id)
        {
            if (db.CriminalActivities == null)
            {
                return NotFound();
            }
            var ca = await db.CriminalActivities.Include(x=>x.CriminalInfo).FirstAsync(x=>x.CriminalActivityId==id);

            if (ca == null)
            {
                return NotFound();
            }

            var criminalActivity = new GetCriminalActivityDTO()
            {
                CriminalActivityId=ca.CriminalActivityId,
                Type=ca.Type,
                Description=ca.Description,
                CriminalName=ca.CriminalInfo.Name
            };
            return Ok(criminalActivity);
        }

        [HttpPost]
        public async Task<ActionResult<CriminalActivity>> PostCriminalActivity([FromForm]CriminalActivityDTO model)
        {
            CriminalActivity criminalActivity = new CriminalActivity()
            {
                Type= model.Type,
                Description= model.Description,
                CriminalId= model.CriminalId
            };
            db.CriminalActivities.Add(criminalActivity);
            await db.SaveChangesAsync();

            return Ok(criminalActivity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCriminalActivity(int id, [FromForm]CriminalActivityDTO model)
        {
            var criminalActivity = await db.CriminalActivities.FindAsync(id);
            if (criminalActivity==null)
            {
                return BadRequest();
            }
            criminalActivity.Type = model.Type;
            criminalActivity.Description = model.Description;
            criminalActivity.CriminalId = model.CriminalId;
            db.Entry(criminalActivity).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return Ok(criminalActivity);
        }

      

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCriminalActivity(int id)
        {
            if (db.CriminalActivities == null)
            {
                return NotFound();
            }
            var criminalActivity = await db.CriminalActivities.FindAsync(id);
            if (criminalActivity == null)
            {
                return NotFound();
            }

            db.CriminalActivities.Remove(criminalActivity);
            await db.SaveChangesAsync();

            return NoContent();
        }
    }
}
