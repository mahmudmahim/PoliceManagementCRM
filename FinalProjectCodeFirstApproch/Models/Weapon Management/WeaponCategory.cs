using System.ComponentModel.DataAnnotations;

namespace FinalProjectCodeFirstApproch.Models.Weapon_Management
{
    public class WeaponCategory
    {
        public int WeaponCategoryId { get; set; }
        [Required, StringLength(50), Display(Name = "Category Name")]
        public string? CategoryName { get; set; }
        [Required,StringLength(50)]
        public string? Description { get; set; }

        public virtual ICollection<WeaponInfo> Weapons { get; set; } = new List<WeaponInfo>();
    }
}
