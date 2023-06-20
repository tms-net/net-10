using System;
namespace TradingApp
{
    public class BuyOrder : IOrder
    {
        // 1. Управление статусами

        private IDealAccommodationService _da;
        private OrderInfo _orderInfo;

        public DealStatus DealStatus { get; set; }
        public event Action<OrderInfo, DealDetails> OrderFullfilled;

        public BuyOrder(string symbol, int quantity, decimal? price, OrderPriceType orderPriceType, IDealAccommodationService da)
        {
            _orderInfo = new OrderInfo
            {
                Symbol = symbol,
                Price = price ?? default,
                OrderType = OrderType.Buy,
                OrderPriceType = orderPriceType,
                Quantity = quantity
            };

            _da = da;
        }

        public bool FullfillOrder(DealDetails dealDetails)
        {
            _da.ApproveOrder(_orderInfo.Id);
            DealStatus = DealStatus.Completed;
            OrderFullfilled?.Invoke(_orderInfo, dealDetails);
            return true;
        }

        public bool CancelOrder()
        {
            DealStatus = DealStatus.Cancelled;
            return true;
        }
    }
}

