using System;
namespace TradingApp
{
    public class SellOrder : IOrder
    { 
        private IDealAccommodationService _da;
        private OrderInfo _orderInfo;

        public DealStatus DealStatus { get; set; }
        public event Action<OrderInfo, DealDetails> OrderFullfilled;

        public SellOrder(string symbol, int quantity, decimal? price, OrderPriceType orderPriceType, IDealAccommodationService da)
        {
            _orderInfo = new OrderInfo
            {
                Symbol = symbol,
                Price = price,
                OrderType = OrderType.Sell,
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