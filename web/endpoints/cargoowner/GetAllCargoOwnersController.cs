using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace web.endpoints.cargoowners;

[ApiController]
[Route("[controller]")]
public class GetAllCargoOwnersController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<GetAllCargoOwnersController> _logger;

    public GetAllCargoOwnersController(ILogger<GetAllCargoOwnersController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetCargoOwners")]
    public IEnumerable<string> Get()
    {
        return Summaries.ToList();
    }
}
