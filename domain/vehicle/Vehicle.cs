using System;
using domain.common;

namespace domain.vehicle
{
    public class Vehicle
    {
        public string Id { get; set; }
        public string PlateNumber { get; set; }
        public string OwnerId { get; set; }
        public string DriverId { get; set; }
        public string City { get; set; }
        public string Type { get; set; }
        public string LoadType { get; set; }
        public DateTime ManufacturedDate { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string LoadCapacity { get; set; }
        public string Color { get; set; }
        public PersonId DriverIdentificationDocument { get; set; }
        public Uri CarImage { get; set; }
        public Uri LibreImage { get; set; }
        public Uri InsuranceImage { get; set; }
        public DateTime LibreExpiryDate { get; set; }
        public DateTime InsuranceExpiryDate { get; set; }

        public Vehicle(
            string plateNumber, string ownerId, string driverId, string city,
            string type, string loadType, DateTime manufacturedDate,
            string make, string model, string loadCapacity,
            string color, PersonId driverIdentificationDocument, Uri carImage,
            Uri libreImage, Uri insuranceImage, DateTime libreExpiryDate,
            DateTime insuranceExpiryDate
        )
        {
            Id = Guid.NewGuid().ToString("N");
            PlateNumber = plateNumber;
            OwnerId = ownerId;
            DriverId = driverId;
            City = city;
            Type = type;
            LoadType = loadType;
            ManufacturedDate = manufacturedDate;
            Make = make;
            Model = model;
            LoadCapacity = loadCapacity;
            Color = color;
            DriverIdentificationDocument = driverIdentificationDocument;
            CarImage = carImage;
            LibreImage = libreImage;
            InsuranceImage = insuranceImage;
            LibreExpiryDate = libreExpiryDate;
            InsuranceExpiryDate = insuranceExpiryDate;
        }
    }
}