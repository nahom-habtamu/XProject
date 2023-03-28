using domain.vehicle;
using Microsoft.AspNetCore.Mvc;

namespace web.endpoints.vehicle;

[ApiController]
public class GetPlateNumbersController : ControllerBase
{
    private readonly VehicleRepository _repository;

    public GetPlateNumbersController(
        VehicleRepository repository
    )
    {
        _repository = repository;
    }

    [HttpGet]
    [Route("[controller]")]
    public async Task<List<string>> Call()
    {
        return await _repository.GetAllPlateNumbers();
    }
}
