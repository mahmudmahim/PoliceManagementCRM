using FinalProjectCodeFirstApproch.Models.System_Administration;

namespace FinalProjectCodeFirstApproch.AuthenticationPart.Interfaces
{
    public interface IVictimAuthentication
    {
        VictimRegistration AddVictim(VictimRegistration victimRegistration);
        string VictimLogIn(VictimLoginRequest loginRequest);
    }
}
