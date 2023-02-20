namespace domain.bid;

public class Bid
{
    public string Id { get; set; }
    public string AuctionId { get; set; }
    public string DriverId { get; set; }
    public double PricePerKilogram { get; set; }
    public string AdditionalInformation { get; set; }
    public Bid(
        string auctionId, 
        string driverId, 
        double pricePerKilogram, 
        string additionalInformation
    )
    {
        Id = Guid.NewGuid().ToString("N");
        AuctionId = auctionId;
        DriverId = driverId;
        PricePerKilogram = pricePerKilogram;
        AdditionalInformation = additionalInformation;
    }    
}