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
    public class PrisonRecordsController : ControllerBase
    {
        private readonly PoliceStationManagementDbContext db;

        public PrisonRecordsController(PoliceStationManagementDbContext db)
        {
            this.db = db;
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<PrisonRecords>>> GetPrisonRecords()
        //{
        //    if (db.PrisonRecords == null)
        //    {
        //        return NotFound();
        //    }
        //    return await db.PrisonRecords.ToListAsync();
        //}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrisonRecords>>> GetPrisonRecords()
        {
            if (db.PrisonRecords == null)
            {
                return NotFound();
            }
            var prisonRecord = await db.PrisonRecords.Include(x => x.Prison).Include(x => x.CriminalInfo)
                .Select(x => new GetPrisonRecordsDTO
                {
                    PrisonRecordsId = x.PrisonRecordsId,
                    EntryDate = x.EntryDate,
                    ReleaseDate = x.ReleaseDate,
                    Status = x.Status,
                    ReasonForImprisonment = x.ReasonForImprisonment,
                    CriminalName = x.CriminalInfo.Name,
                    PrisonName = x.Prison.PrisonName
                }).ToListAsync();
            return Ok(prisonRecord);
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult<PrisonRecords>> GetPrisonRecords(int id)
        //{
        //    if (db.PrisonRecords == null)
        //    {
        //        return NotFound();
        //    }
        //    var prisonRecords = await db.PrisonRecords.FindAsync(id);

        //    if (prisonRecords == null)
        //    {
        //        return NotFound();
        //    }

        //    return prisonRecords;
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<PrisonRecords>> GetPrisonRecords(int id)
        {
            if (db.PrisonRecords == null)
            {
                return NotFound();
            }
            var pr = await db.PrisonRecords.Include(x => x.CriminalInfo).Include(x => x.Prison).FirstAsync(x => x.PrisonRecordsId == id);

            if (pr == null)
            {
                return NotFound();
            }
            var prisonRecord = new GetPrisonRecordsDTO()
            {
                PrisonRecordsId = pr.PrisonRecordsId,
                EntryDate = pr.EntryDate,
                ReleaseDate = pr.ReleaseDate,
                Status = pr.Status,
                ReasonForImprisonment = pr.ReasonForImprisonment,
                CriminalName = pr.CriminalInfo.Name,
                PrisonName = pr.Prison.PrisonName
            };
            return Ok(prisonRecord);
        }


        [HttpPost]
        public async Task<ActionResult<PrisonRecords>> PostPrisonRecords([FromForm] PrisonRecordsDTO model)
        {
            PrisonRecords prisonRecords = new PrisonRecords()
            {
                EntryDate = model.EntryDate,
                ReleaseDate = model.ReleaseDate,
                Status = model.Status,
                ReasonForImprisonment = model.ReasonForImprisonment,
                PrisonId = model.PrisonId,
                CriminalId = model.CriminalId
            };
            db.PrisonRecords.Add(prisonRecords);
            await db.SaveChangesAsync();
            return Ok(prisonRecords);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrisonRecords(int id, [FromForm] PrisonRecordsDTO model)
        {
            var prisonRecords = await db.PrisonRecords.FindAsync(id);
            if (prisonRecords == null)
            {
                return BadRequest();
            }
            prisonRecords.EntryDate = model.EntryDate;
            prisonRecords.ReleaseDate = model.ReleaseDate;
            prisonRecords.Status = model.Status;
            prisonRecords.ReasonForImprisonment = model.ReasonForImprisonment;
            prisonRecords.PrisonId = model.PrisonId;
            prisonRecords.CriminalId = model.CriminalId;

            db.Entry(prisonRecords).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return Ok(prisonRecords);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrisonRecords(int id)
        {

            var prisonRecords = await db.PrisonRecords.FindAsync(id);
            if (prisonRecords == null)
            {
                return NotFound();
            }
            db.PrisonRecords.Remove(prisonRecords);
            await db.SaveChangesAsync();
            return Ok("Succesfully Deleted");
        }

    }
}