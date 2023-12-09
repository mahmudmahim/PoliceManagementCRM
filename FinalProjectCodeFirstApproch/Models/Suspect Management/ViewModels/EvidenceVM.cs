using FinalProjectCodeFirstApproch.Models.Police_Management;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FinalProjectCodeFirstApproch.Models.JunctionForAllClass;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;

namespace FinalProjectCodeFirstApproch.Models.Suspect_Management.ViewModels
{
    public class EvidenceVM
    {
        public string? Description { get; set; }
        public string? Type { get; set; }
        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Collection Date")]
        public DateTime? CollectionDate { get; set; }
        public int? CaseId { get; set; }
    }
}