using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Northwind.Data;

namespace Northwind.Application
{
    public interface IUIDataProvider
    {
        IList<Customer> GetCustomers();
        Customer GetCustomer(string customerID);
    }

    public class UIDataProvider : IUIDataProvider
    {
        NorthwindEntities _northWindEntities = new NorthwindEntities();
        public IList<Customer> GetCustomers()
        {
            return _northWindEntities.Customers.ToList();
        }

        public Customer GetCustomer(string customerID)
        {
            return _northWindEntities.Customers.Single((c) => c.CustomerID == customerID);
        }
    }
}
