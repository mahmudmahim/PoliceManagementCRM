using FinalProjectCodeFirstApproch.Models.System_Administration;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;

namespace FinalProjectCodeFirstApproch.Models.Police_Management
{
    public class ReportsInfo
    {
        public int ReportsInfoId { get; set; }
        [Required]
        public string? Description { get; set; }
        [ForeignKey("PoliceUser")]
        public int? OfficerId { get; set; }
        [ForeignKey("CaseInfo")]
        public int? CaseId { get; set; }
        public virtual CaseInfo? CaseInfo { get; set; }
        public virtual PoliceUser? PoliceUser { get; set; }
    }
}
