using EntityFrameworkCorePlayground.Models;

namespace Repositories.Interfaces;

public interface ICustomerRepository
{
    /// <summary>
    /// Get All Customers
    /// </summary>
    /// <returns></returns>
    IEnumerable<Customer> GetAllCustomers();

    /// <summary>
    /// Get a Customer's Details using EF Core Eager Loading
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Customer> GetCustomerEager(int id);

    /// <summary>
    /// Get a Customer's Details using EF Core Lazy Loading
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Customer> GetCustomerLazy(int id);

    /// <summary>
    /// Get a Customer's Details using EF Core From Sql Interpolated
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Customer> GetCustomerFromSqlInterpolated(int id);

    /// <summary>
    /// Add a Customer
    /// </summary>
    /// <param name="customer"></param>
    /// <returns></returns>
    Task<bool> AddCustomer(Customer customer);

    /// <summary>
    /// Update a Customer
    /// </summary>
    /// <param name="customer"></param>
    /// <returns></returns>
    Task<Customer> UpdateCustomer(Customer customer);

    /// <summary>
    /// Remove a Customer
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> RemoveCustomer(int id);
}
