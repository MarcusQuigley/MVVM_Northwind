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

namespace Northwind.ViewModel.Tests
{
    /// <summary>
    /// Summary description for CustomerDetailsViewModel
    /// </summary>
    [TestClass]
    public class CustomerDetailsViewModelTests
    {

        [TestMethod]
        public void Ctor_Always_CallsGetCustomer()
        {
            IUIDataProvider uiDataProviderMock = MockRepository.GenerateMock<IUIDataProvider>();
            const string expectedID = "ExpectedID";

            uiDataProviderMock.Expect(c => c.GetCustomer(expectedID)).Return(new Customer());

            CustomerDetailsViewModel target = new CustomerDetailsViewModel
            (uiDataProviderMock, expectedID);

            uiDataProviderMock.VerifyAllExpectations();
        }

        [TestMethod]
        public void Customer_Always_ReturnsCustomerFromGetCustomer()
        {
            IUIDataProvider uiDataProviderMock = MockRepository.GenerateMock<IUIDataProvider>();
            const string expectedID = "ExpectedID";
            Customer expectedCustomer = new Customer
            {
                CustomerID = expectedID
            };
            uiDataProviderMock.Expect(c => c.GetCustomer(expectedID)).Return(expectedCustomer);

            CustomerDetailsViewModel target = new CustomerDetailsViewModel(uiDataProviderMock, expectedID);
            Assert.AreSame(expectedCustomer, target.Customer);
        }

        [TestMethod]
        public void DisplayName_Always_ReturnsCompanyName()
        {
            IUIDataProvider uiDataProviderStub = MockRepository.GenerateStub<IUIDataProvider>();
            const string expectedID = "ExpectedID";
            const string expectedCompanyName = "ExpectedCompanyName";
            Customer expectedCustomer = new Customer
            {
                CustomerID = expectedID,
                CompanyName = expectedCompanyName
            };

            uiDataProviderStub.Expect(c => c.GetCustomer(expectedID)).Return(expectedCustomer);
            CustomerDetailsViewModel target = new CustomerDetailsViewModel(uiDataProviderStub, expectedID);
            Assert.AreSame(expectedCompanyName, target.DisplayName);


        }
    }
}
