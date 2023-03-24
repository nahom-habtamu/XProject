using domain.common;
using dtos.vehicle;

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
        public string CarImage { get; set; }
        public string LibreImage { get; set; }
        public string InsuranceImage { get; set; }
        public DateTime LibreExpiryDate { get; set; }
        public DateTime InsuranceExpiryDate { get; set; }
        public IdentificationDocument? DriverIdentificationDocument { get; set; }

        public Vehicle(
            string? id, string plateNumber, string ownerId,
            string driverId, string city, string type, string loadType,
            DateTime manufacturedDate, string make, string model, string loadCapacity,
            string color, string carImage, string libreImage, string insuranceImage,
            DateTime libreExpiryDate, DateTime insuranceExpiryDate, string driverDocument
        )
        {
            Id = id ?? Guid.NewGuid().ToString("N");
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
            DriverIdentificationDocument = new IdentificationDocument(
                new JsonListFormatter().Decode(driverDocument)
            );
            CarImage = carImage;
            LibreImage = libreImage;
            InsuranceImage = insuranceImage;
            LibreExpiryDate = libreExpiryDate;
            InsuranceExpiryDate = insuranceExpiryDate;
        }

        public static Vehicle parseFromDto(CreateVehicleRequestDto requestDto)
        {
            var jsonFormatter = new JsonListFormatter();
            return new Vehicle(
                null,
                requestDto.PlateNumber!,
                requestDto.OwnerId!,
                requestDto.DriverId!,
                requestDto.City!,
                requestDto.Type!,
                requestDto.LoadType!,
                requestDto.ManufacturedDate,
                requestDto.Make!,
                requestDto.Model!,
                requestDto.LoadCapacity!,
                requestDto.Color!,
                requestDto.CarImage!,
                requestDto.LibreImage!,
                requestDto.InsuranceImage!,
                requestDto.LibreExpiryDate,
                requestDto.InsuranceExpiryDate,
                jsonFormatter.Encode(
                    new List<string>{
                        requestDto.DriverIdentificationDocumentFront!,
                        requestDto.DriverIdentificationDocumentBack!,
                    }
                )
            );
        }
    }
}