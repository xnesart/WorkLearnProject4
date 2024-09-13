using Microsoft.AspNetCore.Mvc;
using Serilog;
using WorkLearnProject4.Data.Models;
using WorkLearnProject4.Data.Repository;
using ILogger = Serilog.ILogger;

namespace WorkLearnProject4.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : Controller
{
    public IOrdersRepository OrdersRepository { get; private set; }
    private readonly ILogger _logger = Log.ForContext<OrdersController>();

    public OrdersController(IOrdersRepository ordersRepository)
    {
        OrdersRepository = ordersRepository;
    }

    [HttpGet]
    public ActionResult<List<Order>> GetAllOrders()
    {
        _logger.Information("Getting list of all orders");

        return Ok(OrdersRepository.GetAllOrders());
    }

    [HttpGet("{id}")]
    public ActionResult<Customer> GetOrderById(Guid id)
    {
        _logger.Information($"Getting order by id {id}");
        
        return Ok(OrdersRepository.GetById(id));
    }

    [HttpPost]
    public ActionResult<Order> CreateOrder(Order order)
    {
        _logger.Information($"Create order with this parameters {order}");

        OrdersRepository.Add(order);
        
        return Ok();
    }

    [HttpPut]
    public ActionResult<Customer> UpdateOrder(Order order)
    {
        _logger.Information($"Put order with this parameters {order}");

        OrdersRepository.Update(order);

        return Ok();
    }

    [HttpPatch]
    public ActionResult<Order> PatchOrder(Order order)
    {
        _logger.Information($"Patch customer with this parameters {order}");

        OrdersRepository.Patch(order);
        
        return Ok();
    }

    [HttpDelete]
    public ActionResult<Customer> DeleteOrder(Guid id)
    {
        _logger.Information($"Delete order by id {id}");

        OrdersRepository.Delete(id);

        return Ok();
    }
}