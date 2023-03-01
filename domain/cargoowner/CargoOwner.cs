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
    public string TradeLicence { get; set; }
    public CargoOwnerPointPerson PointPerson { get; set; }

    public CargoOwner(
        string name,
        MobileNumber phoneNumber,
        string email,
        string specificAddress,
        string tradeLicence,
        CargoOwnerPointPerson pointPerson,
        string? id = null
    )
    {
        Id = id ?? Guid.NewGuid().ToString("N");
        Name = name;
        PhoneNumber = phoneNumber;
        Email = email;
        SpecificAddress = specificAddress;
        TradeLicence = tradeLicence;
        PointPerson = pointPerson;
    }

    public static CargoOwner parseFromDto(CreateCargoOwnerRequestDto requestDto)
    {
        return new CargoOwner(
            requestDto.Name!,
            new MobileNumber(requestDto.PhoneNumber!),
            requestDto.Email!,
            requestDto.SpecificAddress!,
            requestDto.TradeLicence!,
            new CargoOwnerPointPerson(
                requestDto.PointPersonName!,
                new MobileNumber(requestDto.PointPersonPhoneNumber!),
                requestDto.PointPersonSpecificAddress!,
                requestDto.PointPersonEmail!,
                requestDto.PointPersonPosition!
            )
        );
    }
}