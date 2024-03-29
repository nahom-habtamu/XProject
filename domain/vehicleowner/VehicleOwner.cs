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

    public static VehicleOwner buildFromDto(SaveVehicleOwnerRequestDto requestDto)
    {
        return new VehicleOwner(
            string.IsNullOrEmpty(requestDto.Id) ? null : requestDto.Id,
            requestDto.Name!,
            requestDto.PhoneNumber!,
            requestDto.Email!, requestDto.CompanyName!,
            requestDto.TradeLicense!,
            requestDto.UserName!,
            requestDto.Password!
        );
    }

    public override bool Equals(object? obj)
    {

        var jsonListFormatter = new JsonListFormatter();

        if (obj == null) return false;

        if (ReferenceEquals(obj, this))
            return false;

        if (obj.GetType() != this.GetType())
            return false;

        var parsed = obj as VehicleOwner;

        if (
            this.Id.Equals(parsed?.Id) &&
            this.Name.Equals(parsed?.Name) &&
            this.PhoneNumber.Equals(parsed?.PhoneNumber) &&
            this.Email.Equals(parsed?.Email) &&
            this.CompanyName.Equals(parsed?.CompanyName) &&
            jsonListFormatter.CheckEqualityOfJsonLists(this.TradeLicense, parsed!.TradeLicense) &&
            this.UserName.Equals(parsed.UserName) &&
            this.Password.Equals(parsed.Password)
        )
        {
            return true;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return this.Id.GetHashCode();
    }
}