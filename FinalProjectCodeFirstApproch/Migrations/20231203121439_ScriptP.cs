using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProjectCodeFirstApproch.Migrations
{
    /// <inheritdoc />
    public partial class ScriptP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CrimeTypes",
                columns: table => new
                {
                    CrimeTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrimeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrimeTypes", x => x.CrimeTypeId);
                });

            migrationBuilder.CreateTable(
                name: "PoliceIdentitieses",
                columns: table => new
                {
                    PoliceIdentitiesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceIdentitiesNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoliceIdentitieses", x => x.PoliceIdentitiesId);
                });

            migrationBuilder.CreateTable(
                name: "PoliceRoless",
                columns: table => new
                {
                    PoliceRolesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceUserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoliceRoless", x => x.PoliceRolesId);
                });

            migrationBuilder.CreateTable(
                name: "Prisons",
                columns: table => new
                {
                    PrisonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrisonName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: true),
                    ContactInfo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prisons", x => x.PrisonId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RolesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RolesId);
                });

            migrationBuilder.CreateTable(
                name: "ShiftInfos",
                columns: table => new
                {
                    ShiftInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<DateTime>(type: "date", nullable: false),
                    EndTime = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftInfos", x => x.ShiftInfoId);
                });

            migrationBuilder.CreateTable(
                name: "VictimRegs",
                columns: table => new
                {
                    VictimRegistrationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VictimRegs", x => x.VictimRegistrationId);
                });

            migrationBuilder.CreateTable(
                name: "WeaponCategories",
                columns: table => new
                {
                    WeaponCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeaponCategories", x => x.WeaponCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "VictimsCaseApplies",
                columns: table => new
                {
                    VictimCaseApplyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Profession = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nid = table.Column<long>(type: "bigint", nullable: true),
                    CrimeTypeId = table.Column<int>(type: "int", nullable: true),
                    CrimeSpot = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CrimeDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VictimsCaseApplies", x => x.VictimCaseApplyId);
                    table.ForeignKey(
                        name: "FK_VictimsCaseApplies_CrimeTypes_CrimeTypeId",
                        column: x => x.CrimeTypeId,
                        principalTable: "CrimeTypes",
                        principalColumn: "CrimeTypeId");
                });

            migrationBuilder.CreateTable(
                name: "PoliceUsers",
                columns: table => new
                {
                    PoliceUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceIdentitiesNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PoliceIdentitiesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoliceUsers", x => x.PoliceUserId);
                    table.ForeignKey(
                        name: "FK_PoliceUsers_PoliceIdentitieses_PoliceIdentitiesId",
                        column: x => x.PoliceIdentitiesId,
                        principalTable: "PoliceIdentitieses",
                        principalColumn: "PoliceIdentitiesId");
                });

            migrationBuilder.CreateTable(
                name: "SuspectInfos",
                columns: table => new
                {
                    SuspectInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VictimCaseApplyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuspectInfos", x => x.SuspectInfoId);
                    table.ForeignKey(
                        name: "FK_SuspectInfos_VictimsCaseApplies_VictimCaseApplyId",
                        column: x => x.VictimCaseApplyId,
                        principalTable: "VictimsCaseApplies",
                        principalColumn: "VictimCaseApplyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WitnessInfos",
                columns: table => new
                {
                    WitnessInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Profession = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VictimCaseApplyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WitnessInfos", x => x.WitnessInfoId);
                    table.ForeignKey(
                        name: "FK_WitnessInfos_VictimsCaseApplies_VictimCaseApplyId",
                        column: x => x.VictimCaseApplyId,
                        principalTable: "VictimsCaseApplies",
                        principalColumn: "VictimCaseApplyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StationInfos",
                columns: table => new
                {
                    StationInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PoliceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StationInfos", x => x.StationInfoId);
                    table.ForeignKey(
                        name: "FK_StationInfos_PoliceUsers_PoliceId",
                        column: x => x.PoliceId,
                        principalTable: "PoliceUsers",
                        principalColumn: "PoliceUserId");
                });

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    WeaponInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AcquisitionDate = table.Column<DateTime>(type: "date", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    OwnerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.WeaponInfoId);
                    table.ForeignKey(
                        name: "FK_Weapons_PoliceUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "PoliceUsers",
                        principalColumn: "PoliceUserId");
                    table.ForeignKey(
                        name: "FK_Weapons_WeaponCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "WeaponCategories",
                        principalColumn: "WeaponCategoryId");
                });

            migrationBuilder.CreateTable(
                name: "SuspectContacts",
                columns: table => new
                {
                    SuspectContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuspectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuspectContacts", x => x.SuspectContactId);
                    table.ForeignKey(
                        name: "FK_SuspectContacts_SuspectInfos_SuspectId",
                        column: x => x.SuspectId,
                        principalTable: "SuspectInfos",
                        principalColumn: "SuspectInfoId");
                });

            migrationBuilder.CreateTable(
                name: "CaseInfos",
                columns: table => new
                {
                    CaseInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PoliceId = table.Column<int>(type: "int", nullable: true),
                    SuspectId = table.Column<int>(type: "int", nullable: true),
                    VictimId = table.Column<int>(type: "int", nullable: true),
                    WitnessId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseInfos", x => x.CaseInfoId);
                    table.ForeignKey(
                        name: "FK_CaseInfos_PoliceUsers_PoliceId",
                        column: x => x.PoliceId,
                        principalTable: "PoliceUsers",
                        principalColumn: "PoliceUserId");
                    table.ForeignKey(
                        name: "FK_CaseInfos_SuspectInfos_SuspectId",
                        column: x => x.SuspectId,
                        principalTable: "SuspectInfos",
                        principalColumn: "SuspectInfoId");
                    table.ForeignKey(
                        name: "FK_CaseInfos_VictimsCaseApplies_VictimId",
                        column: x => x.VictimId,
                        principalTable: "VictimsCaseApplies",
                        principalColumn: "VictimCaseApplyId");
                    table.ForeignKey(
                        name: "FK_CaseInfos_WitnessInfos_WitnessId",
                        column: x => x.WitnessId,
                        principalTable: "WitnessInfos",
                        principalColumn: "WitnessInfoId");
                });

            migrationBuilder.CreateTable(
                name: "PoliceRegs",
                columns: table => new
                {
                    PoliceRegistrationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StationId = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoliceRegs", x => x.PoliceRegistrationId);
                    table.ForeignKey(
                        name: "FK_PoliceRegs_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RolesId");
                    table.ForeignKey(
                        name: "FK_PoliceRegs_StationInfos_StationId",
                        column: x => x.StationId,
                        principalTable: "StationInfos",
                        principalColumn: "StationInfoId");
                });

            migrationBuilder.CreateTable(
                name: "Criminals",
                columns: table => new
                {
                    CriminalInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaseId = table.Column<int>(type: "int", nullable: true),
                    SuspectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Criminals", x => x.CriminalInfoId);
                    table.ForeignKey(
                        name: "FK_Criminals_CaseInfos_CaseId",
                        column: x => x.CaseId,
                        principalTable: "CaseInfos",
                        principalColumn: "CaseInfoId");
                    table.ForeignKey(
                        name: "FK_Criminals_SuspectInfos_SuspectId",
                        column: x => x.SuspectId,
                        principalTable: "SuspectInfos",
                        principalColumn: "SuspectInfoId");
                });

            migrationBuilder.CreateTable(
                name: "EvidenceInfos",
                columns: table => new
                {
                    EvidenceInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollectionDate = table.Column<DateTime>(type: "date", nullable: true),
                    CaseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvidenceInfos", x => x.EvidenceInfoId);
                    table.ForeignKey(
                        name: "FK_EvidenceInfos_CaseInfos_CaseId",
                        column: x => x.CaseId,
                        principalTable: "CaseInfos",
                        principalColumn: "CaseInfoId");
                });

            migrationBuilder.CreateTable(
                name: "InterrogationsInfos",
                columns: table => new
                {
                    InterrogationsInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "date", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaseId = table.Column<int>(type: "int", nullable: true),
                    OfficerId = table.Column<int>(type: "int", nullable: true),
                    SuspectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterrogationsInfos", x => x.InterrogationsInfoId);
                    table.ForeignKey(
                        name: "FK_InterrogationsInfos_CaseInfos_CaseId",
                        column: x => x.CaseId,
                        principalTable: "CaseInfos",
                        principalColumn: "CaseInfoId");
                    table.ForeignKey(
                        name: "FK_InterrogationsInfos_PoliceUsers_OfficerId",
                        column: x => x.OfficerId,
                        principalTable: "PoliceUsers",
                        principalColumn: "PoliceUserId");
                    table.ForeignKey(
                        name: "FK_InterrogationsInfos_SuspectInfos_SuspectId",
                        column: x => x.SuspectId,
                        principalTable: "SuspectInfos",
                        principalColumn: "SuspectInfoId");
                });

            migrationBuilder.CreateTable(
                name: "InvestigationInfos",
                columns: table => new
                {
                    InvestigationInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaseId = table.Column<int>(type: "int", nullable: true),
                    OfficerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestigationInfos", x => x.InvestigationInfoId);
                    table.ForeignKey(
                        name: "FK_InvestigationInfos_CaseInfos_CaseId",
                        column: x => x.CaseId,
                        principalTable: "CaseInfos",
                        principalColumn: "CaseInfoId");
                    table.ForeignKey(
                        name: "FK_InvestigationInfos_PoliceUsers_OfficerId",
                        column: x => x.OfficerId,
                        principalTable: "PoliceUsers",
                        principalColumn: "PoliceUserId");
                });

            migrationBuilder.CreateTable(
                name: "ReportAnalyses",
                columns: table => new
                {
                    ReportAnalysisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnalysisResults = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportingDate = table.Column<DateTime>(type: "date", nullable: false),
                    Conclusions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaseId = table.Column<int>(type: "int", nullable: true),
                    OfficerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportAnalyses", x => x.ReportAnalysisId);
                    table.ForeignKey(
                        name: "FK_ReportAnalyses_CaseInfos_CaseId",
                        column: x => x.CaseId,
                        principalTable: "CaseInfos",
                        principalColumn: "CaseInfoId");
                    table.ForeignKey(
                        name: "FK_ReportAnalyses_PoliceUsers_OfficerId",
                        column: x => x.OfficerId,
                        principalTable: "PoliceUsers",
                        principalColumn: "PoliceUserId");
                });

            migrationBuilder.CreateTable(
                name: "ReportsInfos",
                columns: table => new
                {
                    ReportsInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfficerId = table.Column<int>(type: "int", nullable: true),
                    CaseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportsInfos", x => x.ReportsInfoId);
                    table.ForeignKey(
                        name: "FK_ReportsInfos_CaseInfos_CaseId",
                        column: x => x.CaseId,
                        principalTable: "CaseInfos",
                        principalColumn: "CaseInfoId");
                    table.ForeignKey(
                        name: "FK_ReportsInfos_PoliceUsers_OfficerId",
                        column: x => x.OfficerId,
                        principalTable: "PoliceUsers",
                        principalColumn: "PoliceUserId");
                });

            migrationBuilder.CreateTable(
                name: "CriminalActivities",
                columns: table => new
                {
                    CriminalActivityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CriminalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CriminalActivities", x => x.CriminalActivityId);
                    table.ForeignKey(
                        name: "FK_CriminalActivities_Criminals_CriminalId",
                        column: x => x.CriminalId,
                        principalTable: "Criminals",
                        principalColumn: "CriminalInfoId");
                });

            migrationBuilder.CreateTable(
                name: "CriminalContacts",
                columns: table => new
                {
                    CriminalContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CriminalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CriminalContacts", x => x.CriminalContactId);
                    table.ForeignKey(
                        name: "FK_CriminalContacts_Criminals_CriminalId",
                        column: x => x.CriminalId,
                        principalTable: "Criminals",
                        principalColumn: "CriminalInfoId");
                });

            migrationBuilder.CreateTable(
                name: "PrisonRecords",
                columns: table => new
                {
                    PrisonRecordsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntryDate = table.Column<DateTime>(type: "date", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "date", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReasonForImprisonment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CriminalId = table.Column<int>(type: "int", nullable: true),
                    PrisonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrisonRecords", x => x.PrisonRecordsId);
                    table.ForeignKey(
                        name: "FK_PrisonRecords_Criminals_CriminalId",
                        column: x => x.CriminalId,
                        principalTable: "Criminals",
                        principalColumn: "CriminalInfoId");
                    table.ForeignKey(
                        name: "FK_PrisonRecords_Prisons_PrisonId",
                        column: x => x.PrisonId,
                        principalTable: "Prisons",
                        principalColumn: "PrisonId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaseInfos_PoliceId",
                table: "CaseInfos",
                column: "PoliceId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseInfos_SuspectId",
                table: "CaseInfos",
                column: "SuspectId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseInfos_VictimId",
                table: "CaseInfos",
                column: "VictimId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseInfos_WitnessId",
                table: "CaseInfos",
                column: "WitnessId");

            migrationBuilder.CreateIndex(
                name: "IX_CriminalActivities_CriminalId",
                table: "CriminalActivities",
                column: "CriminalId");

            migrationBuilder.CreateIndex(
                name: "IX_CriminalContacts_CriminalId",
                table: "CriminalContacts",
                column: "CriminalId");

            migrationBuilder.CreateIndex(
                name: "IX_Criminals_CaseId",
                table: "Criminals",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Criminals_SuspectId",
                table: "Criminals",
                column: "SuspectId");

            migrationBuilder.CreateIndex(
                name: "IX_EvidenceInfos_CaseId",
                table: "EvidenceInfos",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_InterrogationsInfos_CaseId",
                table: "InterrogationsInfos",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_InterrogationsInfos_OfficerId",
                table: "InterrogationsInfos",
                column: "OfficerId");

            migrationBuilder.CreateIndex(
                name: "IX_InterrogationsInfos_SuspectId",
                table: "InterrogationsInfos",
                column: "SuspectId");

            migrationBuilder.CreateIndex(
                name: "IX_InvestigationInfos_CaseId",
                table: "InvestigationInfos",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_InvestigationInfos_OfficerId",
                table: "InvestigationInfos",
                column: "OfficerId");

            migrationBuilder.CreateIndex(
                name: "IX_PoliceRegs_RoleId",
                table: "PoliceRegs",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_PoliceRegs_StationId",
                table: "PoliceRegs",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_PoliceUsers_PoliceIdentitiesId",
                table: "PoliceUsers",
                column: "PoliceIdentitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_PrisonRecords_CriminalId",
                table: "PrisonRecords",
                column: "CriminalId");

            migrationBuilder.CreateIndex(
                name: "IX_PrisonRecords_PrisonId",
                table: "PrisonRecords",
                column: "PrisonId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportAnalyses_CaseId",
                table: "ReportAnalyses",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportAnalyses_OfficerId",
                table: "ReportAnalyses",
                column: "OfficerId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportsInfos_CaseId",
                table: "ReportsInfos",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportsInfos_OfficerId",
                table: "ReportsInfos",
                column: "OfficerId");

            migrationBuilder.CreateIndex(
                name: "IX_StationInfos_PoliceId",
                table: "StationInfos",
                column: "PoliceId");

            migrationBuilder.CreateIndex(
                name: "IX_SuspectContacts_SuspectId",
                table: "SuspectContacts",
                column: "SuspectId");

            migrationBuilder.CreateIndex(
                name: "IX_SuspectInfos_VictimCaseApplyId",
                table: "SuspectInfos",
                column: "VictimCaseApplyId");

            migrationBuilder.CreateIndex(
                name: "IX_VictimsCaseApplies_CrimeTypeId",
                table: "VictimsCaseApplies",
                column: "CrimeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_CategoryId",
                table: "Weapons",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_OwnerId",
                table: "Weapons",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_WitnessInfos_VictimCaseApplyId",
                table: "WitnessInfos",
                column: "VictimCaseApplyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CriminalActivities");

            migrationBuilder.DropTable(
                name: "CriminalContacts");

            migrationBuilder.DropTable(
                name: "EvidenceInfos");

            migrationBuilder.DropTable(
                name: "InterrogationsInfos");

            migrationBuilder.DropTable(
                name: "InvestigationInfos");

            migrationBuilder.DropTable(
                name: "PoliceRegs");

            migrationBuilder.DropTable(
                name: "PoliceRoless");

            migrationBuilder.DropTable(
                name: "PrisonRecords");

            migrationBuilder.DropTable(
                name: "ReportAnalyses");

            migrationBuilder.DropTable(
                name: "ReportsInfos");

            migrationBuilder.DropTable(
                name: "ShiftInfos");

            migrationBuilder.DropTable(
                name: "SuspectContacts");

            migrationBuilder.DropTable(
                name: "VictimRegs");

            migrationBuilder.DropTable(
                name: "Weapons");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "StationInfos");

            migrationBuilder.DropTable(
                name: "Criminals");

            migrationBuilder.DropTable(
                name: "Prisons");

            migrationBuilder.DropTable(
                name: "WeaponCategories");

            migrationBuilder.DropTable(
                name: "CaseInfos");

            migrationBuilder.DropTable(
                name: "PoliceUsers");

            migrationBuilder.DropTable(
                name: "SuspectInfos");

            migrationBuilder.DropTable(
                name: "WitnessInfos");

            migrationBuilder.DropTable(
                name: "PoliceIdentitieses");

            migrationBuilder.DropTable(
                name: "VictimsCaseApplies");

            migrationBuilder.DropTable(
                name: "CrimeTypes");
        }
    }
}
