using System.Threading.Tasks;
using OnlineShop.ApplicationCore.Entities.OrderAggregate;

namespace OnlineShop.ApplicationCore.Interfaces
{

    public interface IOrderRepository : IRepository<Order>, IAsyncRepository<Order>
    {
        Order GetByIdWithItems(int id);
        Task<Order> GetByIdWithItemsAsync(int id);
    }
}
