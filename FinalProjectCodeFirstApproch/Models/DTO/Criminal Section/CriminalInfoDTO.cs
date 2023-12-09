using FinalProjectCodeFirstApproch.Models.Criminal_Management;
using FinalProjectCodeFirstApproch.Models.Police_Management;
using FinalProjectCodeFirstApproch.Models.Suspect_Management;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectCodeFirstApproch.Models.DTO.Criminal_Section
{
    public class CriminalInfoDTO
    {
        [Required]
        public string? Name { get; set; }
        public int? Age { get; set; }
        [Required]
        public string? Gender { get; set; }
        public IFormFile? PicturePath { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? Status { get; set; }
        public int? CaseId { get; set; }
        public int? SuspectId { get; set; }
    }
}
