using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DotNetCore_Hello_World_Microservice_Example.Controllers;
using MiaServiceDotNetLibrary;
using MiaServiceDotNetLibrary.Decorators;
using MiaServiceDotNetLibrary.Environment;
using Microsoft.AspNetCore.Http;
using NFluent;
using NUnit.Framework;

namespace HelloWorld.Test
{
    class EnvsConfigurationsTest: MiaEnvsConfigurations
    {
        [Required]
        [MinLength(5)]
        public string MyCustomEnv { get; set; }
    }
    public class HelloWorldControllerTest
    {
        private EnvsConfigurationsTest _mockEnvsConfigurations;
        private ServiceClientFactory _mockServiceClientFactory;
        private DecoratorResponseFactory _mockDecoratorResponseFactory;
        private IHeaderDictionary _mockHeaderDictionary;
        private HttpContext _httpContext;
        
        [SetUp]
        public void Setup()
        {
            _mockEnvsConfigurations = new EnvsConfigurationsTest
            {
                USERID_HEADER_KEY = "userid",
                USER_PROPERTIES_HEADER_KEY = "userproperties",
                GROUPS_HEADER_KEY = "groups",
                CLIENTTYPE_HEADER_KEY = "clienttype",
                BACKOFFICE_HEADER_KEY = "isbackoffice",
                MICROSERVICE_GATEWAY_SERVICE_NAME = "gateway-name",
                MyCustomEnv = "my-custom-env"
            };

            _mockHeaderDictionary = new HeaderDictionary
            {
                {"userid", "user"},
                {"userproperties", "props"},
                {"groups", "groups"},
                {"clienttype", "client"},
                {"isbackoffice", "true"},
                {"gateway-name", "gateway"}
            };
            
            _httpContext = new DefaultHttpContext();;

            var miaHeadersPropagator =
                new MiaHeadersPropagator(_mockHeaderDictionary, _mockEnvsConfigurations);
            
            _httpContext.Items = new Dictionary<object, object> {{"MiaHeadersPropagator", miaHeadersPropagator}};

            _mockServiceClientFactory = new ServiceClientFactory(_mockEnvsConfigurations);
            _mockDecoratorResponseFactory = new DecoratorResponseFactory();
        }

        [Test]
        public void TestHelloWorld()
        {
            var controller = new HelloWorldController(_mockEnvsConfigurations, _mockServiceClientFactory,
                _mockDecoratorResponseFactory) {ControllerContext = {HttpContext = _httpContext}};
            
            var result = controller.Get();
            
            Check.That(result).Equals("Hello user");
        }
    }
}
