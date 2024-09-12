using Serilog;
using WorkLearnProject4.Data.Models;

namespace WorkLearnProject4.Data.Repository;

public class CustomerRepository : ICustomerRepository
{
    private LearnBdContext _context;
    private readonly Serilog.ILogger _logger = Log.ForContext<CustomerRepository>();

    public CustomerRepository(LearnBdContext context)
    {
        _context = context;
    }

    public void Add(Customer entity)
    {
        entity.Id = Guid.NewGuid();
        _logger.Information($"Start adding customer with this parameters {entity} in repository method");
        
        _context.Customers.Add(entity);
        _context.SaveChanges();

        if (_context.Customers.FirstOrDefault(c => c.Id == entity.Id) != null)
        {
            _logger.Information($"Customer was added successful {entity}");
        }
    }

    public void Delete(Guid id)
    {
        _logger.Information($"Start deleting customer with this id {id} in repository method");

        var foundCustomer = _context.Customers.Find(id);

        if (foundCustomer == null)
        {
            _logger.Error($"Error, Customer with this id {id} not found");
            
            throw new KeyNotFoundException($"customers with {id} not found");
        }

        _context.Customers.Remove(foundCustomer);
        _context.SaveChanges();
    }

    //TODO переделать, обновляемый пользователь не будет соответсовавть старому.
    public void Update(Customer entity)
    {
        _logger.Information($"Start updating customer with this parameters {entity} in repository method");

        var foundCustomer = _context.Customers
            .FirstOrDefault(c => c.Name == entity.Name && c.BirthDate == entity.BirthDate && c.Email == entity.Email);

        if (foundCustomer == null)
        {
            _logger.Error($"Error, Customer with this id {entity.Id} not found");
            
            throw new KeyNotFoundException($"customers with {entity.Id} not found");
        }

        foundCustomer.Name = entity.Name;
        foundCustomer.BirthDate = entity.BirthDate;
        foundCustomer.Email = entity.Email;

        _context.Customers.Update(foundCustomer);
        _context.SaveChanges();
    }

    public void Patch(Customer entity)
    {
        _logger.Information($"Start patching customer with this parameters {entity} in repository method");
        var existingEntity = _context.Customers.Find(entity.Id);

        if (existingEntity == null)
        {
            _logger.Error($"Error, Customer not found");
            
            throw new ArgumentException("Customer not found.");
        }

        _context.Entry(existingEntity).CurrentValues.SetValues(entity);
        
        foreach (var property in _context.Entry(existingEntity).Properties)
        {
            if (property.IsModified)
            {
                Console.WriteLine($"Property {property.Metadata.Name} was modified.");
            }
        }

        _context.SaveChanges();
    }

    public Customer GetById(Guid id)
    {
        _logger.Information($"Start getting customer with this id {id} in repository method");

        var foundCustomer = _context.Customers.Find(id);
        if (foundCustomer == null)
        {
            _logger.Error($"Error, customer with this id {id} is not found");

            throw new KeyNotFoundException($"customers with {id} not found");
        }

        return foundCustomer;
    }

    public List<Customer> GetAllCustomers()
    {
        var customers = _context.Customers.ToList();

        if (customers == null)
        {
            _logger.Error($"Error, customers are not found");

            throw new KeyNotFoundException("customers are not found");
        }

        return customers;
    }
}