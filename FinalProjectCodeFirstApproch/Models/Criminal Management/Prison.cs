using System.ComponentModel.DataAnnotations;

namespace FinalProjectCodeFirstApproch.Models.Criminal_Management
{
    public class Prison
    {
        public int PrisonId { get; set; }
        [Required]
        public string? PrisonName { get; set; }
        [Required]
        public string? Location { get; set; }
        public int? Capacity { get; set; }
        [Required]
        public string? ContactInfo { get; set; }

        public virtual ICollection<PrisonRecords> PrisonRecords { get; set; } = new List<PrisonRecords>();
    }
}
