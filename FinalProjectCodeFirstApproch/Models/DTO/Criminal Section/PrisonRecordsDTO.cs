using FinalProjectCodeFirstApproch.Models.Criminal_Management;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinalProjectCodeFirstApproch.Models.DTO.Criminal_Section
{
    public class PrisonRecordsDTO
    {
        [Required, Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Entry Date")]
        public DateTime? EntryDate { get; set; }
        [Required, Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }
        [Required]
        public string? Status { get; set; }
        public string? ReasonForImprisonment { get; set; }
        public int? CriminalId { get; set; }
        public int? PrisonId { get; set; }
    }
}
