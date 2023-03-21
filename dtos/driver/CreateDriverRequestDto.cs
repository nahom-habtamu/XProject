namespace dtos.driver;

public class CreateDriverRequestDto
{
    public string? Name { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public int Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? Address { get; set; }
    public string? DrivingLicense { get; set; }
}