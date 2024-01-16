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

    /// <summary>
    /// GetCustomerEager
    /// 
    /// Change Tracking:
    /// When EF Core queries a DB, it stores the snapshot of the result set in memory
    /// Now, any modifications you made into that entity is actually made to that snapshot and then later written to DB.
    /// In a read only scenario, there's no chance we are going to write data back to the DB. 
    /// So we can skip the snapshot in the above readonly scenario.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Customer> GetCustomerEager(int id)
    {
        return await _dbContext.Customers
            .Include(c => c.Orders) // Eager Loading
            .AsNoTracking() // To Disable change tracking.
            .SingleAsync(x => x.Id == id);
    }

    public async Task<Customer> GetCustomerLazy(int id)
    {
        return await _dbContext.Customers
            .Include(c => c.Orders)
            .AsSplitQuery()
            .SingleAsync(x => x.Id == id);
    }

    public async Task<Customer> GetCustomerFromSqlInterpolated(int id)
    {
        return await _dbContext.Customers
            .FromSqlInterpolated(@$"
                SELECT TOP(2) [c].[Id], [c].[Address], [c].[Email], [c].[FirstName], [c].[LastName], [c].[Phone]
                FROM [Customers] AS [c]
                WHERE [c].[Id] = {id}
               "
            )
            .SingleAsync(); ;
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
