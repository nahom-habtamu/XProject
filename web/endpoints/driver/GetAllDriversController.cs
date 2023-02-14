using domain.driver;
using domain.driver.usecases;
using Microsoft.AspNetCore.Mvc;

namespace web.endpoints.driver;

[ApiController]
public class GetDriverController : ControllerBase
{
    private readonly GetAllDriversInteractor _getAllDrivers;
    private readonly ILogger<GetDriverController> _logger;

    public GetDriverController(
        ILogger<GetDriverController> logger,
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
