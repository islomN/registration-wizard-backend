using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/country")]
public class CountryController(ICountryService service) : ControllerBase
{
    [HttpGet]
    public Task<IActionResult> Get()
    {
        return service.Get(HttpContext.RequestAborted);
    }
}