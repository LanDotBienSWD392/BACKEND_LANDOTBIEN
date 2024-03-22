using System.Net;

namespace LanVar.DTO.DTO.response;

public class ApiResponse<TEntity>
{
    public TEntity Data { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public string Message { get; set; }

    public ApiResponse(TEntity data, HttpStatusCode statusCode, string message)
    {
        Data = data;
        StatusCode = statusCode;
        Message = message;
    }

    public ApiResponse(string message)
    {
        Message = message;
    }
    public ApiResponse(HttpStatusCode statusCode, string message)
    {
        
        StatusCode = statusCode;
        Message = message;
    }
    public ApiResponse(TEntity data, HttpStatusCode statusCode)
    {
        Data = data;
        StatusCode = statusCode;
       
    }

    
}