using Api.DTO;
using Api.Mappers;
using Domain.Abstractions;
using FastEndpoints;
using Microsoft.AspNetCore.Identity;

namespace Api.Endpoints.Users;

public class GetAll : EndpointWithoutRequest<IEnumerable<UserDTO>>
{
    private readonly IUserRepository repository;

    public GetAll(IUserRepository repository)
    {
        this.repository = repository;
    }

    public override void Configure()
    {
        Roles("Admin", "developer");
        Get("/api/users");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var users = await repository.GetAllAsync();

        var userDTOs = users
            .Select(u => u.ToDTO());

        Response = userDTOs;
    }


}
