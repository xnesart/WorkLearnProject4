//
// using Microsoft.AspNetCore.Mvc;
// using Serilog;
// using WorkLearnProject4.Data.Models;
// using WorkLearnProject4.Data.Repository;
//
// namespace WorkLearnProject4.API.Controllers;
//
// [ApiController]
// [Route("api/[controller]")]
// public class OrdersController : Controller
// {
//     public IOrdersRepository OrdersRepository { get; private set; }
//     private readonly Serilog.ILogger _logger = Log.ForContext<OrdersController>();
//
//     public OrdersController(IOrdersRepository ordersRepository)
//     {
//         OrdersRepository = ordersRepository;
//     }
//
//     [HttpGet]
//     public IEnumerable<Customer> GetAllOrders()
//     {
//         _logger.Information("Getting list of all users");
//
//         return OrdersRepository.GetAllOrders();
//     }
//
//     [HttpGet("{id}")]
//     public ActionResult<Customer> GetCustomerById(Guid id)
//     {
//         _logger.Information($"Getting user by id {id}");
//         
//         return Ok(CustomersRepository.GetById(id));
//     }
//
//     [HttpPost]
//     public ActionResult<Customer> CreateCustomer(Customer customer)
//     {
//         _logger.Information($"Create customer with this parameters {customer}");
//
//         CustomersRepository.Add(customer);
//         
//         return Ok();
//     }
//
//     [HttpPut]
//     public ActionResult<Customer> UpdateCustomer(Customer customer)
//     {
//         _logger.Information($"Put customer with this parameters {customer}");
//
//         CustomersRepository.Update(customer);
//
//         return Ok();
//     }
//
//     [HttpPatch]
//     public ActionResult<Customer> PatchCustomer(Customer customer)
//     {
//         _logger.Information($"Patch customer with this parameters {customer}");
//
//         CustomersRepository.Patch(customer);
//         
//         return Ok();
//     }
//
//     [HttpDelete]
//     public ActionResult<Customer> DeleteCustomer(Guid id)
//     {
//         _logger.Information($"Delete customer by id {id}");
//
//         CustomersRepository.Delete(id);
//
//         return Ok();
//     }
// }