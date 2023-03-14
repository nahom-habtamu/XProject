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
}