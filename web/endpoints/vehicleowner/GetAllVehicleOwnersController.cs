using domain.vehicleowner;
using Microsoft.AspNetCore.Mvc;

namespace web.endpoints.vehicleowner;

[ApiController]
public class GetAllVehicleOwnersController : ControllerBase
{
    private readonly VehicleOwnerRepository _repository;
    private readonly ILogger<GetAllVehicleOwnersController> _logger;

    public GetAllVehicleOwnersController(
        ILogger<GetAllVehicleOwnersController> logger,
        VehicleOwnerRepository repository
    )
    {
        _logger = logger;
        _repository = repository;
    }

    [HttpGet]
    [Route("[controller]")]
    public async Task<List<VehicleOwner>> Call()
    {
        return await _repository.GetAllVehicleOwners();
    }
}
