using FinalProjectCodeFirstApproch.Models.Police_Management;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;

namespace FinalProjectCodeFirstApproch.Models.Suspect_Management
{
    public class EvidenceInfo
    {
        public int EvidenceInfoId { get; set; }
        [Required]
        public string? Description { get; set; }
        public string? Type { get; set; }
        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Collection Date")]
        public DateTime? CollectionDate { get; set; }
        [ForeignKey("Case")]
        public int? CaseId { get; set; }
        public virtual CaseInfo? Case { get; set; }
    }
}
