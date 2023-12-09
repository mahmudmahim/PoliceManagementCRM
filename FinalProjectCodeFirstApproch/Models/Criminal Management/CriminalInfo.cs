using FinalProjectCodeFirstApproch.Models.Police_Management;
using FinalProjectCodeFirstApproch.Models.Suspect_Management;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;

namespace FinalProjectCodeFirstApproch.Models.Criminal_Management
{
    public class CriminalInfo
    {
        public int CriminalInfoId { get; set; }
        [Required]
        public string? Name { get; set; }
        public int? Age { get; set; }
        [Required]
        public string? Gender { get; set; }
        public string? Picture { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? Status { get; set; }
        [ForeignKey("CaseInfo")]
        public int? CaseId { get; set; }
        [ForeignKey("SuspectInfo")]
        public int? SuspectId { get; set; }
        public virtual CaseInfo? CaseInfo { get; set; }
        public virtual SuspectInfo? SuspectInfo { get; set; }

        public virtual ICollection<CriminalActivity> CriminalActivities { get; set; } = new List<CriminalActivity>();

        public virtual ICollection<CriminalContact> CriminalContacts { get; set; } = new List<CriminalContact>();

        public virtual ICollection<PrisonRecords> PrisonRecords { get; set; } = new List<PrisonRecords>();
    }
}
