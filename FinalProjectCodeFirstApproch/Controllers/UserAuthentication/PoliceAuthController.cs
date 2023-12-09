using FinalProjectCodeFirstApproch.AuthenticationPart.Interfaces;
using FinalProjectCodeFirstApproch.Models.System_Administration;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProjectCodeFirstApproch.Controllers.UserAuthentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoliceAuthController : ControllerBase
    {
        private readonly IAuthentication _auth;
        public PoliceAuthController(IAuthentication authentication)
        {
            _auth = authentication;
        }
        [HttpPost("login")]
        public string Login([FromBody] LoginRequest obj)
        {
            var token = _auth.LogIn(obj);
            return token;
        }

        [HttpPost("assignRole")]
        public bool AssignRoleToUser([FromBody] AddPoliceRole policeRole)
        {
            var addPoliceRole = _auth.AssignRoleToPolice(policeRole);
            return addPoliceRole;
        }


        [HttpPost("addPolice")]
        public IActionResult AddUser([FromBody] PoliceUser policeUser)
        {
            try
            {
                var addPolice = _auth.AddPolice(policeUser);
                return Ok(addPolice);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        [HttpPost("addRole")]
        public Roles AddRole(int id, [FromBody] Roles role)
        {
            var addRole = _auth.AddRole(role);
            return addRole;
        }
    }
}
