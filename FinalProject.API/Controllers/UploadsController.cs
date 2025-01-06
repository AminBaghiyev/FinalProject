using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace FinalProject.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class UploadsController : ControllerBase
{
    [HttpGet("uploads/{*paths}")]
    public IActionResult GetFile(string paths)
    {
        string[] splittedPaths = paths.Split('/');
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", Path.Combine(splittedPaths));

        if (System.IO.File.Exists(filePath))
        {
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(filePath, out string contentType))
                contentType = "application/octet-stream";
            
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, contentType);
        }

        return NotFound();
    }
}
