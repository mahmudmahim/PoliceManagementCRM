using FinalProjectCodeFirstApproch.Models.Police_Management;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace FinalProjectCodeFirstApproch.Models.System_Administration
{
    public class PoliceRegistration
    {
        public int PoliceRegistrationId { get; set; }
        public int PoliceId { get; set; }
        [Required, StringLength(50), Display(Name = "First Name")]
        public string? FirstName { get; set; }
        [Required, StringLength(50), Display(Name = "Last Name")]
        public string? LastName { get; set; }
        [Required]
        public string? Gender { get; set; }
        [Required,Column(TypeName ="date"),DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
            [Display(Name ="Date Of Birth")]
        public DateTime? DateOfBirth { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? PhoneNo { get; set; }
        [ForeignKey("Station")]
        public int? StationId { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Password must be between 8 and 15 characters and contain at least one lowercase letter, one uppercase letter, one digit, and one special character.")]
        public string? Password { get; set; }
        [ForeignKey("Role")]
        public int? RoleId { get; set; }

        public virtual Roles? Role { get; set; }

        public virtual StationInfo? Station { get; set; }
    }
}
