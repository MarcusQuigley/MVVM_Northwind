using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using Northwind.Application;
using Northwind.Data;

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
    }
}
