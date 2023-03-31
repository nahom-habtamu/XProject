namespace dtos.driver;

public class CreateDriverRequestDto
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? SpecificAddress { get; set; }
    public string? DrivingLicense { get; set; }
}