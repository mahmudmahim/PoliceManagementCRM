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
using FinalProjectCodeFirstApproch.Models.Criminal_Management;

namespace FinalProjectCodeFirstApproch.Controllers.PoliceManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationInfoesController : ControllerBase
    {
        private readonly PoliceStationManagementDbContext _context;

        public StationInfoesController(PoliceStationManagementDbContext context)
        {
            _context = context;
        }

       
        [HttpGet]
        public async Task<IActionResult> GetStationInfos()
        {
            try
            {
                var station = await _context.StationInfos.ToListAsync();
                return Ok(station);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
            
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<StationInfo>> GetStationInfo(int id)
        {
          if (_context.StationInfos == null)
          {
              return NotFound();
          }
            var stationInfo = await _context.StationInfos.FindAsync(id);

            if (stationInfo == null)
            {
                return NotFound();
            }

            return stationInfo;
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStationInfo(int id, [FromForm] stationVM formData)
        {
            var station = await _context.StationInfos.FindAsync(id);
            if (station == null)
            {
                return NotFound("Station Not Found");
            }
            station.StationName = formData.StationName;
            station.Address = formData.Address;
            station.ContactInfo = formData.ContactInfo;
            station.PoliceId = formData.PoliceId;

            _context.Entry(station).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok("Update Successfull....!!");
        }

       
        [HttpPost]
        public async Task<ActionResult<StationInfo>> PostStationInfo([FromForm] stationVM formData)
        {
     

            var policeUser = _context.PoliceUsers.FirstOrDefault(x => x.PoliceUserId == formData.PoliceId);

            try
            {
                var stationInfo = new StationInfo
                {
                    StationName = formData.StationName,
                    Address = formData.Address,
                    ContactInfo = formData.ContactInfo,
                    PoliceId = policeUser.PoliceUserId
                };
                _context.StationInfos.Add(stationInfo);
                await _context.SaveChangesAsync();
                return Ok("Station created successfully");

            }
            catch (Exception ex) 
            {
                return StatusCode(500, "Internal server error");
            }
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStationInfo(int id)
        {
            try
            {
                var stationDelete = await _context.StationInfos.FindAsync(id);
                if (stationDelete == null)
                {
                    return NotFound("Station Not Found");
                }
                _context.StationInfos.Remove(stationDelete);
                await _context.SaveChangesAsync();
                return Ok("Station Deleted Successfully..!!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        private bool StationInfoExists(int id)
        {
            return (_context.StationInfos?.Any(e => e.StationInfoId == id)).GetValueOrDefault();
        }
    }
}
