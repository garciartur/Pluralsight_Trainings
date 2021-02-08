using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement_BusinessLayer
{
    public class ProductRepository
    {
        //retrieve one product
        public Product Retrieve(int productId)
        {
            Product product = new Product(productId);

            //return a populated Order instance
            if (productId == 2)
            {
                product.ProductName = "Clow Cards";
                product.ProductDescription = "Complete deck with 52 magic cards designed by the half british half chinese magician Clow Reed.";
                product.CurrentPrice = 200.50M;
            }

            return product;
        }

        //save the current order
        public bool Save(Product product)
        {
            if (product.HasChanges)
            {
                if (product.IsValid)
                {
                    if (product.IsNew)
                    {
                        //not implemented
                    }
                    else
                    {
                        //not implemented
                    }
                }
                else
                {
                    //in case of invalid data...
                    return false;
                }
            }

            //in case of product with changes...
            return true;
        }
    }
}
