using System.ComponentModel.DataAnnotations;

namespace FinalProjectCodeFirstApproch.Models.Victim_Management
{
    public class CrimeType
    {
        public int CrimeTypeId { get; set; }
        [Required]
        public string? CrimeName { get; set; }

        public virtual ICollection<VictimCaseApply> VictimsCaseApplies { get; set; } = new List<VictimCaseApply>();
    }
}
