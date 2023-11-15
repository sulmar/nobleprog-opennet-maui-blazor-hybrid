using Api.DTO;
using Api.Mappers;
using Domain.Abstractions;
using Domain.Model;
using FastEndpoints;

namespace Api.Endpoints.Users;

public abstract class GetById<T, TDTO> : Endpoint<GetByIdRequest, T>
    where T : BaseEntity
{
    private readonly IEntityRepository<T> repository;

    public GetById(IEntityRepository<T> repository)
    {
        this.repository = repository;
    }

    public override void Configure()
    {
        AllowAnonymous();
    }


}



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
