using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CarDealer.DTO;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<SuppliersModel, Supplier>();
            this.CreateMap<PartsModel, Part>();
            this.CreateMap<CustomersModel, Customer>();
            this.CreateMap<SalesModel, Sale>();
        }
    }
}
