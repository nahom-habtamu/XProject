namespace dtos.cargoowner;

public class CreateCargoOwnerRequestDto
{
    public string? Name { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? SpecificAddress { get; set; }
    public string? TradeLicence { get; set; }
    public string? PointPersonName { get; set; }
    public string? PointPersonPhoneNumber { get; set; }
    public string? PointPersonSpecificAddress { get; set; }
    public string? PointPersonEmail { get; set; }
    public string? PointPersonPosition { get; set; }
}