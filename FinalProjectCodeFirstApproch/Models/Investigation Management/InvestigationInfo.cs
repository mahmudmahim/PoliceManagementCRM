using FinalProjectCodeFirstApproch.Models.Police_Management;
using FinalProjectCodeFirstApproch.Models.System_Administration;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;

namespace FinalProjectCodeFirstApproch.Models.Investigation_Management
{
    public class InvestigationInfo
    {
        public int InvestigationInfoId { get; set; }
        [Required, Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }
        [Required, Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }
        [Required]
        public string? Status { get; set; }
        public string? Location { get; set; } 
        public string? Details { get; set; } 
        [ForeignKey("CaseInfo")]
        public int? CaseId { get; set; }
        [ForeignKey("PoliceUser")]
        public int? OfficerId { get; set; }
        public virtual CaseInfo? CaseInfo { get; set; }
        public virtual PoliceUser? PoliceUser { get; set; }
    }
}
