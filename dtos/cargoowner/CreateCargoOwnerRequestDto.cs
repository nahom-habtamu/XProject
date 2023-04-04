namespace dtos.cargoowner;

public class SaveCargoOwnerRequestDto
{
    public string? Name { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? SpecificAddress { get; set; }
    public string? TradeLicense { get; set; }
    public string? PointPersonName { get; set; }
    public string? PointPersonPhoneNumber { get; set; }
    public string? PointPersonSpecificAddress { get; set; }
    public string? PointPersonEmail { get; set; }
    public string? PointPersonPosition { get; set; }
}