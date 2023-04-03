using domain.vehicleowner;
using dtos.vehicleowner;
using Microsoft.AspNetCore.Mvc;

namespace web.endpoints.vehicleowner;

[ApiController]
public class SaveVehicleOwnerController : ControllerBase
{
    private readonly VehicleOwnerRepository _repository;
    private readonly ILogger<SaveVehicleOwnerController> _logger;

    public SaveVehicleOwnerController(
        ILogger<SaveVehicleOwnerController> logger,
        VehicleOwnerRepository repository
    )
    {
        _logger = logger;
        _repository = repository;
    }

    [HttpPost]
    [Route("[controller]")]
    public async Task<VehicleOwner> Call(SaveVehicleOwnerRequest requestDto)
    {
        var vehicleOwner = VehicleOwner.buildFromDto(requestDto);
        await _repository.Save(vehicleOwner);
        return vehicleOwner;
    }
}
