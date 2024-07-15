using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/province")]
public class ProvinceController(IProvinceService service) : ControllerBase
{
    [HttpGet]
    public Task<IActionResult> Get(int countryId)
    {
        return service.Get(countryId, HttpContext.RequestAborted);
    }
}