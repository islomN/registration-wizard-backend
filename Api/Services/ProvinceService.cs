using Api.ActionResults;
using Api.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace Api.Services;

internal sealed class ProvinceService(IProvinceDataAccess dataAccess)
    : IProvinceService
{
    public async Task<IActionResult> Get(int countryID, CancellationToken cancellationToken)
    {
        var result = await dataAccess.Get(countryID, cancellationToken);
        
        if (!result.IsSuccess)
        {
            return new ErrorActionResult(result.Message!);
        }
        
        return new SuccessActionResult(result.Payload!); 
    }
}