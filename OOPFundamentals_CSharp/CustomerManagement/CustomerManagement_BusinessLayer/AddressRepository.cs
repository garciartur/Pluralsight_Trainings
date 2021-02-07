using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement_BusinessLayer
{
    public class AddressRepository
    {
        //retrieve one address
        public Address Retrieve(int addressId)
        {
            Address address = new Address(addressId);

            //return a populated Address instance
            if (addressId == 1)
            {
                address.AddressType = 1;
                address.StreetLine1 = "Kinomoto's House";
                address.City = "Tomoeda";
                address.State = "Kanto";
                address.Country = "Japan";
                address.PostalCode = "1833-4";
            }

            return address;
        }

        //retrieve a list of addresses 
        public IEnumerable<Address> RetrieveByCostumerId(int customerId)
        {
            var addressList = new List<Address>();

            Address address = new Address(1)
            {
                AddressType = 1,
                StreetLine1 = "Kinomoto's House",
                City = "Tomoeda",
                State = "Kanto",
                Country = "Japan",
                PostalCode = "1833-4"
            };
            addressList.Add(address);

            address = new Address(2)
            {
                AddressType = 2,
                StreetLine1 = "Tomoeda's Elementary School",
                City = "Tomoeda",
                State = "Kanto",
                Country = "Japan",
                PostalCode = "1455-4"
            };
            addressList.Add(address);

            return addressList;
        }

        //save the current address
        public bool Save(Address address)
        {
            return true;
        }
    }
}
