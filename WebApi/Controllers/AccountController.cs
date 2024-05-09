using Core.ViewModels;
using Entity.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private UserManager<ApplicationUser> UserManager { get; set; }
        private SignInManager<ApplicationUser> SignInManager { get; set; }
        public AccountController(SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            IConfiguration configuration)
        {
            SignInManager = signInManager;
            UserManager = userManager;
            _configuration = configuration;
        }


        [HttpPost("Login")]
        public async Task<ResponseLoginJson> Login(LoginVM entity)
        {
            var result = await SignInManager.PasswordSignInAsync(entity.UserName, entity.Password, false, false);

            if (result.Succeeded)
            {
                var user = await UserManager.FindByNameAsync(entity.UserName);
                var roles = await UserManager.GetRolesAsync(user);

                var token = GenerateJwtToken(user.Id, roles);

                return new ResponseLoginJson
                {
                    Code = 200,
                    Message = "OK",
                    Success = true,
                    Token = token
                };
            }
            else
            {
                return new ResponseLoginJson
                {
                    Code = 401,
                    Message = "UserName or Password Not Correct!",
                    Success = false
                };
            }
        }

        [HttpPost("RegisterUser")]
        public async Task<ResponseLoginJson> RegisterUser(RegisterVM entity)
        {
            var newUser = new ApplicationUser
            {
                Email = entity.Email,
                UserName = entity.UserName,
            };

            var result = await UserManager.CreateAsync(newUser, entity.Password);

            if (result.Succeeded)
            {
                await UserManager.AddToRoleAsync(newUser, "User");
                var user = await UserManager.FindByNameAsync(entity.UserName);
                var roles = await UserManager.GetRolesAsync(user);

                var token = GenerateJwtToken(user.Id, roles);

                return new ResponseLoginJson
                {
                    Code = 200,
                    Message = "OK",
                    Success = true,
                    Token = token
                };
            }
            else
            {
                return new ResponseLoginJson
                {
                    Code = 401,
                    Message = string.Join("; ", result.Errors.Select(e => e.Description)),
                    Success = false
                };
            }
        }



        private string GenerateJwtToken(int userId, IList<string> roles)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
    {
        new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }



    }
}
