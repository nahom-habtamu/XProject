using domain.vehicle;
using domain.vehicle.usecases;
using Microsoft.AspNetCore.Mvc;

namespace web.endpoints.vehicle;

[ApiController]
public class GetAllVehiclesController : ControllerBase
{
    private readonly GetAllVehiclesInteractor _getAllVehicles;
    private readonly ILogger<GetAllVehiclesController> _logger;

    public GetAllVehiclesController(
        ILogger<GetAllVehiclesController> logger,
        GetAllVehiclesInteractor getAllVehicles
    )
    {
        _logger = logger;
        _getAllVehicles = getAllVehicles;
    }

    [HttpGet]
    [Route("[controller]")]
    public async Task<List<Vehicle>> Call()
    {
        return await _getAllVehicles.Call();
    }
}
