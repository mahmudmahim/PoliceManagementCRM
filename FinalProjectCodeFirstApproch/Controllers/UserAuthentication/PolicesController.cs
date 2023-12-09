using FinalProjectCodeFirstApproch.AuthenticationPart.Interfaces;
using FinalProjectCodeFirstApproch.Models.System_Administration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProjectCodeFirstApproch.Controllers.UserAuthentication
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
    public class PolicesController : ControllerBase
    {
        private readonly IPoliceService _policeServices;

        public PolicesController(IPoliceService policeServices)
        {
            _policeServices = policeServices;
        }

        [HttpGet]
        public List<PoliceUser> GetEmployees()
        {
            return _policeServices.GetPoliceDetails();
        }

        [HttpPost]
        public PoliceUser AddEmployeer([FromBody] PoliceUser policeUser)
        {
            var police = _policeServices.Addpolice(policeUser);
            return police;
        }
    }
}
