using System.Threading.Tasks;
using OnlineShop.ApplicationCore.Entities.OrderAggregate;

namespace OnlineShop.ApplicationCore.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrderAsync(int basketId, Address shippingAddress);
    }
}
