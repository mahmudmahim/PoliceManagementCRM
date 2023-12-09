using FinalProjectCodeFirstApproch.AuthenticationPart.Interfaces;
using FinalProjectCodeFirstApproch.Models.System_Administration;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProjectCodeFirstApproch.Controllers.UserAuthentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class VictimAuthController : ControllerBase
    {
        private readonly IVictimAuthentication _victimAuthentication;
        public VictimAuthController(IVictimAuthentication victimAuthentication)
        {
            _victimAuthentication = victimAuthentication;
        }
        [HttpPost("login")]
        public string Login([FromBody] VictimLoginRequest obj)
        {
            var token = _victimAuthentication.VictimLogIn(obj);
            return token;
        }


        [HttpPost("addVictim")]
        public VictimRegistration AddVictim([FromBody] VictimRegistration victimRegistration)
        {
            var addVictim = _victimAuthentication.AddVictim(victimRegistration);
            return addVictim;  
        }

    }
}
