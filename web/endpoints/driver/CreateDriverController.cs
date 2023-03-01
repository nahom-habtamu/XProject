using domain.driver;
using dtos.driver;
using Microsoft.AspNetCore.Mvc;

namespace web.endpoints.driver;

[ApiController]
public class CreateDriverController : ControllerBase
{
    private readonly ILogger<CreateDriverController> _logger;
    private readonly DriverRepository _repository;

    public CreateDriverController(
        ILogger<CreateDriverController> logger,
        DriverRepository repository
    )
    {
        _logger = logger;
        _repository = repository;
    }

    [HttpPost]
    [Route("[controller]")]
    public async Task<Driver> Call([FromBody] CreateDriverRequestDto requestDto)
    {
        var driver = Driver.parseFromDto(requestDto);
        await _repository.Save(driver);
        return driver;
    }
}