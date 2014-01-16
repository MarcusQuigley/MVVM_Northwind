using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Application.CustomerService; 
using Rhino.Mocks;
using Northwind.Application;
using Service = Northwind.Application.CustomerService;

namespace Northwind.Application.Tests
{
    [TestClass]
    public class UIDataProviderTests
    {
        [TestMethod()]
        public void GetCustomers_Always_CallsGetCustomers()
        {
            Service.Customer[] expected = new Service.Customer[] { new Service.Customer() };
            Service.ICustomerService ICustomerServiceStub = MockRepository.GenerateMock<Service.ICustomerService>();
            ICustomerServiceStub.Expect(c => c.GetCustomers()).Return(expected);

            UIDataProvider target = new UIDataProvider(ICustomerServiceStub);
            target.GetCustomers();
            ICustomerServiceStub.AssertWasCalled(c => c.GetCustomers());

        }

        [TestMethod()]
        public void GetCustomers_ServiceReturnsDto_DtoPassedToTranslator()
        {
            CustomerTranslator._instance = MockRepository.GenerateStub<IEntityTranslator<Model.Customer, Service.Customer>>();
            Service.ICustomerService iCustomerServiceStub = MockRepository.GenerateStub<Service.ICustomerService>();
            Service.Customer expected = new Service.Customer();
            Service.Customer[] dtos = new Service.Customer[] { expected };
            iCustomerServiceStub.Stub(c => c.GetCustomers()).Return(dtos);

            UIDataProvider target = new UIDataProvider(iCustomerServiceStub);
            target.GetCustomers();

            CustomerTranslator._instance.AssertWasCalled(c => c.CreateModel(expected));
        }
        [TestMethod()]
        public void GetCustomers_ServiceReturnsDto_ModelReturnedFromTranslator()
        {
            CustomerTranslator._instance = MockRepository.GenerateStub<IEntityTranslator<Model.Customer, Service.Customer>>();
            Service.ICustomerService serviceStub = MockRepository.GenerateStub<Service.ICustomerService>();
            string expectedID = "expectedID";
            Model.Customer expected = new Model.Customer
            {
                CustomerID = expectedID
            };
            Service.Customer dto = new Service.Customer
            {
                CustomerID = expectedID
            };
            Service.Customer[] dtos = new Service.Customer[] { dto };

            serviceStub.Stub(c => c.GetCustomers()).Return(dtos);

            UIDataProvider target = new UIDataProvider(serviceStub);
            target.GetCustomers();

            CustomerTranslator._instance.Expect(c => c.CreateModel(dto)).Return(expected);

        }

         
    
        [TestMethod()]
        public void GetCustomer_Always_CallsGetCustomer()
        {
            string expectedID = "ExpectedID";
            Service.ICustomerService mockService = MockRepository.GenerateMock<Service.ICustomerService>();
            CustomerTranslator._instance = MockRepository.GenerateStub<IEntityTranslator<Model.Customer, Service.Customer>>();

            var model = new Model.Customer { CustomerID = expectedID };
            var dto = new Service.Customer{CustomerID=expectedID};
            var dtos = new Service.Customer[] { dto };

            UIDataProvider target = new UIDataProvider(mockService);

            mockService.Stub(c => c.GetCustomers()).Return(dtos);
            CustomerTranslator._instance.Stub(c => c.CreateModel(dto)).Return(model);
            target.GetCustomers();

            target.GetCustomer(expectedID);
             
            mockService.AssertWasCalled(c => c.GetCustomer(expectedID));
        }
    }
}
