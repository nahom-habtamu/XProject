using domain.driver;
using domain.driver.usecases;
using Microsoft.AspNetCore.Mvc;

namespace web.endpoints.driver;

[ApiController]
public class GetAllDriversController : ControllerBase
{
    private readonly GetAllDriversInteractor _getAllDrivers;
    private readonly ILogger<GetAllDriversController> _logger;

    public GetAllDriversController(
        ILogger<GetAllDriversController> logger,
        GetAllDriversInteractor getAllDrivers
    )
    {
        _logger = logger;
        _getAllDrivers = getAllDrivers;
    }

    [HttpGet]
    [Route("[controller]")]
    public async Task<List<Driver>> Call()
    {
        return await _getAllDrivers.Call();
    }
}
