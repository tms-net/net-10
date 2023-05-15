using System;
namespace TradingApp
{
    public class SellOrder : IOrder
    {
        private TradingLogic _tl;

        private DealAccommodation _da;
        public string Symbol { get; init; }
        public int Quantity { get; init; }
        public decimal Price { get; init; }

        private OrderInfo _orderInfo;
        public OrderPriceType PriceType { get; init; }

        public event Action<OrderInfo> OrderApproved;

        public SellOrder(TradingLogic tradingLogic, string symbol, int quantity, decimal price, OrderPriceType orderPriceType)
        {
            _orderInfo.Symbol = symbol;
            _orderInfo.DealPrice = quantity * price;
            Symbol = symbol;
            Quantity = quantity;
            Price = price;
            PriceType = orderPriceType;
            _tl = tradingLogic;
            _da = new DealAccommodation();
        }

        public void MakeOrderMarket()
        {
            _da.ApproveSellOrder(this);
            _orderInfo.Status = DealStatus.Completed;
            OrderApproved?.Invoke(_orderInfo);
        }

        public void MakeOrderPrice()
        {
            _da.ApproveSellOrder(this);
            _orderInfo.Status = DealStatus.Completed;
            OrderApproved?.Invoke(_orderInfo);
        }


        public bool CancelOrder()
        {
            _orderInfo.Status = DealStatus.Cancelled;
            return _da.CancelCurrentOrder();
        }
    }
}