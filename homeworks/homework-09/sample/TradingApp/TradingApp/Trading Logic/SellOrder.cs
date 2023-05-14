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
        public OrderPriceType PriceType { get; init; }

        public event Action<bool> OrderApproved;

        public SellOrder(TradingLogic tradingLogic, string symbol, int quantity, decimal price, OrderPriceType orderPriceType)
        {
            Symbol = symbol;
            Quantity = quantity;
            Price = price;
            PriceType = orderPriceType;
            _tl = tradingLogic;
            _da = new DealAccommodation();
        }

        public void MakeOrderMarket() => OrderApproved?.Invoke(_da.ApproveSellOrder(this));

        public void MakeOrderPrice() => OrderApproved?.Invoke(_da.ApproveSellOrder(this));


        public bool CancelOrder() => _da.CancelCurrentOrder();
    }
}