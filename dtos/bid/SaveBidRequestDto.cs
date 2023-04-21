namespace dtos.bid;

public class SaveBidRequestDto
{
    public string? Id { get; set; }
    public string? AuctionId { get; set; }
    public string? DriverId { get; set; }
    public double PricePerKilogram { get; set; }
    public string? AdditionalInformation { get; set; }
    public DateTime? CreatedAt { get; set; }
}