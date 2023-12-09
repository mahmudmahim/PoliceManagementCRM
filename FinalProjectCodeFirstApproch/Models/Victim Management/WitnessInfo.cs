using FinalProjectCodeFirstApproch.Models.Police_Management;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;

namespace FinalProjectCodeFirstApproch.Models.Victim_Management
{
    public class WitnessInfo
    {
        public int WitnessInfoId { get; set; }
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
        public string? Profession { get; set; }
        [Required]
        public string? Nationality { get; set; }
        [ForeignKey("VictimCaseApply")]
        public int VictimCaseApplyId { get; set; }
        public virtual ICollection<CaseInfo> CaseInfos { get; set; } = new List<CaseInfo>();

        public virtual VictimCaseApply? VictimCaseApply { get; set; }
    }
}
