using CarTech.Domain.Models.Identity;
using CarTech.VewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CarTech.Registration.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AuthController(IConfiguration config, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _config = config;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginViewModel model)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(model.UserName);

                if (user != null && !string.IsNullOrEmpty(user.Id))
                {
                    var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

                    if (result.Succeeded)
                    {
                        var appUser = await _userManager.Users.FirstOrDefaultAsync(o => o.NormalizedUserName == model.UserName.ToUpper());

                        return Ok(new
                        {
                            token = GenerateJsonWebToken(appUser)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }

            return Unauthorized();
        }

        private async Task<string> GenerateJsonWebToken(IdentityUser appUser)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, appUser.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, appUser.UserName));

            var roles = await _userManager.GetRolesAsync(appUser);

            foreach (var item in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, item));
            }

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config.GetSection("AppSettings:JwToken").Value));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor();
            tokenDescriptor.Subject = new ClaimsIdentity(claims);
            tokenDescriptor.Expires = DateTime.Now.AddDays(1);
            tokenDescriptor.SigningCredentials = credential;

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
