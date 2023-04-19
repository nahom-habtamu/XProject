using domain.common;
using dtos.cargoowner;

namespace domain.cargoowner;
public class CargoOwner
{
    public string Id { get; set; }
    public string Name { get; set; }
    public MobileNumber PhoneNumber { get; set; }
    public string Email { get; set; }
    public string SpecificAddress { get; set; }
    public string TradeLicense { get; set; }
    public string PointPersonName { get; set; }
    public MobileNumber PointPersonPhoneNumber { get; set; }
    public string PointPersonSpecificAddress { get; set; }
    public string PointPersonEmail { get; set; }
    public string PointPersonPosition { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }

    public CargoOwner(
        string? id,
        string name,
        string phoneNumber,
        string email,
        string specificAddress,
        string tradeLicense,
        string userName,
        string password,
        string pointPersonName,
        string pointPersonPhoneNumber,
        string pointPersonSpecificAddress,
        string pointPersonEmail,
        string pointPersonPosition
    )
    {
        Id = id ?? Guid.NewGuid().ToString("N");
        Name = name;
        PhoneNumber = new MobileNumber(phoneNumber);
        Email = email;
        SpecificAddress = specificAddress;
        TradeLicense = tradeLicense;
        UserName = userName;
        Password = password;
        PointPersonEmail = pointPersonEmail;
        PointPersonName = pointPersonName;
        PointPersonPhoneNumber = new MobileNumber(pointPersonPhoneNumber);
        PointPersonSpecificAddress = pointPersonSpecificAddress;
        PointPersonPosition = pointPersonPosition;
    }

    public static CargoOwner parseFromDto(SaveCargoOwnerRequestDto requestDto)
    {
        return new CargoOwner(
            string.IsNullOrEmpty(requestDto.Id) ? null : requestDto.Id,
            requestDto.Name!,
            requestDto.PhoneNumber!,
            requestDto.Email!,
            requestDto.SpecificAddress!,
            requestDto.TradeLicense!,
            requestDto.UserName!,
            requestDto.Password!,
            requestDto.PointPersonName!,
            requestDto.PointPersonPhoneNumber!,
            requestDto.PointPersonSpecificAddress!,
            requestDto.PointPersonEmail!,
            requestDto.PointPersonPosition!
        );
    }

    public override bool Equals(object? obj)
    {
        if (obj == null)
            return false;

        if (ReferenceEquals(obj, this))
            return false;

        if (obj.GetType() != this.GetType())
            return false;

        var parsed = obj as CargoOwner;

        if (
            this.Id.Equals(parsed?.Id) &&
            this.Email.Equals(parsed.Email) &&
            this.Name.Equals(parsed.Name) &&
            this.PhoneNumber.Equals(parsed.PhoneNumber) &&
            this.TradeLicense.Equals(parsed.TradeLicense) &&
            this.UserName.Equals(parsed.UserName) &&
            this.Password.Equals(parsed.Password) &&
            this.SpecificAddress.Equals(parsed.SpecificAddress) &&
            this.PointPersonName.Equals(parsed?.PointPersonName) &&
            this.PointPersonEmail.Equals(parsed.PointPersonEmail) &&
            this.PointPersonPhoneNumber.Equals(parsed.PointPersonPhoneNumber) &&
            this.PointPersonSpecificAddress.Equals(parsed.PointPersonSpecificAddress) &&
            this.PointPersonPosition.Equals(parsed.PointPersonPosition)
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