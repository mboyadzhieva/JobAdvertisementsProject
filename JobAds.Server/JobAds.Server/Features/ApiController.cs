namespace JobAds.Server.Features
{
    using Microsoft.AspNetCore.Mvc;

    // The [ApiController] attribute can be applied to enable API-specific behaviors
    // https://docs.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-5.0#apicontroller-attribute
    [ApiController]
    [Route("[controller]")]

    // Extend Controller when using Views (handling web pages)
    // ControllerBase is used when you're handling API requests
    // https://docs.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-5.0#controllerbase-class
    public abstract class ApiController : ControllerBase
    {
    }
}
