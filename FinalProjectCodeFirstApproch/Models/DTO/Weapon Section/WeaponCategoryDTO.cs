using System.ComponentModel.DataAnnotations;

namespace FinalProjectCodeFirstApproch.Models.DTO.Weapon_Section
{
    public class WeaponCategoryDTO
    {
        [Required, StringLength(50), Display(Name = "Category Name")]
        public string? CategoryName { get; set; }
        [Required, StringLength(50)]
        public string? Description { get; set; }
    }
}
