using AutoMapper;
using Customer.Application.DTOS;
using Customer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Application.Mapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerEntity, CustomerDto>(); 
            CreateMap<CustomerDto, CustomerEntity>(); 
        }
    }
}
