namespace Api.DTO;

public record UserDTO(string FirstName, string LastName, string Email, AddressDTO ShippingAddress);

public record AddressDTO (string City, string Street);
