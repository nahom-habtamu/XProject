namespace dtos.bid;

public class SaveBidRequestDto
{
    public string? AuctionId { get; set; }
    public string? DriverId { get; set; }
    public double PricePerKilogram { get; set; }
    public string? AdditionalInformation { get; set; }
}