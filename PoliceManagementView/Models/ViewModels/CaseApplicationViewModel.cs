using Microsoft.AspNetCore.Mvc.Rendering;

namespace PoliceManagementView.Models.ViewModels
{
    public class CaseApplicationViewModel
    {
        // VictimCaseApply properties
        public string? VictimName { get; set; }
        public int? VictimAge { get; set; }
        public string VictimGender { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string Profession { get; set; }
        public string VictimPicture { get; set; }
        public string Nationality { get; set; }
        public string MaritalStatus { get; set; }
        public long? Nid { get; set; }
        public string CrimeSpot { get; set; }
        public string CrimeDescription { get; set; }

        // SuspectInfo properties
        public string SuspectName { get; set; }
        public int? SuspectAge { get; set; }
        public string SuspectGender { get; set; }
        public string SuspectAddress { get; set; }
        public string SuspectPhoneNo { get; set; }
        public string SuspectPicture { get; set; }
        public string SuspectDescription { get; set; }

        // CrimeType properties
        public string CrimeTypeName { get; set; }
        public List<SelectListItem> CrimeTypeList { get; set; }

        // WitnessInfo properties
        public string WitnessName { get; set; }
        public int? WitnessAge { get; set; }
        public string WitnessGender { get; set; }
        public string WitnessAddress { get; set; }
        public string WitnessPicture { get; set; }
        public string WitnessPhoneNo { get; set; }
        public string WitnessProfession { get; set; }
        public string WitnessNationality { get; set; }

        // Picture files
        public IFormFile VictimPictureFile { get; set; }
        public IFormFile SuspectPictureFile { get; set; }
        public IFormFile WitnessPictureFile { get; set; }
    }
}
