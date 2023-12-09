using FinalProjectCodeFirstApproch.Models.JunctionForAllClass;
using FinalProjectCodeFirstApproch.Models.Police_Management;
using FinalProjectCodeFirstApproch.Models.Suspect_Management;
using FinalProjectCodeFirstApproch.Models.Suspect_Management.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectCodeFirstApproch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvidenceInfoController : ControllerBase
    {
        private readonly PoliceStationManagementDbContext _context;

        public EvidenceInfoController(PoliceStationManagementDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetEvidenceInfos()
        {
            try
            {
                var evidence = await _context.EvidenceInfos.ToListAsync();
                return Ok(evidence);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EvidenceInfo>> GetEvidenceInfoById(int id)
        {
            if (_context.EvidenceInfos == null)
            {
                return NotFound();
            }
            var evidenceInfo = await _context.EvidenceInfos.FindAsync(id);

            if (evidenceInfo == null)
            {
                return NotFound();
            }

            return evidenceInfo;
        }

        [HttpPost]
        public async Task<ActionResult<EvidenceInfo>> CreateEvidenceInfo([FromForm] EvidenceVM formData)
        {
            var caseInfo = _context.CaseInfos.FirstOrDefault(x => x.CaseInfoId == formData.CaseId);
            if (caseInfo == null)
            {
                return NotFound();
            }

            try
            {
                var evidenceInfo = new EvidenceInfo
                {
                    Description = formData.Description,
                    Type = formData.Type,
                    CollectionDate = formData.CollectionDate,
                    CaseId = caseInfo.CaseInfoId
                };
                _context.EvidenceInfos.Add(evidenceInfo);
                await _context.SaveChangesAsync();
                return Ok("Evidence created successfully!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvidenceInfo(int id, [FromForm] EvidenceVM formData)
        {
            var evidenceInfo = await _context.EvidenceInfos.FindAsync(id);
            if(evidenceInfo == null)
            {
                return NotFound();
            }
            evidenceInfo.Description = formData.Description;
            evidenceInfo.Type = formData.Type;
            evidenceInfo.CollectionDate = formData.CollectionDate;
            evidenceInfo.CaseId = formData.CaseId;

            _context.Entry(evidenceInfo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok("Evidence updated successfully!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvidenceInfo(int id)
        {
            try
            {
                var evidenceDelete = await _context.EvidenceInfos.FindAsync(id);
                if (evidenceDelete == null)
                {
                    return NotFound("Evidence Not Found");
                }
                _context.EvidenceInfos.Remove(evidenceDelete);
                await _context.SaveChangesAsync();
                return Ok("Evidence Deleted Successfully..!!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        private bool EvidenceInfoExists(int id)
        {
            return (_context.EvidenceInfos?.Any(e => e.EvidenceInfoId == id)).GetValueOrDefault();
        }
    }
}
