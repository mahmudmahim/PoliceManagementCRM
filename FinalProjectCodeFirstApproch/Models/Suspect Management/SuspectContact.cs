using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectCodeFirstApproch.Models.Suspect_Management
{
    public class SuspectContact
    {
        public int SuspectContactId { get; set; }
        [Required]
        public string? ContactInfo { get; set; }
      
        public string? Description { get; set; }
        [ForeignKey("Suspect")]
        public int? SuspectId { get; set; }
        public virtual SuspectInfo? Suspect { get; set; }
    }
}
