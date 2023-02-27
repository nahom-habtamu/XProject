using domain.vehicleowner;
using domain.vehicleowner.usecases;
using dtos.vehicleowner;
using Microsoft.AspNetCore.Mvc;

namespace web.endpoints.vehicleowner;

[ApiController]
public class CreateVehicleOwnerController : ControllerBase
{
    private readonly CreateVehicleOwnerInteractor _interactor;
    private readonly ILogger<CreateVehicleOwnerController> _logger;

    public CreateVehicleOwnerController(
        ILogger<CreateVehicleOwnerController> logger,
        CreateVehicleOwnerInteractor interactor
    )
    {
        _logger = logger;
        _interactor = interactor;
    }

    [HttpPost]
    [Route("[controller]")]
    public async Task<VehicleOwner> Call(CreateVehicleOwnerRequest requestDto)
    {
        return await _interactor.Call(requestDto);
    }
}
