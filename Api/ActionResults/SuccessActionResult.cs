﻿using System.Net;

namespace Api.ActionResults;

internal class SuccessActionResult: ExtendedObjectResult
{
    public SuccessActionResult(
        object value = null!,
        HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        : base(value, httpStatusCode)
    {
            
    }
        
    public SuccessActionResult(
        HttpStatusCode httpStatusCode = HttpStatusCode.NoContent)
        : base(null!, httpStatusCode)
    {
            
    }
        
    public SuccessActionResult() : base(null!,  HttpStatusCode.NoContent)
    {
            
    }
}