using FinalProjectCodeFirstApproch.Models.Criminal_Management;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectCodeFirstApproch.Models.DTO.Criminal_Section
{
    public class GetCriminalActivityDTO
    {
        public int CriminalActivityId { get; set; }
        [Required]
        public string? Type { get; set; }
        [Required]
        public string? Description { get; set; }
        [DisplayName("Criminal Name")]
        public string? CriminalName { get; set; }
    }
}
