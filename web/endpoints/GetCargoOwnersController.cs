using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace web.endpoints;

[ApiController]
[Route("[controller]")]
public class GetCargoOwnersController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<GetCargoOwnersController> _logger;

    public GetCargoOwnersController(ILogger<GetCargoOwnersController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetCargoOwners")]
    public IEnumerable<string> Get()
    {
        return Summaries.ToList();
    }
}
