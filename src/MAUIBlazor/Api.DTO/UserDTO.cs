namespace Api.DTO;

public record UserDTO(string FirstName, string LastName, string Email);

public record AddressDTO (string City, string Street);
