using domain.driver;
using dtos.driver;
using Microsoft.AspNetCore.Mvc;

namespace web.endpoints.driver;

[ApiController]
public class CreateDriverController : ControllerBase
{
    private readonly DriverRepository _repository;

    public CreateDriverController(
        DriverRepository repository
    )
    {
        _repository = repository;
    }

    [HttpPost]
    [Route("[controller]")]
    public async Task<string> Call([FromBody] CreateDriverRequestDto requestDto)
    {
        var driver = Driver.parseFromDto(requestDto);
        await _repository.Save(driver);
        return driver.Id;
    }
}