namespace Domain.Model;

public class User : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public Address ShippingAddress { get; set; } = new();

    public string HashedPassword { get; set; }

}


public class Address : Base
{
    public string City { get; set; }
    public string Street { get; set; }
}