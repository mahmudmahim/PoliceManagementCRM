using System.ComponentModel.DataAnnotations;

namespace FinalProjectCodeFirstApproch.Models.Police_Management.ViewModels
{
    public class policeVM
    {
        // CaseInfo
        public string? Status { get; set; }

        //ReportInfo
        [Required]
        public string? Description { get; set; }

        //ShiftInfo
        public string? ShiftName { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Time")]
        public DateTime? StartTime { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)]
        [Display(Name = "End Time")]
        public DateTime? EndTime { get; set; }

        //StationInfo
        public string? StationName { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? ContactInfo { get; set; }
    }
}
