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
using FinalProjectCodeFirstApproch.Models.DTO.Weapon_Section;

namespace FinalProjectCodeFirstApproch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportAnalysisController : ControllerBase
    {
        private readonly PoliceStationManagementDbContext db;

        public ReportAnalysisController(PoliceStationManagementDbContext db)
        {
            this.db = db;
        }


        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<ReportAnalysis>>> GetReportAnalyses()
        //{
        //  if (db.ReportAnalyses == null)
        //  {
        //      return NotFound();
        //  }
        //    return await db.ReportAnalyses.ToListAsync();
        //}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReportAnalysis>>> GetReportAnalyses()
        {
            if (db.ReportAnalyses == null)
            {
                return NotFound();
            }
            var reportAnalyses = await db.ReportAnalyses.Include(x => x.PoliceUser)
                .Select(x => new GetReportAnalysisDTO
                {
                    ReportAnalysisId = x.ReportAnalysisId,
                    AnalysisResults = x.AnalysisResults,
                    ReportingDate = x.ReportingDate,
                    Conclusions = x.Conclusions,
                    CaseId = x.CaseId,
                    OfficerName = x.PoliceUser.FirstName
                }).ToListAsync();
            return Ok(reportAnalyses);
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult<ReportAnalysis>> GetReportAnalysis(int id)
        //{
        //    if (db.ReportAnalyses == null)
        //    {
        //        return NotFound();
        //    }
        //    var reportAnalysis = await db.ReportAnalyses.FindAsync(id);

        //    if (reportAnalysis == null)
        //    {
        //        return NotFound();
        //    }

        //    return reportAnalysis;
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<ReportAnalysis>> GetReportAnalysis(int id)
        {
            if (db.ReportAnalyses == null)
            {
                return NotFound();
            }
            var ra = await db.ReportAnalyses.Include(x=>x.PoliceUser).FirstAsync(x=>x.ReportAnalysisId==id);

            if (ra == null)
            {
                return NotFound();
            }
            var reportAnalysis = new GetReportAnalysisDTO()
            {
                ReportAnalysisId = ra.ReportAnalysisId,
                AnalysisResults = ra.AnalysisResults,
                ReportingDate = ra.ReportingDate,
                Conclusions = ra.Conclusions,
                CaseId = ra.CaseId,
                OfficerName = ra.PoliceUser.FirstName
            };
            return Ok(reportAnalysis);
        }

        [HttpPost]
        public async Task<ActionResult<ReportAnalysis>> PostReportAnalysis([FromForm] ReportAnalysisDTO model)
        {
            ReportAnalysis reportAnalysis = new ReportAnalysis()
            {
                AnalysisResults = model.AnalysisResults,
                ReportingDate = model.ReportingDate,
                Conclusions = model.Conclusions,
                CaseId = model.CaseId,
                OfficerId = model.OfficerId
            };
            db.ReportAnalyses.Add(reportAnalysis);
            await db.SaveChangesAsync();

            return Ok(reportAnalysis);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutReportAnalysis(int id, [FromForm] ReportAnalysisDTO model)
        {
            var reportAnalysis = await db.ReportAnalyses.FindAsync(id);
            if (reportAnalysis == null)
            {
                return NotFound();
            }
            reportAnalysis.AnalysisResults = model.AnalysisResults;
            reportAnalysis.ReportingDate = model.ReportingDate;
            reportAnalysis.Conclusions = model.Conclusions;
            reportAnalysis.CaseId = model.CaseId;
            reportAnalysis.OfficerId = model.OfficerId;
            db.Entry(reportAnalysis).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return Ok(reportAnalysis);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReportAnalysis(int id)
        {
            if (db.ReportAnalyses == null)
            {
                return NotFound();
            }
            var reportAnalysis = await db.ReportAnalyses.FindAsync(id);
            if (reportAnalysis == null)
            {
                return NotFound();
            }

            db.ReportAnalyses.Remove(reportAnalysis);
            await db.SaveChangesAsync();

            return Ok("Successfull Deleted");
        }

        private bool ReportAnalysisExists(int id)
        {
            return (db.ReportAnalyses?.Any(e => e.ReportAnalysisId == id)).GetValueOrDefault();
        }
    }
}
