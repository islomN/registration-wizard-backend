using Models;

namespace Api.DataAccess;

public interface IUserDataAccess
{
    Task<Result<EntityModel>> GetByLogin(string login, CancellationToken cancellationToken);

    Task<Result<EntityModel>> Save(RegistrationRequestModel model, CancellationToken cancellationToken);
}