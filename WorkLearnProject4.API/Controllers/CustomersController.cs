using Microsoft.AspNetCore.Mvc;
using Serilog;
using WorkLearnProject4.Data.Models;
using WorkLearnProject4.Data.Repository;

namespace WorkLearnProject4.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : Controller
{
    public ICustomerRepository CustomersRepository { get; private set; }
    private readonly Serilog.ILogger _logger = Log.ForContext<CustomersController>();

    public CustomersController(ICustomerRepository customersRepository)
    {
        CustomersRepository = customersRepository;
    }

    [HttpGet]
    public IEnumerable<Customer> GetCustomers()
    {
        _logger.Information("Получаем список всех пользователей");
        
        return CustomersRepository.GetAllCustomers();
    }

    [HttpGet("{id}")]
    public ActionResult<Customer> GetCustomerById(Guid id)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public ActionResult<Customer> CreateCustomer(Customer customer)
    {
        CustomersRepository.Add(customer);
        return Ok();
    }

    [HttpPut]
    public ActionResult<Customer> UpdateCustomer(Customer customer)
    {
        throw new NotImplementedException();
    }
    
    [HttpPatch]
    public ActionResult<Customer> PatchCustomer(Customer customer)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    public ActionResult<Customer> DeleteCustomer(Guid id)
    {
        throw new NotImplementedException();
    }
}