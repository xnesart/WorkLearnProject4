using WorkLearnProject4.Data.Models;

namespace WorkLearnProject4.Data.Repository;

public class CustomerRepository:IRepository<Customer>
{
    public IEnumerable<Customer> All { get; }
    public void Add(Customer entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Customer entity)
    {
        throw new NotImplementedException();
    }

    public void Update(Customer entity)
    {
        throw new NotImplementedException();
    }

    public Customer FindById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Customer GetById(Guid id)
    {
        throw new NotImplementedException();
    }
}