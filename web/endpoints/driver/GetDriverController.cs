using domain.driver;
using domain.exceptions;
using Microsoft.AspNetCore.Mvc;

namespace web.endpoints.driver;

[ApiController]
public class GetDriverController : ControllerBase
{
    private readonly DriverRepository _repository;

    public GetDriverController(DriverRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    [Route("[controller]")]
    public async Task<Driver?> Call(string id)
    {
        var driver = await _repository.Get(id);
        if (driver == null) throw new NoDataFoundWithThisIdException("Driver", id);
        return driver;
    }
}
