using WorkLearnProject4.Data.Models;

namespace WorkLearnProject4.Data.Repository;

public interface IOrdersRepository
{
    void Add(Order order);
    void Delete(Guid id);
    void Update(Order order);
    void Patch(Order order);
    Order GetById(Guid id);
    List<Order> GetAllOrders();
}