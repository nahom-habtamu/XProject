using domain.common;

namespace domain.cargoowner;
public class CargoOwnerPointPerson
{
    public CargoOwnerPointPerson(
        string name, 
        MobileNumber phoneNumber, 
        string specificAddress, 
        string email, 
        string position
    )
    {
        Name = name;
        PhoneNumber = phoneNumber;
        SpecificAddress = specificAddress;
        Email = email;
        Position = position;
    }

    public string Name { get; set; }
    public MobileNumber PhoneNumber { get; set; }
    public string SpecificAddress { get; set; }
    public string Email { get; set; }
    public string Position { get; set; }
}