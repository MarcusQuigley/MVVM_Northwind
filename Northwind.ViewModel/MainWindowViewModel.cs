using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Northwind.Data;

namespace Northwind.ViewModel
{
   public class MainWindowViewModel
    {
       private IList<Customer> _customers;

       public IList<Customer> Customers
       {
           get
           {
               return _customers ??
               (_customers = new NorthwindEntities().Customers.ToList());
           }
       }
       
    }
}
