using System.ComponentModel.DataAnnotations;

namespace Api.DTO;

public record UserDTO(string FirstName, string LastName, string Email);

public record AddressDTO (string City, string Street);

public record CustomerDTO
{
    [Required, StringLength(10, MinimumLength = 2)]
    public string FirstName { get; set; }
    public string LastName { get; set; }
}