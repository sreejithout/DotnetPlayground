using EntityFrameworkCorePlayground.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace DotnetPlayground.WebApi.Controllers;

[Route("api/v1/[controller]/[action]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;
    private readonly ILogger<CustomerController> _logger;

    public CustomerController(ICustomerService customerService, ILogger<CustomerController> logger)
    {
        _customerService = customerService;
        _logger = logger;
    }

    /// <summary>
    /// Get All Customers
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IEnumerable<Customer> GetAllCustomers()
    {
        _logger.LogInformation("Getting all the customers");
        return _customerService.GetAllCustomers();
    }

    /// <summary>
    /// Get single Customer details
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<Customer> GetCustomer(int id)
    {
        return await _customerService.GetCustomer(id);
    }

    /// <summary>
    /// Add a Customer
    /// </summary>
    /// <param name="customer"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task AddCustomer([FromBody] Customer customer)
    {
        await _customerService.AddCustomer(customer);
    }

    /// <summary>
    /// Update Customer
    /// </summary>
    /// <param name="customer"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task UpdateCustomer([FromBody] Customer customer)
    {
        await _customerService.UpdateCustomer(customer);
    }

    /// <summary>
    /// Remove Customer
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task RemoveCustomer(int id)
    {
        await _customerService.RemoveCustomer(id);
    }
}
