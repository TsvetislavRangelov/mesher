using System.Numerics;
using GeometryGeneratorNonSampled.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GeometryGeneratorNonSampled.Controllers;

/// <summary>
/// HTTP Endpoint for generating geometric vectors or matrices.
/// </summary>
/// <param name="generator">The generator service.</param>
[ApiController]
[Route("api/[controller]/[action]")]
public class GeometryNonSampledController(IGeometryGeneratorNonSampled generator) : ControllerBase
{
    

    /// <summary>
    /// Endpoint for procedurally generating vertices.
    /// </summary>
    /// <returns><see cref="IActionResult"/>.</returns>
    [HttpGet]
    public IActionResult GenerateVertices()
    {
        return Ok(generator.GenerateVertices(null));
    }
}
