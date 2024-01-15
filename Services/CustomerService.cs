using EntityFrameworkCorePlayground.Models;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<bool> AddCustomer(Customer customer)
    {
        return await _customerRepository.AddCustomer(customer);
    }

    public IEnumerable<Customer> GetAllCustomers()
    {
        return _customerRepository.GetAllCustomers();
    }

    public async Task<Customer> GetCustomer(int id)
    {
        return await _customerRepository.GetCustomer(id);
    }

    public async Task<bool> RemoveCustomer(int id)
    {
        return await _customerRepository.RemoveCustomer(id);
    }

    public async Task<Customer> UpdateCustomer(Customer customer)
    {
        return await _customerRepository.UpdateCustomer(customer);
    }
}
