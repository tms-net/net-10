using System;
namespace TradingApp
{
	public class BuyOrder : IOrder
	{
        private TradingLogic _tl;

        public BuyOrder(TradingLogic tradingLogic)
        {
            _tl = tradingLogic;
        }

        public void MakeOrderMarket(string symbol, int quantity, decimal price)
        {


        }

        public void MakeOrderPrice(string symbol, int quantity, decimal price)
        {

        }

        public bool CancelOrder()
        {

        }
    }
}

