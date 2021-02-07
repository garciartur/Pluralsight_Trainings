using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement_BusinessLayer
{
    public class CustomerRepository
    {
        //retrieve one customer
        public Customer Retrieve(int customerId)
        {
            Customer customer = new Customer(customerId);

            //return a populated Customer instance
            if (customerId == 1)
            {
                customer.EmailAdress = "sakurakinomoto@cardcaptors.com";
                customer.FirstName = "Sakura";
                customer.LastName = "Kinomoto";
            }

            return customer;
        }

        //save the current customer
        public bool Save(Customer customer)
        {
            return true;
        }
    }
}
