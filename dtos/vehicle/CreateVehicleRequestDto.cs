using Microsoft.AspNetCore.Http;
namespace persistence.vehicle.dtos;

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
    public IFormFile? DriverIdentificationDocumentFront { get; set; }
    public IFormFile? DriverIdentificationDocumentBack { get; set; }
    public IFormFile? CarImage { get; set; }
    public IFormFile? LibreImage { get; set; }
    public IFormFile? InsuranceImage { get; set; }
}