using DotnetPlayground.WebApi.Utilities.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SharedPocos.DTOs;
using SharedPocos.Models;

namespace DotnetPlayground.WebApi.Controllers;

[Route("api/v1/[controller]/[action]")]
[ApiController]
public class IdentityAuthenticationController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IJWTGenerator _jwtGenerator;

    public IdentityAuthenticationController(UserManager<IdentityUser> userManager, IJWTGenerator jwtGenerator)
    {
        _userManager = userManager;
        _jwtGenerator = jwtGenerator;
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] UserRegistrationRequestDto requestDto)
    {
        var userExists = await _userManager.FindByEmailAsync(requestDto.Email);
        if (userExists != null)
        {
            return BadRequest(new AuthResult()
            {
                Result = false,
                Errors = new List<string>()
                {
                    "Email already exists"
                }
            });
        }

        var newUser = new IdentityUser()
        {
            UserName = requestDto.Email,
            Email = requestDto.Email
        };

        var isCreated = await _userManager.CreateAsync(newUser, requestDto.Password);

        if (!isCreated.Succeeded)
        {
            var errors = new List<string>();
            foreach (var idErr in isCreated.Errors)
            {
                errors.Add(idErr.Description);
            }
            return BadRequest(new AuthResult()
            {
                Result = false,
                Errors = errors
            });
        }

        var (jwtToken, refreshToken) = await _jwtGenerator.GenerateIdentityJwt(newUser);

        return Ok(new AuthResult()
        {
            Result = true,
            Token = jwtToken,
            RefreshToken = refreshToken
        });
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] UserLoginRequestDto requestDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new AuthResult()
            {
                Errors = new List<string>()
                {
                    "Invalid Payload"
                },
                Result = false
            });
        }

        var existingUser = await _userManager.FindByEmailAsync(requestDto.Email);
        if (existingUser is null)
        {
            return BadRequest(new AuthResult()
            {
                Errors = new List<string>()
                {
                    "Invalid Payload"
                },
                Result = false
            });
        }

        var isCorrect = await _userManager.CheckPasswordAsync(existingUser, requestDto.Password);
        if (!isCorrect)
        {
            return BadRequest(new AuthResult()
            {
                Errors = new List<string>()
                {
                    "Invalid credential"
                },
                Result = false
            });
        }

        var (jwtToken, refreshToken) = await _jwtGenerator.GenerateIdentityJwt(existingUser);

        return Ok(new AuthResult()
        {
            Token = jwtToken,
            RefreshToken = refreshToken,
            Result = true
        });
    }

    [HttpPost]
    public async Task<IActionResult> RefreshToken([FromBody] TokenRequest requestDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new AuthResult()
            {
                Errors = new List<string>()
                {
                    "Invalid Payload"
                },
                Result = false
            });
        }

        var (isValid, storedToken) = await _jwtGenerator.VerifyAndGenerateToken(requestDto);

        if (!isValid)
        {
            return BadRequest(new AuthResult()
            {
                Errors = new List<string>()
                {
                    "Invalid Token"
                },
                Result = false
            });
        }

        var existingUser = await _userManager.FindByIdAsync(storedToken.Token);

        var (jwtToken, refreshToken) = await _jwtGenerator.GenerateIdentityJwt(existingUser);

        return Ok(new AuthResult()
        {
            Token = jwtToken,
            RefreshToken = refreshToken,
            Result = true
        });
    }
}