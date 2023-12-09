using FinalProjectCodeFirstApproch.Models.System_Administration;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectCodeFirstApproch.Models.Police_Management
{
    public class StationInfo
    {
        public int StationInfoId { get; set; }

        public string? StationName { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? ContactInfo { get; set; }
        [ForeignKey("PoliceUser")]
        public int? PoliceId { get; set; }
        public virtual PoliceUser? PoliceUser { get; set; }

        public virtual ICollection<PoliceRegistration> PoliceRegs { get; set; } = new List<PoliceRegistration>();
    }
}
