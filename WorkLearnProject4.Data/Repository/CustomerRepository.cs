using WorkLearnProject4.Data.Models;

namespace WorkLearnProject4.Data.Repository;

public class CustomerRepository : ICustomerRepository
{
    private LearnBdContext _context;
    public IEnumerable<Customer> All { get; }

    public CustomerRepository(LearnBdContext context)
    {
        _context = context;
    }

    public void Add(Customer entity)
    {
        _context.Customers.Add(entity);
        _context.SaveChanges();
    }

    public void Delete(Guid id)
    {
        var foundCustomer = _context.Customers.Find(id);

        if (foundCustomer == null) throw new KeyNotFoundException($"customers with {id} not found");

        _context.Customers.Remove(foundCustomer);
        _context.SaveChanges();
    }

    public void Update(Customer entity)
    {
        var foundCustomer = _context.Customers
            .FirstOrDefault(c => c.Name == entity.Name && c.BirthDate == entity.BirthDate && c.Email == entity.Email);

        if (foundCustomer == null) throw new KeyNotFoundException($"customers with {entity.Id} not found");

        foundCustomer.Name = entity.Name;
        foundCustomer.BirthDate = entity.BirthDate;
        foundCustomer.Email = entity.Email;

        _context.Customers.Update(foundCustomer);
        _context.SaveChanges();
    }

    public void Patch(Customer entity)
    {
        // Получаем существующую сущность из базы данных
        var existingEntity = _context.Customers.Find(entity.Id);

        if (existingEntity == null)
        {
            throw new ArgumentException("Customer not found.");
        }

        // Для каждого свойства обновляем только измененные данные
        _context.Entry(existingEntity).CurrentValues.SetValues(entity);

        // Обрабатываем только измененные свойства
        foreach (var property in _context.Entry(existingEntity).Properties)
        {
            if (property.IsModified)
            {
                // Здесь вы можете добавить дополнительную логику
                // Например, запись изменений в лог
                Console.WriteLine($"Property {property.Metadata.Name} was modified.");
            }
        }
    }

    public Customer GetById(Guid id)
    {
        var foundCustomer = _context.Customers.Find(id);
        if (foundCustomer == null) throw new KeyNotFoundException($"customers with {id} not found");

        return foundCustomer;
    }

    public List<Customer> GetAllCustomers()
    {
        var customers = _context.Customers.ToList();

        if (customers == null) throw new KeyNotFoundException("customers are not found");

        return customers;
    }
}