using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using SystemSchool.Server.DTO.Account;
using SystemSchool.Server.Interfaces;
using SystemSchool.Server.Models;

namespace SystemSchool.Server.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly UserManager<Users> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<Users> _singningManager;
        private readonly object? e;

        public AccountController(UserManager<Users> userManager, ITokenService tokenService, SignInManager<Users> signInManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult>Login(LoginDto loginDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());
            if (user == null) return Unauthorized("Invalid username!");
            var result = await _singningManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded) return Unauthorized("Username nor found or password incorrect");

            return Ok(
                new NewUserDto
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    Token = _tokenService.CreateToken(user)
                }
                );
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                
                    return BadRequest(ModelState);

                var Users = new Users
                {
                    UserName = registerDto.Username, 
                    Email = registerDto.Email
                };

                var createUser = await _userManager.CreateAsync(Users, registerDto.Password);
                
                if(createUser.Succeeded)
                {
                    var rolesResult = await _userManager.AddToRolesAsync(Users,new[] { "Users" });
                    if (rolesResult.Succeeded)
                    {
                        return Ok(
                            new NewUserDto
                            {
                                UserName= Users.Username,
                                Email = Users.Email,
                                Token = _tokenService.CreateToken(Users)
                            }
                            );
                    }
                    else 
                    {
                        return StatusCode(500, rolesResult.Errors);
                    }
                }
                else 
                {
                    return StatusCode(500, createUser.Errors);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }


        }

    }
    }

