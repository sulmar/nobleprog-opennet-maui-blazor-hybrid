using Api.DTO;
using Api.Mappers;
using Domain.Abstractions;
using FastEndpoints;

namespace Api.Endpoints.Users;

public class GetById : Endpoint<GetByIdRequest, UserDTO>
{
    private readonly IUserRepository repository;

    public GetById(IUserRepository repository)
    {
        this.repository = repository;
    }

    public override void Configure()
    {
        AllowAnonymous();
        Get("/api/users/{Id}");
    }

    public override async Task HandleAsync(GetByIdRequest req, CancellationToken ct)
    {
        Response = (await repository.GetById(req.Id)).ToDTO();
    }

}
