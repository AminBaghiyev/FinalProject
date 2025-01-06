using FinalProject.BL.DTOs;
using FinalProject.BL.Exceptions;
using FinalProject.BL.Services.Abstractions;
using FinalProject.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        _service = service;
    }

    [Authorize(Roles = "Admin, User")]
    [HttpGet("{id}", Name = "GetProductById")]
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
    [HttpGet(Name = "GetAllProducts")]
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
    [HttpPost("Create", Name = "CreateProduct")]
    public async Task<IActionResult> CreateProduct(ProductCreateDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            string username = (User.FindFirst("UserName") ?? throw new UserCredentialsCouldNotBeVerifiedException()).Value;

            Product category = await _service.CreateAsync(dto, username);
            await _service.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, category);
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
    [HttpPut("Update", Name = "UpdateProduct")]
    public async Task<IActionResult> UpdateProduct(ProductUpdateDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            string username = (User.FindFirst("UserName") ?? throw new UserCredentialsCouldNotBeVerifiedException()).Value;

            Product category = await _service.UpdateAsync(dto, username);
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
    [HttpPatch("Recover", Name = "RecoverProduct")]
    public async Task<IActionResult> RecoverProduct(int id)
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
    [HttpPatch("SoftDelete", Name = "SoftDeleteProduct")]
    public async Task<IActionResult> SoftDeleteProduct(int id)
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
    [HttpDelete("HardDelete", Name = "HardDeleteProduct")]
    public async Task<IActionResult> HardDeleteProduct(int id)
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
