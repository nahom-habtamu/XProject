using domain.common;
using dtos.driver;

namespace domain.driver;
public class Driver
{
    public string Id { get; set; }
    public string Name { get; set; }
    public MobileNumber PhoneNumber { get; set; }
    public string Email { get; set; }
    public Gender Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string SpecificAddress { get; set; }
    public string DrivingLicense { get; set; }
    public Driver(
        string? id,
        string name,
        string phoneNumber,
        string email,
        string gender,
        DateTime dateOfBirth,
        string address,
        string drivingLicense
    )
    {
        Id = id ?? Guid.NewGuid().ToString("N");
        Name = name;
        PhoneNumber = new MobileNumber(phoneNumber);
        Email = email;
        Gender = int.Parse(gender) == 0 ? Gender.MALE : Gender.FEMALE;
        DateOfBirth = dateOfBirth;
        SpecificAddress = address;
        DrivingLicense = drivingLicense;
    }

    public static Driver parseFromDto(CreateDriverRequestDto requestDto)
    {
        return new Driver(
            null,
            requestDto.Name!,
            requestDto.PhoneNumber!,
            requestDto.Email!,
            requestDto.Gender!,
            requestDto.DateOfBirth, requestDto.Address!,
            requestDto.DrivingLicense!
        );
    }
}
