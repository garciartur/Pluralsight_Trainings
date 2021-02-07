using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement_BusinessLayer
{
    public class OrderItem
    {
        public OrderItem()
        {
        }

        public OrderItem(int orderItemId)
        {
            OrderItemId = orderItemId;
        }

        public int ProductId { get; set; }
        public int OrderItemId { get; private set; }
        public int Quantity { get; set; }
        public decimal? PurchasePrice { get; set; }

        public bool Validate()
        {
            if (Quantity <= 0)
                return false;

            if (ProductId <= 0)
                return false;

            if (PurchasePrice == null)
                return false;

            return true;
        }
    }
}
