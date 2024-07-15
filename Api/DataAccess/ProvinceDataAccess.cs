using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Models;

namespace Api.DataAccess;

internal sealed class ProvinceDataAccess(IOptions<EntityContextOptions> options) : IProvinceDataAccess
{
    public async Task<Result<IEnumerable<ProvinceModel>>> Get(int countyID, CancellationToken cancellationToken)
    {
        await using var context = new EntityContext(options);

        try
        {
            var items = await context.Provinces
                .Where(i => i.CountryID == countyID)
                .Select(i => new ProvinceModel(i.ID, i.Name))
                .AsNoTracking()
                .ToListAsync(cancellationToken: cancellationToken);
            
            return new Result<IEnumerable<ProvinceModel>>(items);
        }
        catch
        {
            return new Result<IEnumerable<ProvinceModel>>("Service unavailable, please try later");
        }
    }

    public async Task<Result<ProvinceModel>> GetById(int id, CancellationToken cancellationToken)
    {
        await using var context = new EntityContext(options);
        try
        {
            var item = await context.Provinces
                .FirstOrDefaultAsync(i => i.ID == id, cancellationToken: cancellationToken);

            if (item is null)
            {
                return new Result<ProvinceModel>("Province not found", Result.ErrorCode.NotFound);
            }

            return new Result<ProvinceModel>(new ProvinceModel(item.ID, item.Name));
        }
        catch (Exception)
        {
            return new Result<ProvinceModel>("Service unavailable, please try later");
        }
    }
}