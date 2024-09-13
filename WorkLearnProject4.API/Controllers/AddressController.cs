using Microsoft.AspNetCore.Mvc;
using Serilog;
using WorkLearnProject4.Data.Models;
using WorkLearnProject4.Data.Repository;

namespace WorkLearnProject4.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AddressController:Controller
{
    public IAddressRepository AddressRepository { get; private set; }
    private readonly Serilog.ILogger _logger = Log.ForContext<AddressController>();

    public AddressController(IAddressRepository addressRepository)
    {
        AddressRepository = addressRepository;
    }
    [HttpGet]
    public ActionResult<List<Address>> GetAllAddresses()
    {
        _logger.Information("Getting list of all address");

        return Ok(AddressRepository.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<Address> GetAddressById(Guid id)
    {
        _logger.Information($"Getting address by id {id}");
        
        return Ok(AddressRepository.GetById(id));
    }
    
    [HttpPost]
    public ActionResult<Address> AddAddress(Address address)
    {
        _logger.Information($"Adding address with this parameters {address}");

        AddressRepository.Add(address);
        
        return Ok();
    }

    [HttpPut]
    public ActionResult<Address> UpdateAddress(Address address)
    {
        _logger.Information($"Put address with this parameters {address}");

        AddressRepository.Update(address);

        return Ok();
    }  
    
    [HttpPatch]
    public ActionResult<Address> PatchAddress(AddressPatch address)
    {
        _logger.Information($"Patch address with this parameters {address}");
        
        return Ok(AddressRepository.Patch(address));
    }
    
    [HttpDelete]
    public ActionResult DeleteAddress(Guid id)
    {
        _logger.Information($"Delete address by id {id}");

        AddressRepository.Delete(id);

        return Ok();
    }
}