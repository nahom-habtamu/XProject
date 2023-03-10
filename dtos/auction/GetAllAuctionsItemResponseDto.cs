namespace dtos.auction;

public class GetAllAuctionsItemResponseDto
{
    public string? AuctionId { get; set; }
    public string? CompanyName { get; set; }
    public string? CargoOwnerId { get; set; }
    public string? CargoOwnerName { get; set; }
    public string? TypeOfCargo { get; set; }
    public double? WeightOfCargo { get; set; }
    public double MinPricePerHundredKiloGram { get; set; }
    public double MaxPricePerHundredKiloGram { get; set; }
    public TimeSpan MinPickUpTime { get; set; }
    public TimeSpan MaxPickUpTime { get; set; }
}