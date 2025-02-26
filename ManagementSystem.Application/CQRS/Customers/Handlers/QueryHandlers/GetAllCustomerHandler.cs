using AutoMapper;
using ManagementSystem.Application.CQRS.Customers.Queries.Requests;
using ManagementSystem.Application.CQRS.Customers.Queries.Responses;
using ManagementSystem.Common.GlobalResponses;
using ManagementSystem.Common.GlobalResponses.Generics;
using ManagementSystem.Repository.Common;
using MediatR;

namespace ManagementSystem.Application.CQRS.Customers.Handlers.QueryHandlers;

public class GetAllCustomerHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetAllCustomerRequest, Result<List<GetAllCustomerResponse>>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<Result<List<GetAllCustomerResponse>>> Handle(GetAllCustomerRequest request, CancellationToken cancellationToken)
    {
        var customers = await _unitOfWork.CustomerRepository.GetAllInitialDataAsync();
        //var response = customers.Select(x => new GetAllCustomerResponse
        //{
        //    Id = x.Id,
        //    Name = x.Name,
        //    Email = x.Email,
        //}).ToList();

        var response = customers.Select(x => _mapper.Map<GetAllCustomerResponse>(x)).ToList();

        return new Result<List<GetAllCustomerResponse>>() { Data = response, IsSuccess = true };
    }
}
