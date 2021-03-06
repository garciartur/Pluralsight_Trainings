﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement_BusinessLayer
{
    public class CustomerRepository
    {
        //establishes a collaborative relationship with AddressRepository
        public CustomerRepository()
        {
            addressRepository = new AddressRepository();
        }
        public AddressRepository addressRepository { get; set; }

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
                //communicate with AddressRepository and receive a list of addresses populated
                customer.AddressList = addressRepository.RetrieveByCostumerId(customerId).ToList();
            }

            return customer;
        }

        //save the current customer
        public bool Save(Customer customer)
        {
            if (customer.HasChanges)
            {
                if (customer.IsValid)
                {
                    if (customer.IsNew)
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
