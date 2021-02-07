using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement_BusinessLayer
{
    public class OrderRepository
    {
        //retrieve one order
        public Order Retrieve(int orderId)
        {
            Order order = new Order(orderId);

            //return a populated Order instance
            if (orderId == 10)
            {
                order.OrderDate = new DateTimeOffset(DateTime.Now.Year, 4, 14, 10, 00, 00, new TimeSpan(7, 0, 0));
            }

            return order;
        }

        //save the current order
        public bool Save(Order order)
        {
            return true;
        }
    }
}
