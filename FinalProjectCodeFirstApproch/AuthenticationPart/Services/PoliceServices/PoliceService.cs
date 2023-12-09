using FinalProjectCodeFirstApproch.AuthenticationPart.Interfaces;
using FinalProjectCodeFirstApproch.Models.JunctionForAllClass;
using FinalProjectCodeFirstApproch.Models.System_Administration;

namespace FinalProjectCodeFirstApproch.AuthenticationPart.Services.PoliceServices
{
    public class PoliceService : IPoliceService
    {
        private readonly PoliceStationManagementDbContext _context;

        public PoliceService(PoliceStationManagementDbContext context)
        {
            _context = context;
        }

        public PoliceUser Addpolice(PoliceUser policeUser)
        {
            var police = _context.PoliceUsers.Add(policeUser);
            _context.SaveChanges();
            return police.Entity;
        }

        public List<PoliceUser> GetPoliceDetails()
        {
            var police = _context.PoliceUsers.ToList();
            return police;
        }
    }
}
