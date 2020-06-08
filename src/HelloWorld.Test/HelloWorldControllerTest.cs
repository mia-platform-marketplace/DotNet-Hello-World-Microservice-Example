using System;
using HelloWorld.Controllers;
using HelloWorld.Models;
using Mia.Env;
using Microsoft.Extensions.Options;
using Xunit;

namespace HelloWorld.Test
{
    public class HelloWorldControllerTest
    {
        [Fact]
        public void Get_HelloWorldMessage()
        {
            var environmentConfiguration = new EnvironmentConfiguration()
            {
                HELLO_NAME = "Mock"
            };
            var environmentConfigurationMock = Options.Create<EnvironmentConfiguration>(environmentConfiguration);
            var expectedResponse = $"Hello {environmentConfiguration.HELLO_NAME}";

            var controller = new HelloWorldController(environmentConfigurationMock);

            var response = controller.Get();

            Assert.IsType<HelloWorldMessage>(response);
            Assert.Equal(expectedResponse, response.Salutation);

        }
    }
}
