using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalProjectCodeFirstApproch.Models.ViewModels
{
    public class CaseApplicationViewModel
    {
        // VictimCaseApply properties

        public string? VictimName { get; set; }
        public int? VictimAge { get; set; }
        public string? VictimGender { get; set; } = default!;
        public string? Address { get; set; } = default!;
        public string? PhoneNo { get; set; } = default!;
        public string? Profession { get; set; } = default!;
        public string? Nationality { get; set; } = default!;
        public string? MaritalStatus { get; set; } = default!;
        public long? Nid { get; set; }
        public string? CrimeSpot { get; set; } = default!;
        public string? CrimeDescription { get; set; } = default!;

        // SuspectInfo properties
        
        public string? SuspectName { get; set; } = default!;
        public int? SuspectAge { get; set; }
        public string? SuspectGender { get; set; } = default!;
        public string? SuspectAddress { get; set; } = default!;
        public string? SuspectPhoneNo { get; set; } = default!;
        public string? SuspectDescription { get; set; } = default!;

        // CrimeType properties
        public string? CrimeTypeName { get; set; } = default!;

        // WitnessInfo properties

        public string? WitnessName { get; set; } = default!;
        public int? WitnessAge { get; set; }
        public string? WitnessGender { get; set; } = default!;
        public string? WitnessAddress { get; set; } = default!;
        public string? WitnessPhoneNo { get; set; } = default!;
        public string? WitnessProfession { get; set; } = default!;
        public string? WitnessNationality { get; set; } = default!;

        // Picture files
        public IFormFile? VictimPictureFile { get; set; }
        public IFormFile? SuspectPictureFile { get; set; }
        public IFormFile? WitnessPictureFile { get; set; }
    }
}
