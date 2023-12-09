using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectCodeFirstApproch.Models.Police_Management.ViewModels
{
    public class reportVM
    {
        public int ReportsInfoId { get; set; }
        public string? Description { get; set; }
        
        public int? OfficerId { get; set; }
      
        public int? CaseId { get; set; }
    }
}
