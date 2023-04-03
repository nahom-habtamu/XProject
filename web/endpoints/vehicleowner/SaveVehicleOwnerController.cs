using domain.vehicleowner;
using dtos.vehicleowner;
using Microsoft.AspNetCore.Mvc;

namespace web.endpoints.vehicleowner;

[ApiController]
public class SaveVehicleOwnerController : ControllerBase
{
    private readonly VehicleOwnerRepository _repository;

    public SaveVehicleOwnerController(
        VehicleOwnerRepository repository
    )
    {
        _repository = repository;
    }

    [HttpPost]
    [Route("[controller]")]
    public async Task<string> Call(SaveVehicleOwnerRequestDto requestDto)
    {
        var vehicleOwner = VehicleOwner.buildFromDto(requestDto);
        await _repository.Save(vehicleOwner);
        return vehicleOwner.Id;
    }
}
