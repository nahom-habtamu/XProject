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
    public PickUpTimeInterval? PickUpTimeInterval { get; set; }
    public Auction(
        string cargoOwnerId,
        string typeOfCargo, int totalWeightOfCargo,
        string deliveryPlace, string pickUpPlace,
        DateTime plannedPickUpDate,
        string otherInformationAboutCargo,
        PriceInterval priceIntervalPerHundredKiloGram,
        PickUpTimeInterval pickUpTimeInterval,
        string? id = null
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
        PickUpTimeInterval = pickUpTimeInterval;
    }

    public Auction(
        string id,
        string cargoOwnerId,
        string typeOfCargo, int totalWeightOfCargo,
        string deliveryPlace, string pickUpPlace,
        DateTime plannedPickUpDate,
        string otherInformationAboutCargo
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
    }

    public static Auction parseFromDto(CreateAuctionRequestDto requestDto)
    {
        return new Auction(requestDto.CargoOwnerId!, requestDto.TypeOfCargo!,
            requestDto.TotalWeightOfCargo!, requestDto.DeliveryPlace!,
            requestDto.PickUpPlace!, requestDto.PlannedPickUpDate!,
            requestDto.OtherInformationAboutCargo!,
            new PriceInterval(requestDto.MinPricePerHundredKiloGram, requestDto.MaxPricePerHundredKiloGram),
            new PickUpTimeInterval(requestDto.MinPickUpTime!, requestDto.MaxPickUpTime!)
        );
    }
}