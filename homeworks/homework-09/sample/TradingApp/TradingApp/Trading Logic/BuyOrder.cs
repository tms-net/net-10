using System;
namespace TradingApp
{
	public class BuyOrder : IOrder
	{
        private TradingLogic _tl;
        private DealAccommodation _da;

        public string Symbol { get; init; }
        public int Quantity { get; init; }
        public decimal Price { get; init; }
        public OrderPriceType PriceType { get; init; }

        public event Action<bool> OrderApproved;

        public BuyOrder(TradingLogic tradingLogic, string symbol, int quantity, decimal price, OrderPriceType orderPriceType)
        {
            _tl = tradingLogic;
            _da = new DealAccommodation();
            Symbol = symbol;
            Quantity = quantity;
            Price = price;
            PriceType = orderPriceType;
        }

        /// <summary>
        /// make buy order with market price
        /// fires event OrderApproved based on response from DealAccommodation
        /// </summary>
        public void MakeOrderMarket()=>OrderApproved?.Invoke(_da.ApproveBuyOrder(this)); //call event

        /// <summary>
        ///make buy order with market price
        /// fires event OrderApproved based on response from DealAccommodation
        /// </summary>   
        public void MakeOrderPrice()
        {
            Random random = new Random();
            if (random.Next(0, 100) > 50)
            {
                OrderApproved?.Invoke(_da.ApproveBuyOrder(this));
                return true;
            }
            return false;
        }
        public bool CancelOrder() => _da.CancelCurrentOrder();            
    }   
}

