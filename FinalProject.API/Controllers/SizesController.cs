using FinalProject.BL.DTOs;
using FinalProject.BL.Exceptions;
using FinalProject.BL.Services.Abstractions;
using FinalProject.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class SizesController : ControllerBase
{
    readonly ISizeService _service;

    public SizesController(ISizeService service)
    {
        _service = service;
    }

    [Authorize(Roles = "Admin, User")]
    [HttpGet("{id}", Name = "GetSizeById")]
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
    [HttpGet(Name = "GetAllSizes")]
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
    [HttpPost("Create", Name = "CreateSize")]
    public async Task<IActionResult> CreateSize(SizeCreateDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            string username = (User.FindFirst("UserName") ?? throw new UserCredentialsCouldNotBeVerifiedException()).Value;

            Size category = await _service.CreateAsync(dto, username);
            await _service.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, category);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Something went wrong!" });
        }
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("Update", Name = "UpdateSize")]
    public async Task<IActionResult> UpdateSize(SizeUpdateDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            string username = (User.FindFirst("UserName") ?? throw new UserCredentialsCouldNotBeVerifiedException()).Value;

            Size category = await _service.UpdateAsync(dto, username);
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
    [HttpPatch("Recover", Name = "RecoverSize")]
    public async Task<IActionResult> RecoverSize(int id)
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
    [HttpPatch("SoftDelete", Name = "SoftDeleteSize")]
    public async Task<IActionResult> SoftDeleteSize(int id)
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
    [HttpDelete("HardDelete", Name = "HardDeleteSize")]
    public async Task<IActionResult> HardDeleteSize(int id)
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
