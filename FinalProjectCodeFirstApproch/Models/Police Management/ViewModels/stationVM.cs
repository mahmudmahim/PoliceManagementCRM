using System.ComponentModel.DataAnnotations;

namespace FinalProjectCodeFirstApproch.Models.Police_Management.ViewModels
{
    public class stationVM
    {
        public string? StationName { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? ContactInfo { get; set; }
        public int? PoliceId { get; set; }
    }
}
