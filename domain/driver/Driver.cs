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
        MobileNumber phoneNumber, string email,
        Gender gender, DateTime dateOfBirth,
        string address, string drivingLicense
    )
    {
        Id = id ?? Guid.NewGuid().ToString("N");
        Name = name;
        PhoneNumber = phoneNumber;
        Email = email;
        Gender = gender;
        DateOfBirth = dateOfBirth;
        SpecificAddress = address;
        DrivingLicense = drivingLicense;
    }

    public static Driver parseFromDto(CreateDriverRequestDto requestDto)
    {
        var gender = requestDto.Gender == 0 ? Gender.MALE : Gender.FEMALE;
        return new Driver(
            null,
            requestDto.Name!,
            new MobileNumber(requestDto.PhoneNumber!),
            requestDto.Email!, gender,
            requestDto.DateOfBirth, requestDto.Address!,
            requestDto.DrivingLicense!
        );
    }
}
