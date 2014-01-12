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
    }

    public class UIDataProvider : IUIDataProvider
    {

        public IList<Customer> GetCustomers()
        {
            return new NorthwindEntities().Customers.ToList();
        }
    }
}
