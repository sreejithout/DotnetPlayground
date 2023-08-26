using DotnetPlayground.WebApi.ExampleModels;
using Microsoft.AspNetCore.Mvc;
using SharedPocos.Models;

namespace DotnetPlayground.WebApi.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    [BindProperties(SupportsGet = true)]
    [Consumes("application/xml", "application/json")]
    public class ModelBindingController : ControllerBase
    {
        [BindProperty(SupportsGet = true)]
        public bool isTestProp { get; set; }

        [BindProperty(SupportsGet = true, Name = "test")]
        public bool isTestPropWithName { get; set; }

        public string? isTestPropClassOne { get; set; }
        public bool isTestPropClassTwo { get; set; }

        // Sample Url:  api/v1/model-binding/get-direct/12?isTest=true
        [HttpGet("{id}")]
        public string GetDirect(int id, bool isTest)
        {
            return $"id: {id}, isTest: {isTest}";
        }

        // Sample Url:  api/v1/model-binding/get-prop?isTestProp=true
        [HttpGet]
        public string GetProp()
        {
            return $"isTestProp: {isTestProp}";
        }

        // Sample Url:  api/v1/model-binding/get-prop-with-name?isTestPropWithName=true
        // Sample Url:  api/v1/model-binding/get-prop-with-name?test=true
        [HttpGet]
        public string GetPropWithName()
        {
            return $"isTestPropWithName: {isTestPropWithName}";
        }

        // Sample Url:  api/v1/model-binding/get-prop-class?isTestPropClassOne=two&isTestPropClassTwo=true
        [HttpGet]
        public string GetPropClass()
        {
            return $"isTestPropClassOne: {isTestPropClassOne}, isTestPropClassTwo: {isTestPropClassTwo}";
        }

        // Sample Url:  api/v1/model-binding/get-from-query?id=250
        [HttpGet("{id}")] // This one is not going to be takens
        public string GetFromQuery([FromQuery] int id)
        {
            return $"id: {id}";
        }

        // Sample Url:  api/v1/model-binding/get-from-header
        [HttpGet]
        public string GetFromHeader([FromHeader(Name = "Sreejith")] string name)
        {
            return $"name: {name}";
        }

        // Sample Url:  /api/v1/model-binding/get-from-complex-type/234?Name=sdfgg&Marks=1&Marks=2&Marks=5
        [HttpGet("{Id}")] // "id" was not working here. "Id" works.
        public string GetFromComplexType([FromQuery] ModelBindingExample modelBinded)
        {
            return $"Id: {modelBinded.Id}, Name: {modelBinded.Name}, Language: {modelBinded.Language}";
        }

        // Sample Url:  /api/v1/model-binding/post-from-body
        [HttpPost]
        [Consumes("application/xml")] // restricts this endpoint to be consumed by xml only
        public string PostFromBody(MyCustomData customData)
        {
            return $"Id: {customData.Id}, Name: {customData.Name}";
        }
    }
}
