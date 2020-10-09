using System.Collections.Generic;
using DotNetCore_Hello_World_Microservice_Example.Controllers;
using MiaServiceDotNetLibrary;
using MiaServiceDotNetLibrary.Decorators;
using MiaServiceDotNetLibrary.Environment;
using Microsoft.AspNetCore.Http;
using NFluent;
using NUnit.Framework;

namespace HelloWorld.Test
{
    public class HelloWorldControllerTest
    {
        private MiaEnvConfiguration _mockMiaEnvConfig;
        private ServiceClientFactory _mockServiceClientFactory;
        private DecoratorResponseFactory _mockDecoratorResponseFactory;
        private IHeaderDictionary _mockHeaderDictionary;
        private HttpContext _httpContext;
        
        [SetUp]
        public void Setup()
        {
            _mockMiaEnvConfig = new MiaEnvConfiguration
            {
                USERID_HEADER_KEY = "userid",
                USER_PROPERTIES_HEADER_KEY = "userproperties",
                GROUPS_HEADER_KEY = "groups",
                CLIENTTYPE_HEADER_KEY = "clienttype",
                BACKOFFICE_HEADER_KEY = "isbackoffice",
                MICROSERVICE_GATEWAY_SERVICE_NAME = "gateway-name"
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
                new MiaHeadersPropagator(_mockHeaderDictionary, _mockMiaEnvConfig);
            
            _httpContext.Items = new Dictionary<object, object> {{"MiaHeadersPropagator", miaHeadersPropagator}};

            _mockServiceClientFactory = new ServiceClientFactory(_mockMiaEnvConfig);
            _mockDecoratorResponseFactory = new DecoratorResponseFactory();
        }

        [Test]
        public void TestHelloWorld()
        {
            var controller = new HelloWorldController(_mockMiaEnvConfig, _mockServiceClientFactory,
                _mockDecoratorResponseFactory) {ControllerContext = {HttpContext = _httpContext}};
            
            var result = controller.Get();
            
            Check.That(result).Equals("Hello user");
        }
    }
}
