using System;
namespace TradingApp
{
	public class SellOrder : IOrder
	{
        private TradingLogic _tl;

        private DealAccommodation _da;

        public event Action<bool> OrderApproved;

        public SellOrder(TradingLogic tradingLogic, string symbol, int quantity, decimal price, OrderPriceType orderPriceType)
        {
            _tl = tradingLogic;
        }

        public void MakeOrderMarket()=>OrderApproved?.Invoke(_da.ApproveSellOrder(this));

        public bool MakeOrderPrice()
        { 
            Random random = new Random();
            if (random.Next(0, 100) > 50)
            {
                OrderApproved?.Invoke(_da.ApproveSellOrder(this));
                return true;
            }
            return false;
        }

        
        public bool CancelOrder()=> return _da.CancelCurrentOrder(this);
        
    }
}