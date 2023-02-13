using System;
using domain.common;

namespace domain.vehicle
{
    public class Vehicle
    {
        public string? Id { get; set; }
        public string? PlateNumber { get; set; }
        public string? OwnerId { get; set; }
        public string? City { get; set; }
        public string? Type { get; set; }
        public string? LoadType { get; set; }
        public DateTime ManufacturedDate { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public string? LoadCapacity { get; set; }
        public string? Color { get; set; }
        public PersonId? DriverId { get; set; }
        public Uri? CarImage { get; set; }
        public Uri? LibreImage { get; set; }
        public Uri? InsuranceImage { get; set; }
        public DateTime LibreExpiryDate { get; set; }
        public DateTime InsuranceExpiryDate { get; set; }
    }
}