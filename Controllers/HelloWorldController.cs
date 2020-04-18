using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HelloWorld.Controllers
{
    [ApiController]
    [Route(HELLO_ROUTE)]
    public class HelloWorldController : ControllerBase
    {
        private const string HELLO_ROUTE = "hello";
        private readonly ILogger<HelloWorldController> _logger;

        public HelloWorldController(ILogger<HelloWorldController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public HelloWorldMessage Get()
        {
            return new HelloWorldMessage();
        }
    }
}
