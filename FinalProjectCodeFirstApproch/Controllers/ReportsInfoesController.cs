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
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Authorization;

namespace FinalProjectCodeFirstApproch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsInfoesController : ControllerBase
    {
        private readonly PoliceStationManagementDbContext _context;

        public ReportsInfoesController(PoliceStationManagementDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetReportsInfos()
        {
            try
            {
                var report = await _context.ReportsInfos.ToListAsync();
                return Ok(report);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ReportsInfo>> GetReportsInfo(int id)
        {
            if (_context.ReportsInfos == null)
            {
                return NotFound();
            }
            var reportsInfo = await _context.ReportsInfos.FindAsync(id);

            if (reportsInfo == null)
            {
                return NotFound();
            }

            return reportsInfo;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutReportsInfo(int id, [FromForm] ReportsInfo formData)
        {
            var report = await _context.ReportsInfos.FindAsync(id);

            if (report == null)
            {
                return NotFound("Report Not Found");
            }
            report.Description = formData.Description;
            report.OfficerId = formData.OfficerId;
            report.CaseId = formData.CaseId;

            _context.Entry(report).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok("Update Successfull....!!");

        }

        [HttpPost]
        public async Task<ActionResult<ReportsInfo>> PostReportsInfo([FromForm] reportVM formData)
        {
            var caseInfo = _context.CaseInfos.FirstOrDefault(x => x.CaseInfoId == formData.CaseId);

            var policeUser = _context.PoliceUsers.FirstOrDefault(x => x.PoliceUserId == formData.OfficerId);

            try
            {
                var reportInfo = new ReportsInfo
                {
                    Description = formData.Description,
                    OfficerId = policeUser.PoliceUserId,
                    CaseId = caseInfo.CaseInfoId
                };

                _context.ReportsInfos.Add(reportInfo);
                await _context.SaveChangesAsync();
                return Ok("Report Create successfully...!!");

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReportsInfo(int id)
        {
            try
            {
                var reportDelete = await _context.ReportsInfos.FindAsync(id);
                if (reportDelete == null)
                {
                    return NotFound("Report Not Found");
                }
                _context.ReportsInfos.Remove(reportDelete);
                await _context.SaveChangesAsync();
                return Ok("Report Deleted Successfully..!!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
            
        }

        private bool ReportsInfoExists(int id)
        {
            return (_context.ReportsInfos?.Any(e => e.ReportsInfoId == id)).GetValueOrDefault();
        }
    }
}
