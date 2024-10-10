using EduHub_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace EduHub_Project.Controllers
{
    [Route("api/Auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private AppDbContext db;
        private IConfiguration config;
        public AuthenticationController(AppDbContext db, IConfiguration _config)
        {
            this.db = db;
            config = _config;
        }

        [HttpPost("register")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<dynamic>> Register(User user)
        {
            TryValidateModel(user);
            if (ModelState.IsValid)
            {
                await db.Users.AddAsync(user);
                await db.SaveChangesAsync();
                //await SendVerificationMailAsync(user);
                return Created("", new
                {
                    user.UserId,
                    user.UserName,
                    user.UserRole,
                    user.Email
                });
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPost]
        [Route("Login")]
        public ActionResult<dynamic> Login(LoginModel model)
        {
            TryValidateModel(model);
            if (ModelState.IsValid)
            {
                var user = db.Users.SingleOrDefault(s => s.Email == model.Email && s.Password == model.Password);

                if (user != null)
                {
                    var token = GenerateToken(user);
                    return Ok(new {user.UserId, user.UserName, user.Email, user.MobileNumber, user.UserRole,user.ProfileImage, Token = token });
                }
                else
                {
                    return Unauthorized();// status code 403
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [NonAction]
        private string GenerateToken(User user)
        {
            //This is a claims list that defined who are the subject, what is to be checked and 
            //who are the audience for the claim

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role,user.UserRole),
                  };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetValue<string>("Jwt:secret")));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: config.GetValue<string>("Jwt:issuer"),
                audience: config.GetValue<string>("Jwt:audience"),
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );
            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString;
        }

    }
}
