using Api.Services;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Api.Controllers;

[Route("api/registration")]
public class RegistrationController(IRegistrationService registrationService) : ControllerBase
{
    [HttpPost]
    public Task<IActionResult> Submit([FromBody] RegistrationRequest model)
    {
        return registrationService.Submit(model, HttpContext.RequestAborted);
    }
}