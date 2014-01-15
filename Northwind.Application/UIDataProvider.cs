using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Northwind.Data;
using Northwind.Application.CustomerService;
 
namespace Northwind.Application
{
    public interface IUIDataProvider
    {
        IList<Customer> GetCustomers();
        Customer GetCustomer(string customerID);
    }

    public class UIDataProvider : IUIDataProvider
    {
       // NorthwindEntities _northWindEntities = new NorthwindEntities();

        private IList<Customer> _customers; //This persists Session State
        private readonly CustomerServiceClient _client = new CustomerService.CustomerServiceClient();

        public IList<Customer> GetCustomers()
        {
          //  return _northWindEntities.Customers.ToList();
            return _customers ??
            (_customers = _client.GetCustomers());
        }

        public Customer GetCustomer(string customerID)
        {
           // return _northWindEntities.Customers.Single((c) => c.CustomerID == customerID);
 

            Customer customer = _customers.First(c=> c.CustomerID==customerID);
            return customer.Update(_client.GetCustomer(customerID));
        }
    }

    internal static class CustomerExtensions
    {
        public static Customer Update(this Customer customer, Customer existingCustomer)
        {
            customer.ContactName = existingCustomer.ContactName;
            customer.Address = existingCustomer.Address;
            customer.City = existingCustomer.City;
            customer.Region = existingCustomer.Region;
            customer.Country = existingCustomer.Country;
            customer.Phone = existingCustomer.Phone;
            return customer;
        }
    }
}
