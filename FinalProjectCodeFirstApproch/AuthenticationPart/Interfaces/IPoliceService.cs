using FinalProjectCodeFirstApproch.Models.System_Administration;

namespace FinalProjectCodeFirstApproch.AuthenticationPart.Interfaces
{
    public interface IPoliceService
    {
        public List<PoliceUser> GetPoliceDetails();

        public PoliceUser Addpolice(PoliceUser policeUser);
    }
}
