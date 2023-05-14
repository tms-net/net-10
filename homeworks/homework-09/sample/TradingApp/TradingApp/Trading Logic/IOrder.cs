using System;
namespace TradingApp
{
	public interface IOrder
	{
        public OrderPriceType PriceType { get; init; }

        public event Action<bool> OrderApproved;

        public void MakeOrderMarket();

        public void MakeOrderPrice();

		public bool CancelOrder();

    }
}

