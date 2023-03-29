using dtos.bid;

namespace domain.bid;

public class Bid
{
    public string Id { get; set; }
    public string AuctionId { get; set; }
    public string DriverId { get; set; }
    public double PricePerKilogram { get; set; }
    public string AdditionalInformation { get; set; }
    public Bid(
        string? id,
        string auctionId,
        string driverId,
        double pricePerKilogram,
        string additionalInformation
    )
    {
        Id = id ?? Guid.NewGuid().ToString("N");
        AuctionId = auctionId;
        DriverId = driverId;
        PricePerKilogram = pricePerKilogram;
        AdditionalInformation = additionalInformation;
    }

    public static Bid parseFromDto(CreateBidRequestDto requestDto)
    {
        return new Bid(
            null,
            requestDto.AuctionId!,
            requestDto.DriverId!,
            requestDto.PricePerKilogram,
            requestDto.AdditionalInformation!
        );
    }
}