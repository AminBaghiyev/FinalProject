using FinalProject.BL.DTOs;
using FinalProject.BL.Exceptions;
using FinalProject.BL.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class AccountsController : ControllerBase
{
    readonly IAccountService _service;

    public AccountsController(IAccountService accountService)
    {
        _service = accountService;
    }

    [HttpGet("AllUsers")]
    public async Task<IActionResult> GetAllUsers()
    {
        try
        {
            return Ok(await _service.GetAllUsers());
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!");
        }
    }

    [HttpGet("UserByEmail")]
    public async Task<IActionResult> GetUserByEmail(string email)
    {
        try
        {
            return Ok(await _service.GetUserByEmailAsync(email));
        }
        catch (EntityNotFoundException ex)
        {
            return StatusCode(StatusCodes.Status404NotFound, new { message = ex.Message });
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!");
        }
    }

    [HttpGet("UserByUsername")]
    public async Task<IActionResult> GetUserByUsername(string username)
    {
        try
        {
            return Ok(await _service.GetUserByUsernameAsync(username));
        }
        catch (EntityNotFoundException ex)
        {
            return StatusCode(StatusCodes.Status404NotFound, new { message = ex.Message });
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!");
        }
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(AppUserRegisterDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await _service.RegisterAsync(dto);
            return StatusCode(StatusCodes.Status201Created);
        }
        catch (UserExistsException ex)
        {
            return StatusCode(StatusCodes.Status409Conflict, new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
        }
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(AppUserLoginDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            return StatusCode(StatusCodes.Status200OK, await _service.LoginAsync(dto));
        }
        catch (EntityNotFoundException ex)
        {
            return StatusCode(StatusCodes.Status404NotFound, new { message = ex.Message });
        }
        catch (UserCredentialsCouldNotBeVerifiedException ex)
        {
            return StatusCode(StatusCodes.Status400BadRequest, new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
        }
    }

    [HttpPatch("ChangePassword")]
    public async Task<IActionResult> ChangePassword(ChangePasswordDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await _service.ChangePasswordAsync(dto);
            return Ok();
        }
        catch (EntityNotFoundException ex)
        {
            return StatusCode(StatusCodes.Status404NotFound, new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
        }
    }
}
