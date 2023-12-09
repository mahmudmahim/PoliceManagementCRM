using System.ComponentModel.DataAnnotations;

namespace FinalProjectCodeFirstApproch.Models.Police_Management.ViewModels
{
    public class caseInfoVM
    {
        [Required, Display(Name ="Case Status")]
        public string? Status { get; set; }
        public int? PoliceId { get; set; }
        public int? SuspectId { get; set; }
        public int? VictimId { get; set; }
        public int? WitnessId { get; set; }
    }
}
