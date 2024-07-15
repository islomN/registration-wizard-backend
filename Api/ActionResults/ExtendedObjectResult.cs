using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Api.ActionResults;

internal class ExtendedObjectResult: ObjectResult
{
    protected ExtendedObjectResult(object value, HttpStatusCode statusCode):base(value)
    {
        StatusCode = (int)statusCode;
    }
}