using System;
namespace TradingApp
{
    // the class is responsible for approving/declying buy/sell offers
    // mock function for now

    public class DealAccommodation
    {
        private bool _isCancelOrder;

        public bool ApproveBuyOrder(IOrder order)
        {
            Respond();
            if (_isCancelOrder)
            {
                _isCancelOrder = false; //reset value for future orders
                return false;
            }

            return true;
        }

        public bool ApproveSellOrder(IOrder order)
        {
            Respond();
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

        //imitation of serever/client respond
        private void Respond()
        {
            Random random = new Random();
            TimeSpan respondTime = new TimeSpan(0, 0, random.Next(0, 5));
            Thread.Sleep(respondTime);
        }
    }
}

