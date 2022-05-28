using mbanq.API.Data;
using mbanq.API.Dtos;
using mbanq.API.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mbanq.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly MBANQContext _context;

        public AuthController(MBANQContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginDto login)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var foundUser = await _context.MbqAppUsers.Where(x => x.Email == login.Email).FirstOrDefaultAsync();
            if (foundUser == null) return Unauthorized("Email not associated with any account.");
            var hashedPassword = Utilities.GeneratePasswordHash(login.Password, foundUser?.Nacl);

            if (!hashedPassword.SequenceEqual(foundUser.PasswordHash)) return Unauthorized("Wrong Password");
            else
            {
                //foundUser.LastLoginDate = DateTime.UtcNow;
                //_context.Update(foundUser);
                //await _context.SaveChangesAsync();
                //login user
                //generate jwt
                //var token = await generateJwtToken(foundUser);
                return Ok();
            }

        }
    }
}
