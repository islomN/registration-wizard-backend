using Models;

namespace Api.DataAccess;

public interface ICountryDataAccess
{
    Task<Result<IEnumerable<CountryModel>>> Get(CancellationToken cancellationToken);
}