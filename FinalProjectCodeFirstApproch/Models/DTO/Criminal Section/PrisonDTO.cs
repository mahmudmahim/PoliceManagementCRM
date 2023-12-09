using FinalProjectCodeFirstApproch.Models.Criminal_Management;
using System.ComponentModel.DataAnnotations;

namespace FinalProjectCodeFirstApproch.Models.DTO.Criminal_Section
{
    public class PrisonDTO
    {
        [Required]
        public string? PrisonName { get; set; }
        [Required]
        public string? Location { get; set; }
        public int? Capacity { get; set; }
        [Required]
        public string? ContactInfo { get; set; }
    }
}
