using Microsoft.AspNetCore.Http;
namespace dtos.vehicle;

public class CreateVehicleRequestDto
{
    public string? PlateNumber { get; set; }
    public string? OwnerId { get; set; }
    public string? DriverId { get; set; }
    public string? City { get; set; }
    public string? Type { get; set; }
    public string? LoadType { get; set; }
    public DateTime ManufacturedDate { get; set; }
    public string? Make { get; set; }
    public string? Model { get; set; }
    public string? LoadCapacity { get; set; }
    public string? Color { get; set; }
    public DateTime LibreExpiryDate { get; set; }
    public DateTime InsuranceExpiryDate { get; set; }
    public string? DriverIdentificationDocumentFront { get; set; }
    public string? DriverIdentificationDocumentBack { get; set; }
    public string? CarImage { get; set; }
    public string? LibreImage { get; set; }
    public string? InsuranceImage { get; set; }
}