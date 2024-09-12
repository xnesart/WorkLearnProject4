using WorkLearnProject4.Data.Models;

namespace WorkLearnProject4.Data.Repository;

public interface ICustomerRepository
{
    IEnumerable<Customer> All { get; }
    void Add(Customer entity);
    void Delete(Guid id);
    void Update(Customer entity);
    void Patch(Customer entity);
    Customer GetById(Guid id);
    List<Customer> GetAllCustomers();
}