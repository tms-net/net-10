using System;
namespace TradingApp
{
    public class BuyOrder : IOrder
    {
        private TradingLogic _tl;
        private DealAccommodation _da;

        public string Symbol { get; init; }
        public int Quantity { get; init; }
        public decimal Price { get; init; }

        private OrderInfo _orderInfo;
        public OrderPriceType PriceType { get; init; }

        public event Action<OrderInfo> OrderApproved;

        public BuyOrder(TradingLogic tradingLogic, string symbol, int quantity, decimal price, OrderPriceType orderPriceType)
        {
            _orderInfo = new OrderInfo();
            _tl = tradingLogic;
            _orderInfo.Symbol = symbol;
            _orderInfo.DealPrice = quantity * price;
            _da = new DealAccommodation();
            Symbol = symbol;
            Quantity = quantity;
            Price = price;
            PriceType = orderPriceType;
        }

        /// <summary>
        /// make buy order with market price
        /// fires event OrderApproved based on response from DealAccommodation
        /// </summary>
        public void MakeOrderMarket()
        {
            _da.ApproveBuyOrder(this);
            _orderInfo.Status = DealStatus.Completed;
            OrderApproved?.Invoke(_orderInfo);
        }//call event

        /// <summary>
        ///make buy order with market price
        /// fires event OrderApproved based on response from DealAccommodation
        /// </summary>   
        public void MakeOrderPrice()
        {
            _da.ApproveBuyOrder(this);
            _orderInfo.Status = DealStatus.Completed;
            OrderApproved?.Invoke(_orderInfo);
        }

        public bool CancelOrder()
        {
            _orderInfo.Status = DealStatus.Cancelled;
            return _da.CancelCurrentOrder();
        }
    }
}/* на входе - параметры с конутруктры
  * на выход е- event orderinfo*/

