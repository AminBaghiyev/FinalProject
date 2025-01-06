using FinalProject.BL.DTOs;
using FinalProject.BL.Exceptions;
using FinalProject.BL.Services.Abstractions;
using FinalProject.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class ColorsController : ControllerBase
{
    readonly IColorService _service;

    public ColorsController(IColorService service)
    {
        _service = service;
    }

    [Authorize(Roles = "Admin, User")]
    [HttpGet("{id}", Name = "GetColorById")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            return Ok(await _service.GetByIdAsync(id));
        }
        catch (EntityNotFoundException ex)
        {
            return StatusCode(StatusCodes.Status404NotFound, new { message = ex.Message });
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Something went wrong!" });
        }
    }

    [Authorize(Roles = "Admin, User")]
    [HttpGet(Name = "GetAllColors")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            return Ok(await _service.GetAllAsync());
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Something went wrong!" });
        }
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("Create", Name = "CreateColor")]
    public async Task<IActionResult> CreateColor(ColorCreateDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            string username = (User.FindFirst("UserName") ?? throw new UserCredentialsCouldNotBeVerifiedException()).Value;

            Color category = await _service.CreateAsync(dto, username);
            await _service.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, category);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Something went wrong!" });
        }
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("Update", Name = "UpdateColor")]
    public async Task<IActionResult> UpdateColor(ColorUpdateDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            string username = (User.FindFirst("UserName") ?? throw new UserCredentialsCouldNotBeVerifiedException()).Value;

            Color category = await _service.UpdateAsync(dto, username);
            await _service.SaveChangesAsync();
            return Ok(category);
        }
        catch (EntityNotFoundException ex)
        {
            return StatusCode(StatusCodes.Status404NotFound, new { message = ex.Message });
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Something went wrong!" });
        }
    }

    [Authorize(Roles = "Admin")]
    [HttpPatch("Recover", Name = "RecoverColor")]
    public async Task<IActionResult> RecoverColor(int id)
    {
        try
        {
            await _service.RecoverAsync(id);
            await _service.SaveChangesAsync();
            return Ok();
        }
        catch (EntityNotFoundException ex)
        {
            return StatusCode(StatusCodes.Status404NotFound, new { message = ex.Message });
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Something went wrong!" });
        }
    }

    [Authorize(Roles = "Admin")]
    [HttpPatch("SoftDelete", Name = "SoftDeleteColor")]
    public async Task<IActionResult> SoftDeleteColor(int id)
    {
        try
        {
            string username = (User.FindFirst("UserName") ?? throw new UserCredentialsCouldNotBeVerifiedException()).Value;

            await _service.SoftDeleteAsync(id, username);
            await _service.SaveChangesAsync();
            return Ok();
        }
        catch (EntityNotFoundException ex)
        {
            return StatusCode(StatusCodes.Status404NotFound, new { message = ex.Message });
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Something went wrong!" });
        }
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("HardDelete", Name = "HardDeleteColor")]
    public async Task<IActionResult> HardDeleteColor(int id)
    {
        try
        {
            await _service.HardDeleteAsync(id);
            await _service.SaveChangesAsync();
            return Ok();
        }
        catch (EntityNotFoundException ex)
        {
            return StatusCode(StatusCodes.Status404NotFound, new { message = ex.Message });
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Something went wrong!" });
        }
    }
}
