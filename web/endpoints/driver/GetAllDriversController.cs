using domain.driver;
using Microsoft.AspNetCore.Mvc;

namespace web.endpoints.driver;

[ApiController]
public class GetAllDriversController : ControllerBase
{
    private readonly DriverRepository _repository;
    private readonly ILogger<GetAllDriversController> _logger;

    public GetAllDriversController(
        ILogger<GetAllDriversController> logger,
        DriverRepository repository
    )
    {
        _logger = logger;
        _repository = repository;
    }

    [HttpGet]
    [Route("[controller]")]
    public async Task<List<Driver>> Call()
    {
        return await _repository.GetAllDrivers();
    }
}
