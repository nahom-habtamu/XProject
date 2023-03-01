using domain.common;

namespace domain.cargoowner;
public class CargoOwner
{
    public string Id { get; set; }
    public string Name { get; set; }
    public MobileNumber PhoneNumber { get; set; }
    public string Email { get; set; }
    public string SpecificAddress { get; set; }
    public string TradeLicence { get; set; }
    public CargoOwnerPointPerson PointPerson { get; set; }

    public CargoOwner(
        string? id,
        string name,
        MobileNumber phoneNumber,
        string email,
        string specificAddress,
        string tradeLicence,
        CargoOwnerPointPerson pointPerson
    )
    {
        Id = id ?? Guid.NewGuid().ToString("N");
        Name = name;
        PhoneNumber = phoneNumber;
        Email = email;
        SpecificAddress = specificAddress;
        TradeLicence = tradeLicence;
        PointPerson = pointPerson;
    }
}