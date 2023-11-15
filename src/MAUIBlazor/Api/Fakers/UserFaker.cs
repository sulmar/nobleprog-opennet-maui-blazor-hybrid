using Bogus;
using Domain.Model;

namespace Api.Fakers;

public class UserFaker : Faker<User>
{
    public UserFaker()
    {
        RuleFor(p => p.Id, f => f.IndexFaker);
        RuleFor(p => p.FirstName, f => f.Person.FirstName);
        RuleFor(p => p.LastName, f => f.Person.LastName);
        RuleFor(p => p.Email, (f, u) => $"{u.FirstName}.{u.LastName}@allegro.pl");
    }
}
