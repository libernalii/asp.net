using NewChatApp.Shared.Common;
using Newtonsoft.Json;

namespace NewChatApp.WebApi;

public abstract class WebApiResponseBase
{
    protected WebApiResponseBase(double elapsedTime, int statusCode)
    {
        ElapsedTime = elapsedTime;
        StatusCode = statusCode;
    }


    [JsonProperty("elapsed_time")]
    public double ElapsedTime { get; set; }
    
    [JsonProperty("status_code")]
    public int StatusCode { get; set; }
}

public class WebApiResponseItem<T> : WebApiResponseBase where T : class 
{
    public WebApiResponseItem(T? response, double elapsedTime, int statusCode) : base(elapsedTime, statusCode)
    {
        Response = response;
    }

    [JsonProperty("response")]
    public T? Response { get; set; }
}

public class WebApiErrorItem : WebApiResponseBase
{
    public WebApiErrorItem(Error? error, double elapsedTime, int statusCode) : base(elapsedTime, statusCode)
    {
        Error = error;
    }

    [JsonProperty("error")]
    public Error? Error { get; set; }
}