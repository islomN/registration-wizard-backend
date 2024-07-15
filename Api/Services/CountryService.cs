using Api.ActionResults;
using Api.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace Api.Services;

internal sealed class CountryService(ICountryDataAccess dataAccess)
    : ICountryService
{
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var result = await dataAccess.Get(cancellationToken);
        
        if (!result.IsSuccess)
        {
            return new ErrorActionResult(result.Message!);
        }
        
        return new SuccessActionResult(result.Payload!); 
    }
}