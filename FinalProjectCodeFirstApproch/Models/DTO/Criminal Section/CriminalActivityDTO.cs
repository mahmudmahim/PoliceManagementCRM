using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectCodeFirstApproch.Models.DTO.Criminal_Section
{
    public class CriminalActivityDTO
    {
        [Required]
        public string? Type { get; set; }
        [Required]
        public string? Description { get; set; }
        public int? CriminalId { get; set; }
    }
}
