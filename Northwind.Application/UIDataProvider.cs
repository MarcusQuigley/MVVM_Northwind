using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Northwind.Data;
//using Northwind.Application.CustomerService;
 
 using Service = Northwind.Application.CustomerService;
namespace Northwind.Application
{
    public interface IUIDataProvider
    {
        IList<Model.Customer> GetCustomers();
        Model.Customer GetCustomer(string customerID);
    }

    public class UIDataProvider : IUIDataProvider
    {
        private Service.ICustomerService _client;
        IList<Model.Customer> _customers;

        public UIDataProvider(Service.ICustomerService client)
        {
            if (client == null) throw new ArgumentNullException("client");

            _client = client;
        }

        public IList<Model.Customer> GetCustomers()
        {
            return _customers ??
            (_customers = _client.GetCustomers()
            .Select(c => CustomerTranslator.Instance.CreateModel(c))
            .ToList());
        }

        public Model.Customer GetCustomer(string customerID)
        {
            Model.Customer modelCustomer = GetCustomers()
                .First(c => c.CustomerID == customerID);
            return CustomerTranslator.Instance.UpdateModel
                (modelCustomer, _client.GetCustomer(customerID));
        }
    }


  

  
}
   
