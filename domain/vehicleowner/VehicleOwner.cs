using domain.common;
using dtos.vehicleowner;

namespace domain.vehicleowner;

public class VehicleOwner
{
    public string Id { get; set; }
    public string Name { get; set; }
    public MobileNumber PhoneNumber { get; set; }
    public string Email { get; set; }
    public string CompanyName { get; set; }
    public Uri TradeLicence { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }

    public VehicleOwner(
        string name, MobileNumber phoneNumber,
        string email, string companyName, Uri tradeLicence,
        string userName, string password,
        string? id = null
    )
    {
        Id = id ?? Guid.NewGuid().ToString("N");
        Name = name;
        PhoneNumber = phoneNumber;
        Email = email;
        CompanyName = companyName;
        TradeLicence = tradeLicence;
        UserName = userName;
        Password = password;
    }

    public static VehicleOwner buildFromDto(CreateVehicleOwnerRequest requestDto)
    {
        return new VehicleOwner(
            requestDto.Name!,
            new MobileNumber(requestDto.PhoneNumber!),
            requestDto.Email!, requestDto.CompanyName!,
            new Uri(requestDto.TradeLicence!),
            requestDto.UserName!, requestDto.Password!
        );
    }
}