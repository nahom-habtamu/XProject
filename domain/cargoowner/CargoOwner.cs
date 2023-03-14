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
    public CargoOwnerPointPerson? PointPerson { get; set; }

    public CargoOwner(
        string name,
        string phoneNumber,
        string email,
        string specificAddress,
        string tradeLicense,
        CargoOwnerPointPerson pointPerson,
        string? id = null
    )
    {
        Id = id ?? Guid.NewGuid().ToString("N");
        Name = name;
        PhoneNumber = new MobileNumber(phoneNumber);
        Email = email;
        SpecificAddress = specificAddress;
        TradeLicense = tradeLicense;
        PointPerson = pointPerson;
    }

    public CargoOwner(
        string id,
        string name,
        string phoneNumber,
        string email,
        string specificAddress,
        string tradeLicense
    )
    {
        Id = id;
        Name = name;
        PhoneNumber = new MobileNumber(phoneNumber);
        Email = email;
        SpecificAddress = specificAddress;
        TradeLicense = tradeLicense;
    }

    public static CargoOwner parseFromDto(CreateCargoOwnerRequestDto requestDto)
    {
        return new CargoOwner(
            requestDto.Name!,
            requestDto.PhoneNumber!,
            requestDto.Email!,
            requestDto.SpecificAddress!,
            requestDto.TradeLicense!,
            new CargoOwnerPointPerson(
                requestDto.PointPersonPosition!,
                requestDto.PointPersonName!,
                requestDto.PointPersonPhoneNumber!,
                requestDto.PointPersonSpecificAddress!,
                requestDto.PointPersonEmail!
            )
        );
    }
}