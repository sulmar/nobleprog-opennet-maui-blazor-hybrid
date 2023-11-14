using Api.DTO;
using Domain.Model;

namespace Api.Mappers;

public static class UserDTOMapper
{
    public static UserDTO ToDTO(this User user) => Map(user);

    private static UserDTO Map(User u) => new(
                       u.FirstName,
                       u.LastName,
                       u.Email);
}
