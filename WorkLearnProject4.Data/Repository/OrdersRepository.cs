using Microsoft.EntityFrameworkCore;
using Serilog;
using WorkLearnProject4.Data.Models;

namespace WorkLearnProject4.Data.Repository;

public class OrdersRepository : IOrdersRepository
{
    private LearnBdContext _context;
    private readonly Serilog.ILogger _logger = Log.ForContext<OrdersRepository>();

    public OrdersRepository(LearnBdContext context)
    {
        _context = context;
    }

    public void Add(Order order)
    {
        _logger.Information($"Start adding order with this parameters {order} in repository method");

        var customer = _context.Customers.FirstOrDefault(c => c.Id == order.CustomerId);
        if (customer == null)
        {
            _logger.Error($"Customer with id {order.CustomerId} not found");
            throw new KeyNotFoundException($"Customer with id {order.CustomerId} not found");
        }

        order.Customer = customer;

        order.Id = Guid.NewGuid();
    
        _context.Orders.Add(order);
        _context.SaveChanges();

        _logger.Information($"Order was added successfully with id {order.Id}");
    }

    public void Delete(Guid id)
    {
        _logger.Information($"Start deleting order with this id {id} in repository method");

        var foundOrder = _context.Orders.Find(id);

        if (foundOrder == null)
        {
            _logger.Error($"Error, Order with this id {id} not found");

            throw new KeyNotFoundException($"Error, Order with {id} not found");
        }

        _context.Orders.Remove(foundOrder);
        _context.SaveChanges();
    }

    //TODO переделать, обновляемый пользователь не будет соответсовавть старому.
    public void Update(Order order)
    {
        _logger.Information($"Start updating order with this parameters {order} in repository method");

        var foundOrder = _context.Orders
            .FirstOrDefault(c => c.Id == order.Id);

        if (foundOrder == null)
        {
            _logger.Error($"Error, Order with this id {order.Id} not found");

            throw new KeyNotFoundException($"Order with {order.Id} not found");
        }

        foundOrder.Name = order.Name;
        foundOrder.Date = order.Date;
        foundOrder.Customer = order.Customer;

        _context.Orders.Update(foundOrder);
        _context.SaveChanges();
    }

    public void Patch(Order order)
    {
        _logger.Information($"Start patching order with this parameters {order} in repository method");
        var foundOrder = _context.Orders.Find(order.Id);

        if (foundOrder == null)
        {
            _logger.Error($"Error, Order not found");

            throw new ArgumentException("Order not found.");
        }

        _context.Entry(foundOrder).CurrentValues.SetValues(order);

        foreach (var property in _context.Entry(foundOrder).Properties)
        {
            if (property.IsModified)
            {
                Console.WriteLine($"Property {property.Metadata.Name} was modified.");
            }
        }

        _context.SaveChanges();
    }

    public Order GetById(Guid id)
    {
        _logger.Information($"Start getting order with this id {id} in repository method");

        var foundOrder = _context.Orders
            .Include(o => o.Customer).FirstOrDefault(o => o.Id == id);

        if (foundOrder == null)
        {
            _logger.Error($"Error, Order with this id {id} is not found");
            throw new KeyNotFoundException($"Error, Order with {id} not found");
        }

        return foundOrder;
    }

    public List<Order> GetAllOrders()
    {
        var orders = _context.Orders
            .Include(o => o.Customer).ToList();

        if (orders == null)
        {
            _logger.Error($"Error, orders are not found");

            throw new KeyNotFoundException("Error, Orders are not found");
        }

        return orders;
    }
}