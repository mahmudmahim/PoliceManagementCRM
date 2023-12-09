using FinalProjectCodeFirstApproch.Models.Criminal_Management;
using FinalProjectCodeFirstApproch.Models.Police_Management;
using FinalProjectCodeFirstApproch.Models.Victim_Management;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;

namespace FinalProjectCodeFirstApproch.Models.Suspect_Management
{
    public class SuspectInfo
    {
        public int SuspectInfoId { get; set; }
        [Required]
        public string? Name { get; set; }

        public int? Age { get; set; }
        [Required]
        public string? Gender { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? PhoneNo { get; set; }
        public string? Picture { get; set; }
        public string? Description { get; set; }
        [ForeignKey("VictimCaseApply")]
        public int VictimCaseApplyId { get; set; }

        public virtual VictimCaseApply? VictimCaseApply { get; set; }
        public virtual ICollection<CaseInfo> CaseInfos { get; set; } = new List<CaseInfo>();

        public virtual ICollection<CriminalInfo> Criminals { get; set; } = new List<CriminalInfo>();

        public virtual ICollection<InterrogationsInfo> InterrogationsInfos { get; set; } = new List<InterrogationsInfo>();

        public virtual ICollection<SuspectContact> SuspectContacts { get; set; } = new List<SuspectContact>();
    }
}
