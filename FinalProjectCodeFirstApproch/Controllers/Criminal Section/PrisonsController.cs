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
    public class PrisonsController : ControllerBase
    {
        private readonly PoliceStationManagementDbContext db;

        public PrisonsController(PoliceStationManagementDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prison>>> GetPrisons()
        {
            if (db.Prisons == null)
            {
                return NotFound();
            }
            return await db.Prisons.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Prison>> GetPrison(int id)
        {
            if (db.Prisons == null)
            {
                return NotFound();
            }
            var prison = await db.Prisons.FindAsync(id);

            if (prison == null)
            {
                return NotFound();
            }

            return prison;
        }

        [HttpPost]
        public async Task<ActionResult<Prison>> PostPrison([FromForm] PrisonDTO model)
        {
            Prison prison = new Prison()
            {
                PrisonName=model.PrisonName,
                Location=model.Location,
                Capacity=model.Capacity,
                ContactInfo=model.ContactInfo
            };
            db.Prisons.Add(prison);
            await db.SaveChangesAsync();
            return Ok(prison);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrison(int id,[FromForm] PrisonDTO model)
        {
            var prison = await db.Prisons.FindAsync(id);
            if (prison == null)
            {
                return BadRequest();
            }
            prison.PrisonName= model.PrisonName;
            prison.Location=model.Location;
            prison.Capacity=model.Capacity;
            prison.ContactInfo = model.ContactInfo;
            db.Entry(prison).State = EntityState.Modified;
                await db.SaveChangesAsync();        
            return Ok(prison);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrison(int id)
        {
            var prison = await db.Prisons.FindAsync(id);
            if (prison == null)
            {
                return NotFound();
            }

            db.Prisons.Remove(prison);
            await db.SaveChangesAsync();

            return Ok("Succesfully Deleted");
        }

    }
}
