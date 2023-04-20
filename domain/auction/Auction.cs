using dtos.auction;

namespace domain.auction;

public class Auction
{
    public string Id { get; set; }
    public string CargoOwnerId { get; set; }
    public string TypeOfCargo { get; set; }
    public int TotalWeightOfCargo { get; set; }
    public string DeliveryPlace { get; set; }
    public string PickUpPlace { get; set; }
    public DateTime PlannedPickUpDate { get; set; }
    public string OtherInformationAboutCargo { get; set; }
    public PriceInterval? PriceIntervalPerHundredKiloGram { get; set; }
    public DateTime CreatedAt { get; set; }
    public TimeSpan MinPickUpTime { get; set; }
    public TimeSpan MaxPickUpTime { get; set; }
    public Auction(
        string? id,
        string cargoOwnerId,
        string typeOfCargo, int totalWeightOfCargo,
        string deliveryPlace, string pickUpPlace,
        DateTime plannedPickUpDate,
        string otherInformationAboutCargo,
        string minPickUpTime,
        string maxPickUpTime,
        DateTime? createdAt,
        PriceInterval priceIntervalPerHundredKiloGram
    )
    {
        Id = id ?? Guid.NewGuid().ToString("N");
        CargoOwnerId = cargoOwnerId;
        TypeOfCargo = typeOfCargo;
        TotalWeightOfCargo = totalWeightOfCargo;
        DeliveryPlace = deliveryPlace;
        PickUpPlace = pickUpPlace;
        PlannedPickUpDate = plannedPickUpDate;
        OtherInformationAboutCargo = otherInformationAboutCargo;
        PriceIntervalPerHundredKiloGram = priceIntervalPerHundredKiloGram;
        MinPickUpTime = TimeSpan.Parse(minPickUpTime);
        MaxPickUpTime = TimeSpan.Parse(maxPickUpTime);
        CreatedAt = createdAt ?? DateTime.Now;
    }

    public Auction(
        string id,
        string cargoOwnerId,
        string typeOfCargo, int totalWeightOfCargo,
        string deliveryPlace, string pickUpPlace,
        DateTime plannedPickUpDate,
        string otherInformationAboutCargo,
        string minPickUpTime,
        string maxPickUpTime,
        DateTime? createdAt
    )
    {
        Id = id;
        CargoOwnerId = cargoOwnerId;
        TypeOfCargo = typeOfCargo;
        TotalWeightOfCargo = totalWeightOfCargo;
        DeliveryPlace = deliveryPlace;
        PickUpPlace = pickUpPlace;
        PlannedPickUpDate = plannedPickUpDate;
        OtherInformationAboutCargo = otherInformationAboutCargo;
        MinPickUpTime = TimeSpan.Parse(minPickUpTime);
        MaxPickUpTime = TimeSpan.Parse(maxPickUpTime);
        CreatedAt = createdAt ?? DateTime.Now;
    }

    public static Auction parseFromDto(SaveAuctionRequestDto requestDto)
    {
        return new Auction(
            string.IsNullOrEmpty(requestDto.Id) ? null : requestDto.Id,
            requestDto.CargoOwnerId!, requestDto.TypeOfCargo!,
            requestDto.TotalWeightOfCargo!, requestDto.DeliveryPlace!,
            requestDto.PickUpPlace!, requestDto.PlannedPickUpDate!,
            requestDto.OtherInformationAboutCargo!,
            requestDto.MinPickUpTime!,
            requestDto.MaxPickUpTime!,
            requestDto.CreatedAt,
            new PriceInterval(
                requestDto.MinPricePerHundredKiloGram,
                requestDto.MaxPricePerHundredKiloGram
            )
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

        var parsed = obj as Auction;

        if (
            this.Id.Equals(parsed?.Id) &&
            this.CargoOwnerId.Equals(parsed?.CargoOwnerId) &&
            this.TypeOfCargo.Equals(parsed?.TypeOfCargo) &&
            this.TotalWeightOfCargo.Equals(parsed?.TotalWeightOfCargo) &&
            this.DeliveryPlace.Equals(parsed?.DeliveryPlace) &&
            this.PickUpPlace.Equals(parsed?.PickUpPlace) &&
            this.PlannedPickUpDate.Equals(parsed.PlannedPickUpDate) &&
            this.OtherInformationAboutCargo.Equals(parsed.OtherInformationAboutCargo) &&
            this.PriceIntervalPerHundredKiloGram!.Equals(parsed.PriceIntervalPerHundredKiloGram) &&
            (this.CreatedAt - parsed!.CreatedAt).TotalSeconds < 5 &&
            this.MinPickUpTime!.Equals(parsed.MinPickUpTime) &&
            this.MaxPickUpTime!.Equals(parsed.MaxPickUpTime)
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