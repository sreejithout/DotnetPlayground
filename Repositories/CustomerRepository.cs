using EntityFrameworkCorePlayground.Data;
using EntityFrameworkCorePlayground.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Repositories;

internal class CustomerRepository : ICustomerRepository
{
    private readonly DummyDbContext _dbContext;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="dbContext"></param>
    public CustomerRepository(DummyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> AddCustomer(Customer customer)
    {
        var newCustomer = new Customer
        {
            FirstName = customer.FirstName,
            LastName = customer.LastName
        };
        await _dbContext.AddAsync(newCustomer);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public IEnumerable<Customer> GetAllCustomers()
    {
        return _dbContext.Customers;
    }

    public async Task<Customer> GetCustomer(int id)
    {
        return await _dbContext.Customers
            .Include(c => c.Orders) // Eager Loading
            .SingleAsync(x => x.Id == id);
    }

    public async Task<bool> RemoveCustomer(int id)
    {
        var newProd = _dbContext.Customers.Single(p => p.Id == id);
        _dbContext.Remove(newProd);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<Customer> UpdateCustomer(Customer customer)
    {
        var newCustomer = _dbContext.Customers.Single(p => p.Id == customer.Id);
        newCustomer.FirstName = customer.FirstName;
        newCustomer.LastName = customer.LastName;
        await _dbContext.SaveChangesAsync();
        return newCustomer;
    }
}
