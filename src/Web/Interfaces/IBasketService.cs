using System.Threading.Tasks;
using OnlineShop.Web.ViewModels;

namespace OnlineShop.Web.Interfaces
{
    public interface IBasketViewModelService
    {
        Task<BasketViewModel> GetOrCreateBasketForUser(string userName);
    }
}
