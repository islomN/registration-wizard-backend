using Microsoft.AspNetCore.Mvc;
using Models;

namespace Api.Services;

public interface IRegistrationService
{
    Task<IActionResult> Submit(RegistrationRequest request, CancellationToken cancellationToken);
}