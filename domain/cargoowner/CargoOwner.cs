using System;
using domain.cargoowner;
using domain.common;

namespace domain;
public class CargoOwner
{
    public string Id { get; set; }
    public string Name { get; set; }
    public MobileNumber PhoneNumber { get; set; }
    public string Email { get; set; }
    public string SpecificAddress { get; set; }
    public string TradeLicence { get; set; }
    public CargoOwnerPointPerson? PointPerson { get; set; }

    public CargoOwner(
        string name,
        MobileNumber phoneNumber,
        string email,
        string specificAddress,
        string tradeLicence
    )
    {
        Name = name;
        Id = Guid.NewGuid().ToString("N");
        PhoneNumber = phoneNumber;
        Email = email;
        SpecificAddress = specificAddress;
        TradeLicence = tradeLicence;
    }
}