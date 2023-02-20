using domain.vehicleowner;
using domain.vehicleowner.usecases;
using Microsoft.AspNetCore.Mvc;

namespace web.endpoints.vehicleowner;

[ApiController]
public class GetAllVehicleOwnersController : ControllerBase
{
    private readonly GetAllVehicleOwnersInteractor _getAllVehicleOwners;
    private readonly ILogger<GetAllVehicleOwnersController> _logger;

    public GetAllVehicleOwnersController(
        ILogger<GetAllVehicleOwnersController> logger,
        GetAllVehicleOwnersInteractor getAllVehicleOwners
    )
    {
        _logger = logger;
        _getAllVehicleOwners = getAllVehicleOwners;
    }

    [HttpGet]
    [Route("[controller]")]
    public async Task<List<VehicleOwner>> Call()
    {
        return await _getAllVehicleOwners.Call();
    }
}
