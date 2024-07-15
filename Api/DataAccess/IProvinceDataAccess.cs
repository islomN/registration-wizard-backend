using Models;

namespace Api.DataAccess;

public interface IProvinceDataAccess
{
    Task<Result<IEnumerable<ProvinceModel>>> Get(int countyId, CancellationToken cancellationToken);
    
    Task<Result<ProvinceModel>> GetById(int id, CancellationToken cancellationToken);
}