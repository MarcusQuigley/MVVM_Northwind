using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Northwind.Application;
using Northwind.Data;

namespace Northwind.ViewModel
{
   public class CustomerDetailsViewModel : ToolViewModel
    {
       private readonly IUIDataProvider _dataProvider;
       
       public Customer Customer { get; set; }
      
       public CustomerDetailsViewModel(IUIDataProvider dataProvider, string customerID)
       {
           _dataProvider = dataProvider;

           Customer = _dataProvider.GetCustomer(customerID);
           DisplayName = Customer.CompanyName;

           
       }
    }
}
