using FinalProjectCodeFirstApproch.Models.System_Administration;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectCodeFirstApproch.Models.Weapon_Management
{
    public class WeaponInfo
    {
        public int WeaponInfoId { get; set; }
        [Required]
        public string? Description { get; set; }
  
        [Required, Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Acquisition Date")]
        public DateTime? AcquisitionDate { get; set; }
        [Required]
        public string? Status { get; set; }
        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        [ForeignKey("Owner")]
        public int? OwnerId { get; set; }
        public virtual WeaponCategory? Category { get; set; }

        public virtual PoliceUser? Owner { get; set; }
    }
}
