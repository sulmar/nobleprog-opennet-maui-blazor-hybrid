using Api.DTO;
using Domain.Model;
using Riok.Mapperly.Abstractions;

namespace Api.Mappers;

[Mapper]
public static partial class UserDTOMapper
{
    public static partial UserDTO ToDTO(this User user);
}
