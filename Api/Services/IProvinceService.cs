using Microsoft.AspNetCore.Mvc;

namespace Api.Services;

public interface IProvinceService
{
    Task<IActionResult> Get(int countryID, CancellationToken cancellationToken);
}