using Microsoft.AspNetCore.Mvc;
using NewChatApp.Shared.Common;

namespace NewChatApp.WebApi.Controllers;

public abstract class WebApiController : ControllerBase
{
    protected IActionResult OkResponse<T>(Result<T> result, double elapsed) where T : class
    {
        return result.IsSuccess
            ? Ok(new WebApiResponseItem<T>(result.Value, elapsed, StatusCodes.Status200OK))
            : BadRequest(new WebApiErrorItem(result.Error, elapsed, StatusCodes.Status400BadRequest));
    }
    
    protected IActionResult CreatedResponse<T>(Result<T> result, string path, double elapsed) where T : class
    {
        return result.IsSuccess
            ? CreatedAtAction(path, new { }, new WebApiResponseItem<T>(result.Value, elapsed, StatusCodes.Status200OK))
            : BadRequest(new WebApiErrorItem(result.Error, elapsed, StatusCodes.Status400BadRequest));
    }
}