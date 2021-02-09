using CM_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement_BusinessLayer
{
    public class Product : EntityBase
    {
        public Product()
        {
        }

        public Product(int productId)
        {
            ProductId = productId;
        }

        //using the common library to handle the name
        public string _productName { get; set; }
        public string ProductName
        {
            get
            {
                //you can instanciate a handler to call the methods, but isn't necessary when using a static class
                //var stringHandler = new StringHandler();
                //return stringHandler.InsertSpace(_productName);

                //static classes can be called directly without an instance
                //return StringHandler.InsertSpace(_productName);

                //when you use a extended method, it extends the type, it's showed by intellisense and can be called directly by the var
                return _productName.InsertSpace();
            }
            set
            {
                _productName = ProductName;
            }
        }

        public int ProductId { get; private set; }
        public string ProductDescription { get; set; }

        //the interrogative sign denotes a variable that can be nullable
        public decimal? CurrentPrice { get; set; }

        public override bool Validate()
        {
            if (string.IsNullOrWhiteSpace(ProductName))
                return false;

            if (string.IsNullOrWhiteSpace(ProductDescription))
                return false;

            if (CurrentPrice == null)
                return false;

            return true;
        }

        //overriding the Object class to show the product name while debugging
        public override string ToString() 
            => ProductName;
    }
}
