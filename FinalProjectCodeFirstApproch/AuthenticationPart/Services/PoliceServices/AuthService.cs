using FinalProjectCodeFirstApproch.AuthenticationPart.Interfaces;
using FinalProjectCodeFirstApproch.Models.JunctionForAllClass;
using FinalProjectCodeFirstApproch.Models.System_Administration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FinalProjectCodeFirstApproch.AuthenticationPart.Services.PoliceServices
{
    public class AuthService : IAuthentication
    {
        private readonly PoliceStationManagementDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(PoliceStationManagementDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

        }

        public PoliceUser AddPolice(PoliceUser policeUser)
        {
            var identities = _context.PoliceIdentitieses.SingleOrDefault(x => x.PoliceIdentitiesNumber == policeUser.PoliceIdentitiesNumber);
            if (identities == null)
            {
                throw new Exception("Invalid Police Identities Number");
            }

            var existingUser = _context.PoliceUsers.SingleOrDefault(x => x.PoliceIdentitiesNumber == policeUser.PoliceIdentitiesNumber);

            if (existingUser != null)
            {
                throw new Exception("Police User with the same PoliceIdentitiesNumber already exists");
            }

            var addPolice = _context.PoliceUsers.Add(policeUser);
            _context.SaveChanges();
            return addPolice.Entity;
        }

        public Roles AddRole(Roles role)
        {
            var addRole = _context.Roles.Add(role);
            _context.SaveChanges();
            return addRole.Entity;
        }


        public bool AssignRoleToPolice(AddPoliceRole obj)
        {
            try
            {
                var addRoles = new List<PoliceRoles>();
                var user = _context.PoliceUsers.SingleOrDefault(s => s.PoliceUserId == obj.PoliceUserId);
                if (user == null)
                {
                    throw new Exception("User is not valid");
                }
                foreach (int role in obj.RoleId)
                {
                    var policeRole = new PoliceRoles();
                    policeRole.RoleId = role;
                    policeRole.PoliceUserId = user.PoliceUserId;
                    addRoles.Add(policeRole);
                }
                _context.PoliceRoless.AddRange(addRoles);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string LogIn(LoginRequest loginRequest)
        {
            if (loginRequest.Email != null && loginRequest.Password != null)
            {
                var police = _context.PoliceUsers.SingleOrDefault(s => s.Email == loginRequest.Email && s.Password == loginRequest.Password);

                if (police != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim("Id", police.PoliceUserId.ToString()),
                        new Claim("Email",police.Email)
                    };

                    var policeRoles = _context.PoliceRoless.Where(x => x.PoliceUserId == police.PoliceUserId).ToList();
                    var roleIds = policeRoles.Select(x => x.RoleId).ToList();
                    var roles = _context.Roles.Where(r => roleIds.Contains(r.RolesId)).ToList();

                    foreach (var role in roles)
                    {
                        claims.Add(new Claim("Roles", role.RoleName));
                    }

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
                    throw new Exception("User is not valid");
                }
            }
            else
            {
                throw new Exception("Credentials are not valid");
            }
        }
    }
}
