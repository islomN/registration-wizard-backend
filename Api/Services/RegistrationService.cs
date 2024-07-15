using System.Net;
using Api.ActionResults;
using Api.DataAccess;
using Api.Extensions;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Api.Services;

internal sealed class RegistrationService(IUserDataAccess userDataAccess, IProvinceDataAccess provinceDataAccess)
    : IRegistrationService
{
    public async Task<IActionResult> Submit(RegistrationRequest request, CancellationToken cancellationToken)
    {
        var validResult = await IsValid(request, cancellationToken);
        if (!validResult.IsSuccess)
        {
            return new ErrorActionResult(validResult.Message!, HttpStatusCode.BadRequest);
        }

        var result = await userDataAccess.Save(ConvertRequestToModel(request), cancellationToken);

        if (!result.IsSuccess)
        {
            return new ErrorActionResult(result.Message!, (HttpStatusCode)result.Code);
        }

        return new SuccessActionResult(result.Payload!);
    }

    private async Task<Result> IsValid(RegistrationRequest model, CancellationToken cancellationToken)
    {
        if (model is null)
        {
            return new Result("Model not valid", Result.ErrorCode.BadRequest);
        }

        if (string.IsNullOrEmpty(model.Login))
        {
            return new Result("Login is required", Result.ErrorCode.BadRequest);
        }
        
        if (!model.Login.Trim().IsEmail())
        {
            return new Result("Login is not valid email", Result.ErrorCode.BadRequest);
        }

        var userResult = await userDataAccess.GetByLogin(model.Login.Trim(), cancellationToken);

        if (userResult.IsSuccess)
        {
            return new Result("Login already exists");
        }
        
        if (userResult.Code != Result.ErrorCode.NotFound)
        {
            return new Result(userResult.Message, userResult.Code);
        }
        
        if (string.IsNullOrEmpty(model.Password))
        {
            return new Result("Password is required", Result.ErrorCode.BadRequest);
        }

        if (!model.Password.IsValidPassword())
        {
            return new Result("Password is not valid", Result.ErrorCode.BadRequest);
        }

        var provinceResult = await provinceDataAccess.GetById(model.ProvinceId, cancellationToken);

        if (!provinceResult.IsSuccess)
        {
            return new Result(provinceResult.Message, provinceResult.Code);
        }
        
        return new Result();
    }

    private static RegistrationRequestModel ConvertRequestToModel(RegistrationRequest request)
    {
        return new RegistrationRequestModel(
            request.Login.Trim(),
            request.Password.ToPasswordHash(),
            request.ProvinceId);
    }
}