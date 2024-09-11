using Microsoft.AspNetCore.Mvc;
using WorkLearnProject4.Data.Models;
using WorkLearnProject4.Data.Repository;

namespace WorkLearnProject4.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : Controller
{
    public IRepository<Customer> CustomersCtx { get; private set; }

    public CustomersController(IRepository<Customer> customersCtx)
    {
        CustomersCtx = customersCtx;
    }

    [HttpGet]
    public IEnumerable<Customer> GetCustomers()
    {
        throw new NotImplementedException();
    }

    [HttpGet("{id}")]
    public ActionResult<Customer> GetCustomerById(Guid id)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public ActionResult<Customer> CreateCustomer(Guid id)
    {
        throw new NotImplementedException();
    }

    [HttpPut]
    public ActionResult<Customer> UpdateCustomer(Guid id)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    public ActionResult<Customer> DeleteCustomer(Guid id)
    {
        throw new NotImplementedException();
    }
}