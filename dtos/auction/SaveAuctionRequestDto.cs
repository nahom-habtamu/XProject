namespace dtos.auction;

public class SaveAuctionRequestDto {
    public string? CargoOwnerId { get; set; }
    public string? TypeOfCargo { get; set; }
    public int TotalWeightOfCargo { get; set; }
    public string? DeliveryPlace { get; set; }
    public string? PickUpPlace { get; set; }
    public DateTime PlannedPickUpDate { get; set; }
    public double MinPricePerHundredKiloGram { get; set; }
    public double MaxPricePerHundredKiloGram { get; set; }
    public string? MinPickUpTime { get; set; }
    public string? MaxPickUpTime { get; set; }
    public string? OtherInformationAboutCargo { get; set; }
}
