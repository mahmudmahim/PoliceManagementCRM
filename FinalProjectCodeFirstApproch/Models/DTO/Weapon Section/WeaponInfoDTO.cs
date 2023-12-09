using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinalProjectCodeFirstApproch.Models.DTO.Weapon_Section
{
    public class WeaponInfoDTO
    {
        [Required]
        public string? Description { get; set; }

        [Required, Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Acquisition Date")]
        public DateTime? AcquisitionDate { get; set; }
        [Required]
        public string? Status { get; set; }
        public int? CategoryId { get; set; }
        public int? OwnerId { get; set; }
    }
}
