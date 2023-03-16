using domain.common;

namespace domain.cargoowner;
public class CargoOwnerPointPerson
{
    public CargoOwnerPointPerson(
        string position,
        string name,
        string phoneNumber,
        string specificAddress,
        string email
    )
    {
        Name = name;
        PhoneNumber = new MobileNumber(phoneNumber);
        SpecificAddress = specificAddress;
        Email = email;
        Position = position;
    }

    public string Name { get; set; }
    public MobileNumber PhoneNumber { get; set; }
    public string SpecificAddress { get; set; }
    public string Email { get; set; }
    public string Position { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj == null)
            return false;

        if (ReferenceEquals(obj, this))
            return false;

        if (obj.GetType() != this.GetType())
            return false;

        var parsed = obj as CargoOwnerPointPerson;

        if (
            this.Name.Equals(parsed?.Name) &&
            this.Email.Equals(parsed.Email) &&
            this.SpecificAddress.Equals(parsed.SpecificAddress) &&
            this.Position.Equals(parsed.Position)
        )
        {
            return true;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return this.PhoneNumber.Value.GetHashCode();
    }
}