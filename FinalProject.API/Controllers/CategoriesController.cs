using FinalProject.BL.DTOs;
using FinalProject.BL.Exceptions;
using FinalProject.BL.Services.Abstractions;
using FinalProject.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    readonly ICategoryService _service;

    public CategoriesController(ICategoryService service)
    {
        _service = service;
    }

    [Authorize(Roles = "Admin, User")]
    [HttpGet("{id}", Name = "GetCategoryById")]
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
    [HttpGet(Name = "GetAllCategories")]
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
    [HttpPost("Create", Name = "CreateCategory")]
    public async Task<IActionResult> CreateCategory(CategoryCreateDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            string username = (User.FindFirst("UserName") ?? throw new UserCredentialsCouldNotBeVerifiedException()).Value;

            Category category = await _service.CreateAsync(dto, username);
            await _service.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, category);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Something went wrong!" });
        }
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("Update", Name = "UpdateCategory")]
    public async Task<IActionResult> UpdateCategory(CategoryUpdateDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            string username = (User.FindFirst("UserName") ?? throw new UserCredentialsCouldNotBeVerifiedException()).Value;

            Category category = await _service.UpdateAsync(dto, username);
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
    [HttpPatch("Recover", Name = "RecoverCategory")]
    public async Task<IActionResult> RecoverCategory(int id)
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
    [HttpPatch("SoftDelete", Name = "SoftDeleteCategory")]
    public async Task<IActionResult> SoftDeleteCategory(int id)
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
    [HttpDelete("HardDelete", Name = "HardDeleteCategory")]
    public async Task<IActionResult> HardDeleteCategory(int id)
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
