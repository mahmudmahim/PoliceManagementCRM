using FinalProjectCodeFirstApproch.AuthenticationPart.Interfaces;
using FinalProjectCodeFirstApproch.Models.JunctionForAllClass;
using FinalProjectCodeFirstApproch.Models.System_Administration;

namespace FinalProjectCodeFirstApproch.AuthenticationPart.Services.VictimServices
{
    public class VictimService : IVictimService
    {
        private readonly PoliceStationManagementDbContext _context;

        public VictimService(PoliceStationManagementDbContext context)
        {
            _context = context;
        }
        public VictimRegistration AddVictim(VictimRegistration victimUser)
        {
           var victim = _context.VictimRegs.Add(victimUser);
           _context.SaveChanges();
            return victim.Entity;
        }

        public List<VictimRegistration> GetVictimDetails()
        {
            var victim = _context.VictimRegs.ToList();
            return victim;
        }
    }
}
