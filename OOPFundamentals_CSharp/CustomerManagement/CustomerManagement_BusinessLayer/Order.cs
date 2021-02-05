using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement_BusinessLayer
{
    public class Order
    {
        public Order()
        {
        }

        public Order(int orderId)
        {
            OrderId = orderId;
        }

        //this type adapts the date to different time zones
        //the ? is used to accept null
        public DateTimeOffset OrderDate { get; set; }
        public int OrderId { get; private set; }

        public bool Validate()
        {
            if (OrderDate == null)
                return false;

            return true;
        }

        public Order Retrieve(int customerId)
        {
            return new Order();
        }

        public List<Order> Retrieve()
        {
            return new List<Order>();
        }

        public bool Save()
        {
            return true;
        }
    }
}
