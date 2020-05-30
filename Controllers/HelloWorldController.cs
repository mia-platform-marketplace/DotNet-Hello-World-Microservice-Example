/*
 * Copyright 2020 Mia srl
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HelloWorld.Models;
using Serilog;
using Microsoft.Extensions.Options;
using Mia.Env;

namespace HelloWorld.Controllers
{
    [ApiController]
    [Route(HELLO_ROUTE)]
    public class HelloWorldController : ControllerBase
    {
        private const string HELLO_ROUTE = "hello";
        private string HELLO_NAME;

        public HelloWorldController(IOptions<EnvironmentConfiguration> environmentConfiguration)
        {
            HELLO_NAME = environmentConfiguration.Value.HELLO_NAME;
        }

        [HttpGet]
        public HelloWorldMessage Get()
        {
            Log.Information("Incoming call to {route}", HELLO_ROUTE);

            return new HelloWorldMessage(HELLO_NAME);
        }
    }
}
