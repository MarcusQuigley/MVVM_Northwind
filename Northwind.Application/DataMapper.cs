using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Service = Northwind.Application.CustomerService;
namespace Northwind.Application
{
    public static class DataMapper
    {
        public static Model.Customer Update(this Model.Customer model, Service.Customer dto)
        {
            model.Address = dto.Address;
            model.City = dto.City;
            model.CompanyName = dto.CompanyName;
            model.ContactName = dto.ContactName;
            model.ContactTitle = dto.ContactTitle;
            model.Country = dto.Country;
            model.CustomerID = dto.CustomerID;
            model.Phone = dto.Phone;
            model.PostCode = dto.PostCode;
            model.Region = dto.Region;

            return model;
        }
    }
}
