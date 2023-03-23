using domain.vehicleowner;
using Microsoft.AspNetCore.Mvc;

namespace web.endpoints.vehicleowner;

[ApiController]
public class GetVehicleOwnerController : ControllerBase
{
    private readonly VehicleOwnerRepository _repository;

    public GetVehicleOwnerController(VehicleOwnerRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    [Route("[controller]")]
    public async Task<VehicleOwner> Call(string id)
    {
        var vehicleOwner = await _repository.Get(id);
        if(vehicleOwner == null) throw new Exception("Vehicle With this Id not Found");
        return vehicleOwner;
    }
}
