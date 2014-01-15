using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
//using Northwind.Data;
using Northwind.Application;
using Northwind.Model;
//using Northwind.Application.CustomerService;
using System.Windows.Data;

namespace Northwind.ViewModel.Tests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        [TestMethod]
        public void Customers_Always_CallsGetCustomers()
        {
            IUIDataProvider uiDataProviderMock = MockRepository.GenerateMock<IUIDataProvider>();
            uiDataProviderMock.Expect((c) => c.GetCustomers());
            
            MainWindowViewModel target = new MainWindowViewModel(uiDataProviderMock);

            IList<Customer> expected = target.Customers;

            uiDataProviderMock.VerifyAllExpectations();

        }
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void ShowCustomerDetails_SelectedCustomerIDIsNull_ThrowsException()
        {
            IUIDataProvider uiDataProviderMock = MockRepository.GenerateMock<IUIDataProvider>();

            MainWindowViewModel target = new MainWindowViewModel(uiDataProviderMock);

            target.ShowCustomerDetails();
        }

        [TestMethod]
        public void ShowCustomerDetails_ToolNotFound_AddNewTool()
        {
            Customer expected = new Customer
            {
                CustomerID = "CustomerID"
            };
            MainWindowViewModel target = GetShowCustomerDetailsTarget(expected);
            target.ShowCustomerDetails();
            CustomerDetailsViewModel actual =
              target.Tools.OfType<CustomerDetailsViewModel>().FirstOrDefault(viewmodel =>
                  viewmodel.Customer.CustomerID == expected.CustomerID);

            Assert.IsNotNull(actual);
            
        }

        [TestMethod]
        public void ShowCustomerDetails_Always_ToolIsSetToCurrent()
        {
            Customer expected = new Customer
            {
                CustomerID = "CustomerID"
            };
            MainWindowViewModel target = GetShowCustomerDetailsTarget(expected);
            target.ShowCustomerDetails();
            CustomerDetailsViewModel actual =
            (CustomerDetailsViewModel)CollectionViewSource.GetDefaultView(target.Tools).CurrentItem;

            Assert.AreSame(expected, actual.Customer);
        }

        private MainWindowViewModel GetShowCustomerDetailsTarget(Customer customer)
        { 
            IUIDataProvider uiDataProviderStub = MockRepository.GenerateStub<IUIDataProvider>();

            MainWindowViewModel target = new MainWindowViewModel(uiDataProviderStub);
            target.SelectedCustomerID = customer.CustomerID;
            uiDataProviderStub.Stub(d => d.GetCustomer(customer.CustomerID)).Return(customer);

            return target;
        }
    }
}
