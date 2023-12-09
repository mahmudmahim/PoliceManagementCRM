using System.ComponentModel.DataAnnotations;

namespace FinalProjectCodeFirstApproch.Models.System_Administration
{
    public class Roles
    {
        public int RolesId { get; set; }
        [Required, StringLength(50), Display(Name = "Role Name")]
        public string? RoleName { get; set; }
    }
}

