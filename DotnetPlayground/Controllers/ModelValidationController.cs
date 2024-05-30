using Microsoft.AspNetCore.Mvc;
using SharedPocos.Models;
using System.ComponentModel.DataAnnotations;

namespace DotnetPlayground.WebApi.Controllers;

[Route("api/v1/[controller]/[action]")]
[ApiController]
public class ModelValidationController : ControllerBase
{
    [HttpGet]
    public ActionResult<string> GetSingleParamCustomValidation(string? id, int age)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            return BadRequest("The id field is required");
        }
        return $"id: {id}, age: {age}";
    }

    [HttpGet]
    public ActionResult<string> GetMultiParamCustomValidation(string? id, bool? isTest)
    {
        var errors = new List<string>();
        if (string.IsNullOrWhiteSpace(id))
        {
            errors.Add("The id field is required");
        }
        if (!isTest.HasValue)
        {
            errors.Add("The isTest field is required");
        }
        if (errors.Any())
        {
            return BadRequest(errors);
        }

        return $"id: {id}, isTest: {isTest}";
    }

    [HttpGet]
    public ActionResult<string> GetModelStateValidation(string? id, bool? isTest)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            ModelState.AddModelError(nameof(id), "The id field is required");
        }
        if (!isTest.HasValue)
        {
            ModelState.AddModelError(nameof(isTest), "The isTest field is required");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return $"id: {id}, isTest: {isTest}";
    }

    [HttpGet]
    public ActionResult<string> GetParamAttributeValidation([Required] string? id, [Required] bool isTest)
    {
        return $"id: {id}, isTest: {isTest}";
    }

    /// <summary>
    /// Here, Validation works if nullable is enabled for either project or class
    /// </summary>
    /// <param name="id"></param>
    /// <param name="isTest"></param>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<string> GetNullableAutoValidation(string id, bool isTest)
    {
        return $"id: {id}, isTest: {isTest}";
    }

    /// <summary>
    /// Model Validation. 
    /// All Validation attributes are in the model properties.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    public IEnumerable<string> GetModelValidation(ValidationExampleModel model)
    {
        foreach (var item in model.GetType().GetProperties())
        {
            yield return $"{nameof(item)}: {item}";
        }
    }
}
