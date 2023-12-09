using FinalProjectCodeFirstApproch.Models.Criminal_Management;
using FinalProjectCodeFirstApproch.Models.Investigation_Management;
using FinalProjectCodeFirstApproch.Models.Police_Management;
using FinalProjectCodeFirstApproch.Models.Suspect_Management;
using FinalProjectCodeFirstApproch.Models.Victim_Management;
using FinalProjectCodeFirstApproch.Models.Weapon_Management;
using Microsoft.EntityFrameworkCore;
using FinalProjectCodeFirstApproch.Models.System_Administration;

namespace FinalProjectCodeFirstApproch.Models.JunctionForAllClass
{
    public class PoliceStationManagementDbContext : DbContext
    {
        public PoliceStationManagementDbContext()
        {

        }

        public PoliceStationManagementDbContext(DbContextOptions<PoliceStationManagementDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CaseInfo> CaseInfos { get; set; }

        public virtual DbSet<CrimeType> CrimeTypes { get; set; }

        public virtual DbSet<CriminalInfo> Criminals { get; set; }

        public virtual DbSet<CriminalActivity> CriminalActivities { get; set; }

        public virtual DbSet<CriminalContact> CriminalContacts { get; set; }

        public virtual DbSet<EvidenceInfo> EvidenceInfos { get; set; }

        public virtual DbSet<InterrogationsInfo> InterrogationsInfos { get; set; }

        public virtual DbSet<InvestigationInfo> InvestigationInfos { get; set; }
        public virtual DbSet<PoliceRegistration> PoliceRegs { get; set; }

        public virtual DbSet<Prison> Prisons { get; set; }

        public virtual DbSet<PrisonRecords> PrisonRecords { get; set; }

        public virtual DbSet<ReportAnalysis> ReportAnalyses { get; set; }

        public virtual DbSet<ReportsInfo> ReportsInfos { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }

        public virtual DbSet<ShiftInfo> ShiftInfos { get; set; }

        public virtual DbSet<StationInfo> StationInfos { get; set; }

        public virtual DbSet<SuspectContact> SuspectContacts { get; set; }

        public virtual DbSet<SuspectInfo> SuspectInfos { get; set; }

        public virtual DbSet<VictimRegistration> VictimRegs { get; set; }

        public virtual DbSet<VictimCaseApply> VictimsCaseApplies { get; set; }

        public virtual DbSet<WeaponInfo> Weapons { get; set; }

        public virtual DbSet<WeaponCategory> WeaponCategories { get; set; }

        public virtual DbSet<WitnessInfo> WitnessInfos { get; set; }
        public virtual DbSet<PoliceRoles> PoliceRoless { get; set; }
        public virtual DbSet<PoliceUser> PoliceUsers { get; set; }
        public virtual DbSet<PoliceIdentities> PoliceIdentitieses { get; set; }
    }
}
