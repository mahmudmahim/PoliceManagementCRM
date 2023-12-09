using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FinalProjectCodeFirstApproch.Models.DTO.Investigation_Section
{
    public class GetInvestigationDTO
    {
        public int InvestigationInfoId { get; set; }
        [Required, Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }
        [Required, Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }
        [Required]
        public string? Status { get; set; }
        public string? Location { get; set; }
        public string? Details { get; set; }
        public int? CaseId { get; set; }
        [DisplayName("Officer Name")]
        public string? OfficerName { get; set; }
    }
}
