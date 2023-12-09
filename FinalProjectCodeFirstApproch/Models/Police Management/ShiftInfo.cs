using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinalProjectCodeFirstApproch.Models.Police_Management
{
    public class ShiftInfo
    {
        public int ShiftInfoId { get; set; }

        public string? ShiftName { get; set; }
        [Required, Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Time")]
        public DateTime? StartTime { get; set; }
        [Required, Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "End Time")]
        public DateTime? EndTime { get; set; }
    }
}
