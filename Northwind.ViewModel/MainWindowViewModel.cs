using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Northwind.Data;
using Northwind.Application;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.ComponentModel;

namespace Northwind.ViewModel
{
   public class MainWindowViewModel
    {
       //This is not good for testing. Were dependant on the database
       //We need to add a layer of abstraction so we can mock up
       //This will also enable us to switch datasources easily if needed
        private IList<Customer> _customers;

        private string _selectedCustomerID;

        public String SelectedCustomerID
        {
            get { return _selectedCustomerID; }
            set { _selectedCustomerID = value; }
        }

       //public IList<Customer> Customers
       //{
       //    get
       //    {
       //        return _customers ??
       //        (_customers = new NorthwindEntities().Customers.ToList());
       //    }
       //}

       private readonly IUIDataProvider _dataProvider;

       public ObservableCollection<ToolViewModel> Tools { get; set; }

       public MainWindowViewModel(IUIDataProvider dataProvider)
       {
           _dataProvider = dataProvider;

           Tools = new ObservableCollection<ToolViewModel>();
  
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

       public void ShowCustomerDetails()
       {
           if (string.IsNullOrEmpty(SelectedCustomerID))
               throw new ArgumentNullException("SelectedCustomerID");

           CustomerDetailsViewModel cusDetailsViewModel =
               GetCustomerDetailsViewModel(SelectedCustomerID);

           if (cusDetailsViewModel == null)
           {
               cusDetailsViewModel = new CustomerDetailsViewModel(_dataProvider, SelectedCustomerID);
               Tools.Add(cusDetailsViewModel);
           }

           SetCurrentTool(cusDetailsViewModel);
        }

       private CustomerDetailsViewModel GetCustomerDetailsViewModel(string customerID)
       {
           return Tools.OfType<CustomerDetailsViewModel>()
               .FirstOrDefault(c => c.Customer.CustomerID == customerID);
       }

       private void SetCurrentTool(ToolViewModel currentTool)
       {
           ICollectionView view = CollectionViewSource.GetDefaultView(Tools);
           if (view != null)
               if (view.MoveCurrentTo(currentTool) != true)
                   throw new InvalidOperationException("Current tool does not exist");
       }



       
       
    }
}
