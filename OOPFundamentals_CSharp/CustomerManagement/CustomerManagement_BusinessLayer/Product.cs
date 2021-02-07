using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement_BusinessLayer
{
    public class Product
    {
        public Product()
        {
        }

        public Product(int productId)
        {
            ProductId = productId;
        }

        public string ProductName { get; set; }
        public int ProductId { get; private set; }
        public string ProductDescription { get; set; }

        //the interrogative sign denotes a variable that can be nullable
        public decimal? CurrentPrice { get; set; }

        public bool Validate()
        {
            if (string.IsNullOrWhiteSpace(ProductName))
                return false;

            if (string.IsNullOrWhiteSpace(ProductDescription))
                return false;

            if (CurrentPrice == null)
                return false;

            return true;
        }        
    }
}
