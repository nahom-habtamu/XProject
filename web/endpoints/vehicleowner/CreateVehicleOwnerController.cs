using domain.vehicleowner;
using dtos.vehicleowner;
using Microsoft.AspNetCore.Mvc;

namespace web.endpoints.vehicleowner;

[ApiController]
public class CreateVehicleOwnerController : ControllerBase
{
    private readonly VehicleOwnerRepository _repository;
    private readonly ILogger<CreateVehicleOwnerController> _logger;

    public CreateVehicleOwnerController(
        ILogger<CreateVehicleOwnerController> logger,
        VehicleOwnerRepository repository
    )
    {
        _logger = logger;
        _repository = repository;
    }

    [HttpPost]
    [Route("[controller]")]
    public async Task<VehicleOwner> Call(CreateVehicleOwnerRequest requestDto)
    {
        var vehicleOwner = VehicleOwner.buildFromDto(requestDto);
        await _repository.Save(vehicleOwner);
        return vehicleOwner;
    }
}
