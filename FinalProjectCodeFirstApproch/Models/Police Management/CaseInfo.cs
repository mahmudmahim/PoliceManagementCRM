using FinalProjectCodeFirstApproch.Models.Criminal_Management;
using FinalProjectCodeFirstApproch.Models.Investigation_Management;
using FinalProjectCodeFirstApproch.Models.Suspect_Management;
using FinalProjectCodeFirstApproch.Models.System_Administration;
using FinalProjectCodeFirstApproch.Models.Victim_Management;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectCodeFirstApproch.Models.Police_Management
{
    public class CaseInfo
    {
        public int CaseInfoId { get; set; }
        public virtual ICollection<CriminalInfo> Criminals { get; set; } = new List<CriminalInfo>();
        public virtual ICollection<EvidenceInfo> EvidenceInfos { get; set; } = new List<EvidenceInfo>();
        public virtual ICollection<InterrogationsInfo> InterrogationsInfos { get; set; } = new List<InterrogationsInfo>();
        public virtual ICollection<InvestigationInfo> InvestigationInfos { get; set; } = new List<InvestigationInfo>();
        public virtual ICollection<ReportAnalysis> ReportAnalyses { get; set; } = new List<ReportAnalysis>();
        public virtual ICollection<ReportsInfo> ReportsInfos { get; set; } = new List<ReportsInfo>();
        [Required]
        public string? Status { get; set; }
        [ForeignKey("PoliceUser")]
        public int? PoliceId { get; set; }
        [ForeignKey("SuspectInfo")]
        public int? SuspectId { get; set; }
        [ForeignKey("VictimCaseApply")]
        public int? VictimId { get; set; }
        [ForeignKey("WitnessInfo")]
        public int? WitnessId { get; set; }
        public virtual PoliceUser? PoliceUser { get; set; }
        public virtual SuspectInfo? SuspectInfo { get; set; }

        public virtual VictimCaseApply? VictimCaseApply { get; set; }

        public virtual WitnessInfo? WitnessInfo { get; set; }
    }
}
