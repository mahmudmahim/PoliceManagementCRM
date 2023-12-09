using FinalProjectCodeFirstApproch.Models.System_Administration;

namespace FinalProjectCodeFirstApproch.AuthenticationPart.Interfaces
{
    public interface IVictimService
    {
        public List<VictimRegistration> GetVictimDetails();

        public VictimRegistration AddVictim(VictimRegistration victimUser);
    }
}
