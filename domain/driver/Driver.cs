using domain.common;

namespace domain.driver;
public class Driver
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public MobileNumber PhoneNumber { get; set; }
    public string Email { get; set; }
    public Gender Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Address { get; set; }
    public Uri DrivingLicense { get; set; }
    public Driver(
        string firstName, string lastName,
        MobileNumber phoneNumber, string email,
        Gender gender, DateTime dateOfBirth,
        string address, Uri drivingLicense
    )
    {
        Id = Guid.NewGuid().ToString("N");
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        Email = email;
        Gender = gender;
        DateOfBirth = dateOfBirth;
        Address = address;
        DrivingLicense = drivingLicense;
    }
}
