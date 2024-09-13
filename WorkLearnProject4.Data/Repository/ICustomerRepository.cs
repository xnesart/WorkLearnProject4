using WorkLearnProject4.Data.Models;

namespace WorkLearnProject4.Data.Repository;

public interface ICustomerRepository
{
    void Add(Customer entity);
    void Delete(Guid id);
    void Update(Customer entity);
    Customer Patch(CustomerPatch customer);
    Customer GetById(Guid id);
    List<Customer> GetAllCustomers();
}