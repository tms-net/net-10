using System;
namespace TradingApp
{
    // COHESION - Связанность по близости/функционалу
    // HIGH COHESION

    // Utils -> может быть LOW COHESION
    // ThreadUtils
    // OrderUtils

    // COUPLING - Связанность по завимости (dependency)
    // LOW COUPLING

    public interface IOrder
	{
        event Action<OrderInfo, DealDetails> OrderFullfilled;
        bool FullfillOrder(DealDetails dealDetails);
        bool CancelOrder();
    }
}

