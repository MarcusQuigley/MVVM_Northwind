using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Northwind.Data;
using System.ServiceModel;

namespace Northwind.Service
{
    [ServiceContract]
    public interface ICustomerService
    {
        [OperationContract]
        IList<Customer> GetCustomers();
        [OperationContract]
        Customer GetCustomer(string customerID);
    }


    public class CustomerService : ICustomerService
    {
        private readonly NorthwindEntities _northWindEntities = new NorthwindEntities();

        public IList<Customer> GetCustomers()
        {
            return _northWindEntities.Customers
                .Select(c => new Northwind.Service.Customer 
                { 
                    CustomerID = c.CustomerID, 
                    CompanyName = c.CompanyName}
                ).ToList();
        }
 
        public Customer GetCustomer(string customerID)
        {
            return _northWindEntities.Customers.Select(customer =>
                new Northwind.Service.Customer 
                {
                    CustomerID = customer.CustomerID,
                    CompanyName = customer.CompanyName,
                    ContactName = customer.ContactName,
                    Address = customer.Address,
                    City = customer.City,
                    Country = customer.Country,
                    Region = customer.Region,
                    PostCode = customer.PostalCode,
                    Phone = customer.Phone
                }).Single(
                c => c.CustomerID == customerID);
        }
    }
}
