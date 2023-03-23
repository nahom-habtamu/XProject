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
    public string TradeLicense { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }

    public VehicleOwner(
        string? id, string name, string phoneNumber,
        string email, string companyName, string tradeLicense,
        string userName, string password
    )
    {
        Id = id ?? Guid.NewGuid().ToString("N");
        Name = name;
        PhoneNumber = new MobileNumber(phoneNumber);
        Email = email;
        CompanyName = companyName;
        TradeLicense = tradeLicense;
        UserName = userName;
        Password = password;
    }

    public static VehicleOwner buildFromDto(CreateVehicleOwnerRequest requestDto)
    {
        return new VehicleOwner(
            null,
            requestDto.Name!,
            requestDto.PhoneNumber!,
            requestDto.Email!, requestDto.CompanyName!,
            requestDto.TradeLicense!,
            requestDto.UserName!, 
            requestDto.Password!
        );
    }
}