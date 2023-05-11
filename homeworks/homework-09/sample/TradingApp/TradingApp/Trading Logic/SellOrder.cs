using System;
namespace TradingApp
{
	public class SellOrder : IOrder
	{
        private TradingLogic _tl;

        public event Action<bool> OrderApproved;

        public SellOrder(TradingLogic tradingLogic, string symbol, int quantity, decimal price, OrderPriceType orderPriceType)
        {
            _tl = tradingLogic;
        }

        public void MakeOrderMarket()
        {

        }

        public void MakeOrderPrice()
        {

        }

        public bool CancelOrder()
        {
            return true;
        }
    }
}

