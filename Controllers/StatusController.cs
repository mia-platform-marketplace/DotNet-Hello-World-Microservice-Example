using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HelloWorld.Models;

namespace HelloWorld.Controllers
{
    [ApiController]
    [Route(STATUS_ROUTE)]
    public class StatusController : ControllerBase
    {
        private const string STATUS_ROUTE = "-";
        private readonly ILogger<StatusController> _logger;

        public StatusController(ILogger<StatusController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("ready")]
        public Status GetReady()
        {
            return new Status();
        }

        [HttpGet]
        [Route("healthz")]
        public Status GetHealthz()
        {
            return new Status();
        }

        [HttpGet]
        [Route("check-up")]
        public Status GetCheckUp()
        {
            return new Status();
        }
    }
}
