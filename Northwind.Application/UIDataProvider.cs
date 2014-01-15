using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Northwind.Data;
//using Northwind.Application.CustomerService;
using Northwind.Model;
 using Service = Northwind.Application.CustomerService;
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

       // private IList<Model.Customer> _customers; //This persists Session State
        private readonly Service.CustomerServiceClient _client
            = new Service.CustomerServiceClient();

        public IList<Model.Customer> GetCustomers()
        {
            //  return _northWindEntities.Customers.ToList();
            return  _client.GetCustomers()
            .Select(c => new Model.Customer().Update(c)
             ).ToList();
        }

        public Model.Customer GetCustomer(string customerID)
        {
            // return _northWindEntities.Customers.Single((c) => c.CustomerID == customerID);

            return new Model.Customer().Update(_client.GetCustomer(customerID));

        }
    }
}
   
