using AutoMapper;
using ManagementSystem.Application.CQRS.Customers.Commands.Requests;
using ManagementSystem.Application.CQRS.Customers.Commands.Responses;
using ManagementSystem.Application.CQRS.Customers.Queries.Responses;
using ManagementSystem.Domain.Entities;

namespace ManagementSystem.Application.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateCustomerRequest, Customer>();
        CreateMap<Customer, CreateCustomerResponse>();
        CreateMap<Customer, GetAllCustomerResponse>();
    }
}
