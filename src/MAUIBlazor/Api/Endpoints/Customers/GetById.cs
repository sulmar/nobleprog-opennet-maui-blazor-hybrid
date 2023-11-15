using Api.DTO;
using Api.Endpoints.Users;
using Api.Mappers;
using Domain.Abstractions;
using FastEndpoints;

namespace Api.Endpoints.Customers;

public class GetById : Endpoint<GetByIdRequest, CustomerDTO>
{
    private readonly ICustomerRepository repository;

    public GetById(ICustomerRepository repository)
    {
        this.repository = repository;
    }

    public override void Configure()
    {
        AllowAnonymous();
        Get("/api/customers/{Id}");
    }

    public override async Task HandleAsync(GetByIdRequest req, CancellationToken ct)
    {
        Response = (await repository.GetById(req.Id)).ToDTO();
    }

}
