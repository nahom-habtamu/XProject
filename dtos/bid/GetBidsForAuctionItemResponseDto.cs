namespace dtos.bid;

public class GetBidsForAuctionItemResponseDto
{
    public string? Id { get; set; }
    public string? DriverId { get; set; }
    public string? DriverName { get; set; }
    public string? VehicleModel { get; set; }
    public double? VehicleRating { get; set; }
    public string? VehicleInsuranceImage { get; set; }
    public List<string> VehicleImages { get; set; } = new List<string>();
    public DateTime? VehicleManufaturedDate { get; set; }
}