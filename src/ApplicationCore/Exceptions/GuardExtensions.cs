using Ardalis.GuardClauses;
using OnlineShop.ApplicationCore.Entities.BasketAggregate;

namespace OnlineShop.ApplicationCore.Exceptions
{
    public static class BasketGuards
    {
        public static void NullBasket(this IGuardClause guardClause, int basketId, Basket basket)
        {
            if (basket == null)
                throw new BasketNotFoundException(basketId);
        }
    }
}