using WorkLearnProject4.Data.Models;

namespace WorkLearnProject4.Data.Repository;

public interface IAddressRepository
{
    void Add(Address address);
    void Delete(Guid id);
    void Update(Address address);
    Address Patch(AddressPatch address);
    Address GetById(Guid id);
    List<Address> GetAll();
}