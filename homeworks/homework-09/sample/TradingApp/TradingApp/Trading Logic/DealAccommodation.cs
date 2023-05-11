using System;
using System.Reflection.Metadata.Ecma335;

namespace TradingApp
{
    // the class is responsible for approving/declying buy/sell offers
    // mock function for now

    public class DealAccommodation
    {
        private bool _isCancelOrder;

        public bool ApproveBuyOrder(IOrder order)
        {
            if (_isCancelOrder)
            {
                _isCancelOrder = false; //reset value for future orders
                return false;
            }
            if (order.PriceType == OrderPriceType.Price)
            {
                if (!ClientDecision())
                    return false;
            }
            return true;
        }

        public bool ApproveSellOrder(IOrder order)
        {
            if (_isCancelOrder)
            {
                _isCancelOrder = false; //reset value for future orders
                return false;
            }

            return true;
        }

        //can contain more complicated logic
        public bool CancelCurrentOrder()
        {
            _isCancelOrder = true;

            return true;
        }
       
        //whether client accepts deal terms 
        private bool ClientDecision()
        {
            Random random= new Random();
            if (random.Next(0,100)>50)
                return true;
            return false;
        }
    }
}

