using mbanq.API.Data;
using mbanq.API.Dtos;
using mbanq.API.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace mbanq.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly MBANQContext _context;
        private readonly AppSettings _appSettings;

        public AuthController(MBANQContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginDto login)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var foundUser = await _context.MbqAppUsers.Where(x => x.Email == login.Email).FirstOrDefaultAsync();
            if (foundUser == null) return Unauthorized("Email not associated with any account.");
            if(!foundUser.Enabled) return Unauthorized("Account not activated");
            var hashedPassword = Utilities.GeneratePasswordHash(login.Password, foundUser?.Nacl);

            if (!hashedPassword.SequenceEqual(foundUser.PasswordHash)) return Unauthorized("Wrong Password");
            else
            {
                //foundUser.LastLoginDate = DateTime.UtcNow;
                //_context.Update(foundUser);
                //await _context.SaveChangesAsync();
                //login user
                //generate jwt
                var token = await GenerateJwtToken(foundUser);
                return Ok(new { Token = token});
            }

        }


        private async Task<string> GenerateJwtToken(MbqAppUser user)
        {
            // generate token that is valid for 2 hrz
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var authClaims = new List<Claim> {
                    new Claim("id", user.Id.ToString()),
                    new Claim(ClaimTypes.Name, $"{user?.Forename} {user?.Surname}"),
                    new Claim(ClaimTypes.Email, user?.Email)
                };
            var userRoles = await _context.MbqAppUserRoles.Include(r => r.Role).Where(x => x.UserId == user.Id).ToListAsync();
            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole.Role.Role));
            }
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(authClaims),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
