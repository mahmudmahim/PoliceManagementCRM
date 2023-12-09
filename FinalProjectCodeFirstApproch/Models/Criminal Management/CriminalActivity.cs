using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectCodeFirstApproch.Models.Criminal_Management
{
    public class CriminalActivity
    {
        public int CriminalActivityId { get; set; }
        [Required]
        public string? Type { get; set; }
        [Required]
        public string? Description { get; set; }
        [ForeignKey("CriminalInfo")]
        public int? CriminalId { get; set; }
        public virtual CriminalInfo? CriminalInfo { get; set; }
    }
}
