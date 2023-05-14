using System;
namespace TradingApp
{
	public interface IOrder
	{
        public event Action<bool> OrderApproved;

        public void MakeOrderMarket();

        public bool MakeOrderPrice();

		public bool CancelOrder();

    }
}

