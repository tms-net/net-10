using System;
namespace TradingApp
{
	public interface IOrder
	{
        public event Action<DealDetails> OrderFullfilled;
		public void CancelOrder();
    }
}

