using FinalProjectCodeFirstApproch.Models.Criminal_Management;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectCodeFirstApproch.Models.DTO.Criminal_Section
{
    public class CriminalContactDTO
    {
        [Required]
        public string? ContactType { get; set; }
        [Required]
        public string? ContactInfo { get; set; }
        [Required]
        public string? Description { get; set; }
        public int? CriminalId { get; set; }
    }
}
