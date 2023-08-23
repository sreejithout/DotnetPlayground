using EntityFrameworkCorePlayground.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories.Interfaces;

namespace DotnetPlayground.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ICustomerRepository customerRepository, ILogger<CustomerController> logger)
        {
            _customerRepository = customerRepository;
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
            return _customerRepository.GetAllCustomers();
        }

        /// <summary>
        /// Get single Customer details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<Customer> GetCustomer(int id)
        {
            return await _customerRepository.GetCustomer(id);
        }

        /// <summary>
        /// Add a Customer
        /// </summary>
        /// <param name="prod"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task AddCustomer([FromBody] Customer prod)
        {
            await _customerRepository.AddCustomer(prod);
        }

        /// <summary>
        /// Update Customer
        /// </summary>
        /// <param name="prod"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task UpdateCustomer([FromBody] Customer prod)
        {
            await _customerRepository.UpdateCustomer(prod);
        }

        /// <summary>
        /// Remove Customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task RemoveCustomer(int id)
        {
            await _customerRepository.RemoveCustomer(id);
        }
    }
}
