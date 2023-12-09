using FinalProjectCodeFirstApproch.Models.Criminal_Management;
using FinalProjectCodeFirstApproch.Models.Police_Management;
using FinalProjectCodeFirstApproch.Models.Suspect_Management;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectCodeFirstApproch.Models.DTO.Criminal_Section
{
    public class GetCriminalDTO
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
        public int? CaseId { get; set; }
        [DisplayName("Suspect Name")]
        public string? SuspectName { get; set; }


    }
}
