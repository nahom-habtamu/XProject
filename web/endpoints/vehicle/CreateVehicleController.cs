using domain.vehicle;
using domain.vehicle.usecases;
using dtos.vehicle;
using Microsoft.AspNetCore.Mvc;

namespace web.endpoints.vehicle;

[ApiController]
public class CreateVehicleController : ControllerBase
{
    private readonly CreateVehicleInteractor _createVehicleRepo;
    private readonly ILogger<CreateVehicleController> _logger;

    public CreateVehicleController(ILogger<CreateVehicleController> logger, CreateVehicleInteractor createVehicle)
    {
        _logger = logger;
        _createVehicleRepo = createVehicle;
    }

    [HttpPost]
    [Route("[controller]")]
    public async Task<Vehicle> Call([FromForm] CreateVehicleRequestDto requestDto)
    {
        return await _createVehicleRepo.Call(requestDto);
    }
}
