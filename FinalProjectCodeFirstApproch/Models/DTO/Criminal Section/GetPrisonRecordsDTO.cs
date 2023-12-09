using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FinalProjectCodeFirstApproch.Models.DTO.Criminal_Section
{
    public class GetPrisonRecordsDTO
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
        [DisplayName("Criminal Name")]
        public string? CriminalName { get; set; }
        [DisplayName("Prison Name")]
        public string? PrisonName { get; set; }
    }
}
