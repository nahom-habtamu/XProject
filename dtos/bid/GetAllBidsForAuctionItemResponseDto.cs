namespace dtos.bid;

public class GetAllBidsForAuctionItemResponseDto
{
    public string? DriverId { get; set; }
    public string? DriverName { get; set; }
    public string? VehicleModel { get; set; }
    public double? VehicleRating { get; set; }
    public Uri? VehicleInsuranceImage { get; set; }
    public List<Uri> VehicleImages { get; set; } = new List<Uri>();
    public DateTime? VehicleManufaturedDate { get; set; }
}