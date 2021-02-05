﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement_BusinessLayer
{
    public class Customer
    {
        //it's common to put the constructor before properties
        public Customer()
        {
        }

        public Customer(int customerId)
        {
            CustomerID = customerId;
        }

        //use this property structure when you need to implement getter and setter
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }
        //it needs a private field to receive the value
        private string _lastName;

        //use this property structure when you don't need to implement the getter and setter
        //the private field is created under the hoods
        public string FirstName { get; set; }

        //creating a readonly property
        public string FullName
        {
            get
            {
                //handling empty fieds
                string fullName = LastName;

                //verify the first name is empty
                if (!string.IsNullOrWhiteSpace(FirstName))
                {
                    //verify the last name is empty
                    if(!string.IsNullOrWhiteSpace(fullName))
                    {
                        //in case last name isn't empty add a comma
                        fullName += ", ";
                    }

                    //in case first name isn't empty add it in the end of the string
                    fullName += FirstName;
                }

                //LastName and FirstName empty return null
                //LastName empty return FirstName
                //FirstName empty return LastName without comma
                //everything ok return LastName, FirstName
                return fullName;
            }
        }

        //completing the class properties
        public string EmailAdress { get; set; }
        public int CustomerID { get; set; }

        //creating a static counter that belongs to the class and not to a specific instance
        public static int CustomerCount { get; set; }

        //validates user input
        public bool Validate()
        {
            if (string.IsNullOrWhiteSpace(LastName))
                return false;

            if (string.IsNullOrWhiteSpace(EmailAdress))
                return false;

            return true;
        }

        //retrieve one customer
        public Customer Retrieve(int customerId)
        {
            return new Customer();
        }

        //retrieve all customers
        public List<Customer> Retrieve()
        {
            return new List<Customer>();
        }

        //save the current customer
        public bool Save()
        {
            return true;
        }
    }
}
