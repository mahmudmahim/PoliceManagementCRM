using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectCodeFirstApproch.Models.Criminal_Management
{
    public class PrisonRecords
    {

        public int PrisonRecordsId { get; set; }
        [Required, Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Entry Date")]
        public DateTime? EntryDate { get; set; }
        [Required, Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }
        [Required]
        public string? Status { get; set; }
        public string? ReasonForImprisonment { get; set; }
        [ForeignKey("CriminalInfo")]
        public int? CriminalId { get; set; }
        [ForeignKey("Prison")]
        public int? PrisonId { get; set; }
        public virtual CriminalInfo? CriminalInfo { get; set; }
        public virtual Prison? Prison { get; set; }
    }
}
