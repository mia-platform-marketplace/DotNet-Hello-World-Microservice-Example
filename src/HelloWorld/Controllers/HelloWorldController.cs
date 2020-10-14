using MiaServiceDotNetLibrary;
using MiaServiceDotNetLibrary.Decorators;
using MiaServiceDotNetLibrary.Environment;
using MiaServiceDotNetLibrary.Logging;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore_Hello_World_Microservice_Example.Controllers
{
    [ApiController]
    [Route("/")]
    public class HelloWorldController : ServiceStatusController
    {
        public HelloWorldController(MiaEnvConfiguration miaEnvConfiguration, ServiceClientFactory serviceClientFactory,
            DecoratorResponseFactory decoratorResponseFactory) : base(miaEnvConfiguration, serviceClientFactory,
            decoratorResponseFactory)
        {
        }

        [HttpGet]
        public string Get()
        {
            Logger.Info(HttpContext.Request, "starting hello api");
            var miaHeadersPropagator = (MiaHeadersPropagator) HttpContext.Items["MiaHeadersPropagator"];
            return $"Hello {miaHeadersPropagator.GetUserId()}";
        }
    }
}
