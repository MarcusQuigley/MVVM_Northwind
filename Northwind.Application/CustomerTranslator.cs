using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
using Service = Northwind.Application.CustomerService;
namespace Northwind.Application
{
    public class CustomerTranslator : IEntityTranslator<Model.Customer, Service.Customer>
    {
        internal static IEntityTranslator<Model.Customer,
            Service.Customer> _instance;

        public static IEntityTranslator<Model.Customer,
            Service.Customer> Instance
        {
            get
            {
                return _instance ??
                       (_instance = new CustomerTranslator());
            }
        }

        public Model.Customer CreateModel(Service.Customer dto)
        {
            //   if (dto == null) throw new ArgumentNullException("dto");

            return UpdateModel(new Model.Customer(), dto);
        }

        public Model.Customer UpdateModel(Model.Customer model, Service.Customer dto)
        {
            if (model == null) throw new ArgumentNullException("model");
            if (dto == null) throw new ArgumentNullException("dto");

            if (model.CustomerID != dto.CustomerID)
                model.CustomerID = dto.CustomerID;

            if (model.CompanyName != dto.CompanyName)
                model.CompanyName = dto.CompanyName;

            model.Address = dto.Address;
            model.City = dto.City;
            model.ContactName = dto.ContactName;
            model.ContactTitle = dto.ContactTitle;
            model.Country = dto.Country;
            model.Phone = dto.Phone;
            model.PostCode = dto.PostCode;
            model.Region = dto.Region;

            return model;
        }

        public Service.Customer CreateDto(Model.Customer model)
        {
            return UpdateDto(new Service.Customer(), model);
        }

        public Service.Customer UpdateDto(Service.Customer dto, Model.Customer model)
        {
            if (dto == null) throw new ArgumentNullException("dto");
            if (model == null) throw new ArgumentNullException("model");

            if (dto.CustomerID != model.CustomerID)
                dto.CustomerID = model.CustomerID;

            if (dto.CompanyName != model.CompanyName)
                dto.CompanyName = model.CompanyName;
 
            dto.Address = model.Address;
            dto.City = model.City;
            dto.ContactName = model.ContactName;
            dto.ContactTitle = model.ContactTitle;
            dto.Country = model.Country;
            dto.Phone = model.Phone;
            dto.PostCode = model.PostCode;
            dto.Region = model.Region;

            return dto;
        }
    }
}
