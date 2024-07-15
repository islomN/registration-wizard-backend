namespace Models;

public class Result
{
    public bool IsSuccess { get; }

    public string? Message { get; }

    public ErrorCode Code { get; }

    public Result()
    {
        IsSuccess = true;
    }

    public Result(string? message = null, ErrorCode code = ErrorCode.InternalServer)
    {
        IsSuccess = false;
        Message = message;
        Code = code;
    }   
    
    public enum ErrorCode
    {
        BadRequest = 400,
        NotFound = 404,
        InternalServer = 500,
    }
}

public class Result<T> : Result
{
    public T? Payload { get; }

    public Result(T? payload)
    {
        Payload = payload;
    }

    public Result(string message, ErrorCode code = ErrorCode.InternalServer) : base(message, code)
    {
        
    }
}



