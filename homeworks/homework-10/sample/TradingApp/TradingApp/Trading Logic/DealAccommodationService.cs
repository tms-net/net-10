using System;
using System.Reflection.Metadata.Ecma335;

namespace TradingApp
{
    // the class is responsible for approving/declying buy/sell offers
    // mock function for now

    // ORDER SERVICE

    // BOUNDARY
    //  - Classes
    //  - Libs
    //  - Process - PROTOCOL
    //  - Machine - PROTOCOL (HTTP)

    public interface IDealAccommodationService
    {
        bool ApproveOrder(string orderId);
        bool CancelOrder(string orderId);
    }

    public class DealAccommodationService : IDealAccommodationService
    {
        private bool _isCancelOrder;

        public bool ApproveOrder(string orderId)
        {
            if (_isCancelOrder)
            {
                _isCancelOrder = false; //reset value for future orders
                return false;
            }
            if (!ClientDecision())
            {
                return false;
            }
            return true;
        }

        //can contain more complicated logic
        public bool CancelOrder(string orderId)
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

