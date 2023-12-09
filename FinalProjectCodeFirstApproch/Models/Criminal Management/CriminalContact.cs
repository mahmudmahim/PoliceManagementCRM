using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectCodeFirstApproch.Models.Criminal_Management
{
    public class CriminalContact
    {
        public int CriminalContactId { get; set; }
        [Required]
        public string? ContactType { get; set; }
        [Required]
        public string? ContactInfo { get; set; }
        [Required]
        public string? Description { get; set; }
        [ForeignKey("CriminalInfo")]
        public int? CriminalId { get; set; }
        public virtual CriminalInfo? CriminalInfo { get; set; }
    }
}
