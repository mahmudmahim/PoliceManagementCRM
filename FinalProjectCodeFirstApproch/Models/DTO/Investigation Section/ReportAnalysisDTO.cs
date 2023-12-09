using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinalProjectCodeFirstApproch.Models.DTO.Investigation_Section
{
    public class ReportAnalysisDTO
    {
        public string? AnalysisResults { get; set; }
        [Required, Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Reporting Date")]
        public DateTime? ReportingDate { get; set; }
        public string? Conclusions { get; set; }
        public int? CaseId { get; set; }
        public int? OfficerId { get; set; }
    }
}
