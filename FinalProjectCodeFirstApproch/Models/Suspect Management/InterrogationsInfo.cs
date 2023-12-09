using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using FinalProjectCodeFirstApproch.Models.Police_Management;
using FinalProjectCodeFirstApproch.Models.System_Administration;
using FinalProjectCodeFirstApproch.Models.JunctionForAllClass;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;

namespace FinalProjectCodeFirstApproch.Models.Suspect_Management
{
    public class InterrogationsInfo
    {

        public int InterrogationsInfoId { get; set; }

        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime? Date { get; set; }
        public string? Details { get; set; }
        [ForeignKey("Case")]
        public int? CaseId { get; set; }
        [ForeignKey("PoliceUser")]
        public int? OfficerId { get; set; }
        [ForeignKey("Suspect")]
        public int? SuspectId { get; set; }
        public virtual CaseInfo? Case { get; set; }
        public virtual PoliceUser? PoliceUser { get; set; }
        public virtual SuspectInfo? Suspect { get; set; }
    }
}