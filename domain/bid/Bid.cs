using dtos.bid;

namespace domain.bid;

public class Bid
{
    public string Id { get; set; }
    public string AuctionId { get; set; }
    public string DriverId { get; set; }
    public double PricePerKilogram { get; set; }
    public string AdditionalInformation { get; set; }
    public DateTime CreatedAt { get; set; }

    public Bid(
        string? id,
        string auctionId,
        string driverId,
        double pricePerKilogram,
        string additionalInformation,
        DateTime? createdAt
    )
    {
        Id = id ?? Guid.NewGuid().ToString("N");
        AuctionId = auctionId;
        DriverId = driverId;
        PricePerKilogram = pricePerKilogram;
        AdditionalInformation = additionalInformation;
        CreatedAt = createdAt ?? DateTime.Now;
    }

    public static Bid parseFromDto(SaveBidRequestDto requestDto)
    {
        return new Bid(
            string.IsNullOrEmpty(requestDto.Id) ? null : requestDto.Id,
            requestDto.AuctionId!,
            requestDto.DriverId!,
            requestDto.PricePerKilogram,
            requestDto.AdditionalInformation!,
            requestDto.CreatedAt
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

        var parsed = obj as Bid;

        if (
            this.Id.Equals(parsed?.Id) &&
            this.DriverId.Equals(parsed?.DriverId) &&
            this.AuctionId.Equals(parsed?.AuctionId) &&
            this.AdditionalInformation.Equals(parsed?.AdditionalInformation) &&
            this.PricePerKilogram.Equals(parsed?.PricePerKilogram) &&
            this.CreatedAt.Equals(parsed?.CreatedAt)
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