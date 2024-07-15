using Microsoft.AspNetCore.Mvc;

namespace Api.Services;

public interface ICountryService
{
    Task<IActionResult> Get(CancellationToken cancellationToken);
}