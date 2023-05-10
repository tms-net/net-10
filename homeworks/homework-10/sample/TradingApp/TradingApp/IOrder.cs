using System;
namespace TradingApp
{
	public interface IOrder
	{
		public void MakeOrderMarket(string symbol,
			int quantity,
			decimal price);

        public void MakeOrderPrice(string symbol,
            int quantity,
            decimal price);

		public bool CancelOrder();
    }
}

