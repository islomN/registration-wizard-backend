using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Models;

namespace Api.DataAccess;

internal sealed class CountryDataAccess(IOptions<EntityContextOptions> options) : ICountryDataAccess
{
    public async Task<Result<IEnumerable<CountryModel>>> Get(
        CancellationToken cancellationToken)
    {
        await using var context = new EntityContext(options);

        try
        {
            var items = await context.Countries
                .Select(i => new CountryModel(i.ID, i.Name))
                .AsNoTracking()
                .ToListAsync(cancellationToken: cancellationToken);
            
            return new Result<IEnumerable<CountryModel>>(items);
        }
        catch
        {
            return new Result<IEnumerable<CountryModel>>("Service unavailable, please try later");
        }
    }
}