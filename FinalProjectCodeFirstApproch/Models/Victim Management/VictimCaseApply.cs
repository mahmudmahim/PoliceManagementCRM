using FinalProjectCodeFirstApproch.Models.Police_Management;
using FinalProjectCodeFirstApproch.Models.Suspect_Management;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectCodeFirstApproch.Models.Victim_Management
{
    public class VictimCaseApply
    {
        public int VictimCaseApplyId { get; set; }
        [Required,StringLength(50),Display(Name ="Name")]
        public string? Name { get; set; }

        public int? Age { get; set; }
        [Required]
        public string? Gender { get; set; }
        [Required]
        public string? Address { get; set; }
       
        public string? Profession { get; set; }
        [Required]
        public string? PhoneNo { get; set; }
        public string? Picture { get; set; } = default!;
        [Required]
        public string? Nationality { get; set; }

        public string? MaritalStatus { get; set; }

        public long? Nid { get; set; }
        [ForeignKey("CrimeType")]
        public int? CrimeTypeId { get; set; }
        [Required,StringLength(50),Display(Name ="Crime Spot")]
        public string? CrimeSpot { get; set; }
        [Required, StringLength(50), Display(Name = "Crime Description")]
        public string? CrimeDescription { get; set; }
        public virtual ICollection<SuspectInfo> SuspectInfos { get; set; } = new List<SuspectInfo>();
        public virtual ICollection<CaseInfo> CaseInfos { get; set; } = new List<CaseInfo>();

        public virtual CrimeType? CrimeType { get; set; }

        public virtual ICollection<WitnessInfo> WitnessInfos { get; set; } = new List<WitnessInfo>();
    }
}
