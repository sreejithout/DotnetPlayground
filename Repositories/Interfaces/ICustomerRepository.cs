using EntityFrameworkCorePlayground.Models;

namespace Repositories.Interfaces
{
    public interface ICustomerRepository
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
        Task<Customer> GetCustomer(int id);

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
}
