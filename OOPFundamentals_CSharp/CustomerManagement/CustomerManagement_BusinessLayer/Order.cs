using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement_BusinessLayer
{
    public class Order : EntityBase
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
        public DateTimeOffset? OrderDate { get; set; }
        public int OrderId { get; private set; }
        //these properties are set to establish a collaboration relationship with Customer, OrderItem and Address
        public int CustomerId { get; set; }
        public int ShippingAddressId { get; set; }
        public List<OrderItem> OrderItems { get; set; }

        public override bool Validate()
        {
            var isValid = true;

            if (OrderDate == null)
                isValid = false;

            return isValid;
        }

        //all objects in .NET inherits the class Object
        //override the method ToString() from Object class to show usefull info in the debug
        //=> is used to return a value directly - less code
        public override string ToString() => 
            $"{OrderDate.Value.Date} ({OrderId})";
    }
}
