using FinalProjectCodeFirstApproch.Models.System_Administration;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace FinalProjectCodeFirstApproch.AuthenticationPart.Interfaces
{
    public interface IAuthentication
    {
        PoliceUser AddPolice(PoliceUser policeUser);
        string LogIn(LoginRequest loginRequest);

        Roles AddRole(Roles role);

        bool AssignRoleToPolice(AddPoliceRole prole);
    }
}
