using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Northwind.Data;
using Northwind.Application;

namespace Northwind.ViewModel
{
   public class MainWindowViewModel
    {
       //This is not good for testing. Were dependant on the database
       //We need to add a layer of abstraction so we can mock up
       //This will also enable us to switch datasources easily if needed
        private IList<Customer> _customers;
       //public IList<Customer> Customers
       //{
       //    get
       //    {
       //        return _customers ??
       //        (_customers = new NorthwindEntities().Customers.ToList());
       //    }
       //}

       private readonly IUIDataProvider _dataProvider;

       public MainWindowViewModel(IUIDataProvider dataProvider)
       {
           _dataProvider = dataProvider;
       }


       public IList<Customer> Customers
       {
           get
           {
               return _customers ??
               (_customers = GetCustomers());
           }
       }

       private IList<Customer> GetCustomers()
       {
           return _dataProvider.GetCustomers();
       }



       
       
    }
}
