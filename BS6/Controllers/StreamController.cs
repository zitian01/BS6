using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BS6.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowAllOrigins")]
    public class StreamController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateStream([FromBody] string streamName)
        {
            string filePath = $"wwwroot/{streamName}.html";

            if (System.IO.File.Exists(filePath))
            {
                return BadRequest("Stream name already exists");
            }

            // Generate your HTML content here. Simplified for this example.
            string htmlContent = $"<html><body>Stream: {streamName}</body></html>";

            System.IO.File.WriteAllText(filePath, htmlContent);

            return Ok($"New stream created at {filePath}");
        }
    }
}
