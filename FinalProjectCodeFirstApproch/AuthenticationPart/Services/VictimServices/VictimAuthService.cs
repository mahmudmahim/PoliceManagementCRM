using FinalProjectCodeFirstApproch.AuthenticationPart.Interfaces;
using FinalProjectCodeFirstApproch.Models.JunctionForAllClass;
using FinalProjectCodeFirstApproch.Models.System_Administration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FinalProjectCodeFirstApproch.AuthenticationPart.Services.VictimServices
{
    public class VictimAuthService : IVictimAuthentication
    {
        private readonly PoliceStationManagementDbContext _context;
        private readonly IConfiguration _configuration;

        public VictimAuthService(PoliceStationManagementDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

        }


        public VictimRegistration AddVictim(VictimRegistration victimRegistration)
        {
            var addVictim = _context.VictimRegs.Add(victimRegistration);
            _context.SaveChanges();
            return addVictim.Entity;
        }

        public string VictimLogIn(VictimLoginRequest loginRequest)
        {
            if (loginRequest.Email != null && loginRequest.Password != null)
            {
                var victim = _context.VictimRegs.SingleOrDefault(s => s.Email == loginRequest.Email && s.Password == loginRequest.Password);

                if (victim != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim("Id", victim.VictimRegistrationId.ToString()),
                        new Claim("Email",victim.Email)
                    };

                    //var policeRoles = _context.PoliceRoless.Where(x => x.PoliceUserId == victim.PoliceUserId).ToList();
                    //var roleIds = policeRoles.Select(x => x.RoleId).ToList();
                    //var roles = _context.Roles.Where(r => roleIds.Contains(r.RolesId)).ToList();

                    //foreach (var role in roles)
                    //{
                    //    claims.Add(new Claim("Roles", role.RoleName));
                    //}

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddDays(1),
                        signingCredentials: signIn);
                    var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

                    return jwtToken;
                }
                else
                {
                    throw new Exception("Victim user is not valid");
                }
            }
            else
            {
                throw new Exception("Credentials are not valid");
            }
        }
    }
}
