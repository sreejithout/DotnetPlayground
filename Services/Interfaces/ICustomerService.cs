using EntityFrameworkCorePlayground.Models;

namespace Services.Interfaces;

public interface ICustomerService
{
    /// <summary>
    /// Get All Customers
    /// </summary>
    /// <returns></returns>
    IEnumerable<Customer> GetAllCustomers();

    /// <summary>
    /// Get a Customer's Details
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Customer> GetCustomerEager(int id);

    /// <summary>
    /// Get a Customer's Details by Lazy loading
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Customer> GetCustomerLazy(int id);

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
