using FinalProjectCodeFirstApproch.Models.Police_Management;
using FinalProjectCodeFirstApproch.Models.System_Administration;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FinalProjectCodeFirstApproch.Models.DTO.Investigation_Section
{
    public class GetReportAnalysisDTO
    {
        public int ReportAnalysisId { get; set; }
        public string? AnalysisResults { get; set; }
        [Required, Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Reporting Date")]
        public DateTime? ReportingDate { get; set; }
        public string? Conclusions { get; set; }
        [ForeignKey("CaseInfo")]
        public int? CaseId { get; set; }
        [DisplayName("Officer Name")]
        public string? OfficerName { get; set; }
    }
}
