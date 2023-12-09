using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProjectCodeFirstApproch.Models.JunctionForAllClass;
using FinalProjectCodeFirstApproch.Models.Police_Management;

namespace FinalProjectCodeFirstApproch.Controllers.PoliceManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftInfoesController : ControllerBase
    {
        private readonly PoliceStationManagementDbContext _context;

        public ShiftInfoesController(PoliceStationManagementDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShiftInfo>>> GetShiftInfos()
        {
          if (_context.ShiftInfos == null)
          {
              return NotFound();
          }
            return await _context.ShiftInfos.ToListAsync();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<ShiftInfo>> GetShiftInfo(int id)
        {
          if (_context.ShiftInfos == null)
          {
              return NotFound();
          }
            var shiftInfo = await _context.ShiftInfos.FindAsync(id);

            if (shiftInfo == null)
            {
                return NotFound();
            }

            return shiftInfo;
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShiftInfo(int id, ShiftInfo shiftInfo)
        {
            if (id != shiftInfo.ShiftInfoId)
            {
                return BadRequest();
            }

            _context.Entry(shiftInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShiftInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult<ShiftInfo>> PostShiftInfo(ShiftInfo shiftInfo)
        {

            try
            {
                var shift = new ShiftInfo
                {
                    ShiftName = shiftInfo.ShiftName,
                    StartTime = shiftInfo.StartTime,
                    EndTime = shiftInfo.EndTime
                };

                _context.ShiftInfos.Add(shift);
                await _context.SaveChangesAsync();
                return Ok("Shift Insert successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }

          //if (_context.ShiftInfos == null)
          //{
          //    return Problem("Entity set 'PoliceStationManagementDbContext.ShiftInfos'  is null.");
          //}
          //  _context.ShiftInfos.Add(shiftInfo);
          //  await _context.SaveChangesAsync();

          //  return CreatedAtAction("GetShiftInfo", new { id = shiftInfo.ShiftInfoId }, shiftInfo);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShiftInfo(int id)
        {
            if (_context.ShiftInfos == null)
            {
                return NotFound();
            }
            var shiftInfo = await _context.ShiftInfos.FindAsync(id);
            if (shiftInfo == null)
            {
                return NotFound();
            }

            _context.ShiftInfos.Remove(shiftInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShiftInfoExists(int id)
        {
            return (_context.ShiftInfos?.Any(e => e.ShiftInfoId == id)).GetValueOrDefault();
        }
    }
}
