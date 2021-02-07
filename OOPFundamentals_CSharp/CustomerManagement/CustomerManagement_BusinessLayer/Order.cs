using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement_BusinessLayer
{
    public class Order
    {
        public Order() : this(0)
        {
        }

        public Order(int orderId)
        {
            OrderId = orderId;
            OrderItems = new List<OrderItem>();
        }

        //this type adapts the date to different time zones
        //the ? is used to accept null
        public DateTimeOffset OrderDate { get; set; }
        public int OrderId { get; private set; }
        //these properties are set to establish a collaboration relationship with Customer, OrderItem and Address
        public int CustomerId { get; set; }
        public int ShippingAddressId { get; set; }
        public List<OrderItem> OrderItems { get; set; }

        public bool Validate()
        {
            if (OrderDate == null)
                return false;

            return true;
        }
    }
}
