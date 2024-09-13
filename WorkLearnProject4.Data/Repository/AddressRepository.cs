using Serilog;
using WorkLearnProject4.Data.Models;

namespace WorkLearnProject4.Data.Repository;

public class AddressRepository : IAddressRepository
{
    private readonly LearnBdContext _context;
    private readonly Serilog.ILogger _logger = Log.ForContext<AddressRepository>();

    public AddressRepository(LearnBdContext context)
    {
        _context = context;
    }

    public void Add(Address address)
    {
        address.Id = Guid.NewGuid();
        _logger.Information($"Adding address with parameters {address} in repository method");
        _context.Addresses.Add(address);
        _context.SaveChanges();
    }

    public void Delete(Guid id)
    {
        _logger.Information($"Deleting address with id {id} in repository method");
        var address = _context.Addresses.Find(id);
        if (address == null)
        {
            _logger.Error($"Address with id {id} not found");
            throw new KeyNotFoundException($"Address with id {id} not found");
        }

        _context.Addresses.Remove(address);
        _context.SaveChanges();
    }

    public Address Patch(AddressPatch entity)
    {
        _logger.Information($"Start patching address with this parameters {entity} in repository method");

        var existingEntity = _context.Addresses.Find(entity.Id);

        if (existingEntity == null)
        {
            _logger.Error($"Error, Address with id {entity.Id} not found");
            throw new ArgumentException($"Address with id {entity.Id} not found.");
        }

        if (!string.IsNullOrEmpty(entity.Street)) existingEntity.Street = entity.Street;
        if (!string.IsNullOrEmpty(entity.City)) existingEntity.City = entity.City;
        if (!string.IsNullOrEmpty(entity.PostalCode)) existingEntity.PostalCode = entity.PostalCode;
        if (!string.IsNullOrEmpty(entity.Country)) existingEntity.Country = entity.Country;

        _context.SaveChanges();

        foreach (var property in _context.Entry(existingEntity).Properties)
        {
            if (property.IsModified)
            {
                _logger.Information($"Property {property.Metadata.Name} was modified.");
            }
        }

        return existingEntity;
    }

    public void Update(Address address)
    {
        _logger.Information($"Updating address with parameters {address} in repository method");
        var existingAddress = _context.Addresses.Find(address.Id);
        if (existingAddress == null)
        {
            _logger.Error($"Address with id {address.Id} not found");
            throw new KeyNotFoundException($"Address with id {address.Id} not found");
        }

        _context.Entry(existingAddress).CurrentValues.SetValues(address);
        _context.SaveChanges();
    }

    public Address GetById(Guid id)
    {
        _logger.Information($"Getting address by id {id} in repository method");
        var address = _context.Addresses.Find(id);
        if (address == null)
        {
            _logger.Error($"Address with id {id} not found");
            throw new KeyNotFoundException($"Address with id {id} not found");
        }

        return address;
    }

    public List<Address> GetAll()
    {
        _logger.Information("Getting all addresses in repository method");
        return _context.Addresses.ToList();
    }
}