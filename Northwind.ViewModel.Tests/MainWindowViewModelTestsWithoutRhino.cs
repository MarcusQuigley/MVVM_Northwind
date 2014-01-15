using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Northwind.Data;
using Northwind.Application;
using Northwind.Application.CustomerService;

namespace Northwind.ViewModel.Tests
{
    [TestClass]
    public class MainWindowViewModelTestsWithoutRhino
    {
        [TestMethod]
        public void Customers_Always_CallsGetCustomers()
        {
            IList<Customer> expected = GetCustomers();

            IUIDataProvider stub = new UIDataProviderStub()
            {
                Customers = expected
            };

            MainWindowViewModel target = new MainWindowViewModel
            (stub);

            CollectionAssert.AreEquivalent(
               (List<Customer>)  expected,
                (List<Customer>)target.Customers);
         }

        private IList<Customer> GetCustomers()
        {
            IList<Customer> customer = new List<Customer>();

            for (int i = 1; i < 10; i++)
            {
                customer.Add(new Customer()
                {
                    CustomerID = i.ToString(),
                    CompanyName = "N" + i
                });
            }
                return customer;
        }

        private class UIDataProviderStub : IUIDataProvider
        {
            public IList<Customer> Customers
            {
                private get;
                set;
            }

            public IList<Customer> GetCustomers()
            {
                return Customers;
            }


            public Customer GetCustomer(string customerID)
            {
                throw new NotImplementedException();
            }
        }


    }
}
