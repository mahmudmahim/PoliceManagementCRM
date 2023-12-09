using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using FinalProjectCodeFirstApproch.Models.Police_Management;
using FinalProjectCodeFirstApproch.Models.System_Administration;

namespace FinalProjectCodeFirstApproch.Models.Investigation_Management
{
    public class ReportAnalysis
    {
        public int ReportAnalysisId { get; set; }
        public string? AnalysisResults { get; set; }
        [Required, Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Reporting Date")]
        public DateTime? ReportingDate { get; set; }
        public string? Conclusions { get; set; }
        [ForeignKey("CaseInfo")]
        public int? CaseId { get; set; }
        [ForeignKey("PoliceUser")]
        public int? OfficerId { get; set; }
        public virtual CaseInfo? CaseInfo { get; set; }
        public virtual PoliceUser? PoliceUser { get; set; }
    }
}
