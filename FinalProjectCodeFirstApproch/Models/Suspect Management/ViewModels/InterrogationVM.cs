using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinalProjectCodeFirstApproch.Models.Suspect_Management.ViewModels
{
    public class InterrogationVM
    {
        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime? Date { get; set; }
        public string? Details { get; set; }
        public int? CaseId { get; set; }
        public int? OfficerId { get; set; }
        public int? SuspectId { get; set; }
    }
}
