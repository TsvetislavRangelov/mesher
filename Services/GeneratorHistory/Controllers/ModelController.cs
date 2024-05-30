using Microsoft.AspNetCore.Mvc;
using Models;

namespace GeneratorHistory.Controllers;

/// <summary>
/// HTTP Endpoint for generating geometric vectors or matrices.
/// </summary>
[ApiController]
[Route("api/[controller]/[action]")]
public class ModelController : ControllerBase
{
    /// <summary>
    /// Endpoint for getting models from history for user.
    /// </summary>
    /// <returns><see cref="IActionResult"/>.</returns>
    [HttpGet]
    public IActionResult GetModel()
    {
        return Ok();
    }
    
    /// <summary>
    /// Endpoint for saving models in history for user.
    /// </summary>
    /// <returns><see cref="IActionResult"/>.</returns>
    [HttpPost]
    public IActionResult SaveModel([FromBody] GeometryModelDto model)
    {
        Console.WriteLine(model);
        
        return Created();
    }
}
