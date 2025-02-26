using AutoMapper;
using ManagementSystem.Application.CQRS.Customers.Commands.Requests;
using ManagementSystem.Application.CQRS.Customers.Commands.Responses;
using ManagementSystem.Common.Exceptions;
using ManagementSystem.Common.GlobalResponses;
using ManagementSystem.Common.GlobalResponses.Generics;
using ManagementSystem.Domain.Entities;
using ManagementSystem.Repository.Common;
using MediatR;

namespace ManagementSystem.Application.CQRS.Customers.Handlers.CommandHandlers;

public class CreateCustomerHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateCustomerRequest, Result<CreateCustomerResponse>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    public async Task<Result<CreateCustomerResponse>> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
    {
        //Customer newCustomer = new(request.Name, request.Email);
        var newCustomer = _mapper.Map<Customer>(request);

        if (string.IsNullOrEmpty(newCustomer.Name))
        {
            throw new BadRequestException("Categoriyanin adi null ve ya bosh ola bilmez");
        }

        await _unitOfWork.CustomerRepository.AddAsync(newCustomer);
        //CreateCustomerResponse response = new()
        //{
        //    Id = newCustomer.Id,
        //    Name = newCustomer.Name,
        //    Email = newCustomer.Email
        //};

        var response = _mapper.Map<CreateCustomerResponse>(newCustomer);
        return new Result<CreateCustomerResponse>
        {
            Data = response,
            Errors = [],
            IsSuccess = true
        };
    }
}
