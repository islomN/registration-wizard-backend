using Database;
using Database.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Models;

namespace Api.DataAccess;

internal sealed class UserDataAccess(IOptions<EntityContextOptions> options)
    : IUserDataAccess
{
    public async Task<Result<EntityModel>> GetByLogin(string login, CancellationToken cancellationToken)
    {
        await using var context = new EntityContext(options);
        try
        {
            var user = await context.Users.FirstOrDefaultAsync(i => i.Login == login, cancellationToken);

            return user is null
                ? new Result<EntityModel>("User not found", Result.ErrorCode.NotFound)
                : new Result<EntityModel>(new EntityModel(user.ID));
        }
        catch
        {
            return new Result<EntityModel>("Service unavailable, please try later");
        }
    }

    public async Task<Result<EntityModel>> Save(
        RegistrationRequestModel model, CancellationToken cancellationToken)
    {
        await using var context = new EntityContext(options);

        try
        {
            var user = ConvertToUserModel(model);
            context.Users.Add(user);
            await context.SaveChangesAsync(cancellationToken);

            return new Result<EntityModel>(new EntityModel(user.ID));
        }
        catch
        {
            return new Result<EntityModel>("Service unavailable, please try later");
        }
    }

    private static User ConvertToUserModel(RegistrationRequestModel model)
    {
        return new User(default, model.Login, model.PasswordHash, model.ProvinceId);
    }
}