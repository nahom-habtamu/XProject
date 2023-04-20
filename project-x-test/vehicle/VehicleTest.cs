using domain.vehicle;

namespace project_x_test.vehicle;
public class VehicleTest
{
    Vehicle vehicleOne = new Vehicle(
        "3190df78-9132-44d8-9168-4f90e31616e1", "00000",
        "2150df78-9132-44d8-9168-4f90e31616e1", "7210df78-9132-44d8-9168-4f90e31616e1",
        "Addis Ababa", "SOME_VEHICLE_TYPE", "SOME_LOAD_TYPE", DateTime.Parse("04-05-2022"),
        "Make 1", "Model 1", "266KG", "Green", "7210df78-9132-44d8-9168-4f90e31616.jpg",
        "3210df78-9132-44d8-9168-4f90e31616.jpg", "5210df78-9132-44d8-9168-4f90e31616.jpg",
        DateTime.Parse("03-05-2023"), DateTime.Parse("08-05-2023"), DateTime.Parse("2023-04-20 11:43:00"),
        "[\"x8-9132-44d8-9168-4f90e31616e1.jpg\",\"x8-9132-44d8-9168-4f90e31616e1.jpg\"]"
    );

    [Fact]
    public void ShouldReturnTrueWhenComparingVehicleInstancesOfSameValue()
    {
        Vehicle vehicleTwo = new Vehicle(
            "3190df78-9132-44d8-9168-4f90e31616e1", "00000",
            "2150df78-9132-44d8-9168-4f90e31616e1", "7210df78-9132-44d8-9168-4f90e31616e1",
            "Addis Ababa", "SOME_VEHICLE_TYPE", "SOME_LOAD_TYPE", DateTime.Parse("04-05-2022"),
            "Make 1", "Model 1", "266KG", "Green", "7210df78-9132-44d8-9168-4f90e31616.jpg",
            "3210df78-9132-44d8-9168-4f90e31616.jpg", "5210df78-9132-44d8-9168-4f90e31616.jpg",
            DateTime.Parse("03-05-2023"), DateTime.Parse("08-05-2023"),DateTime.Parse("2023-04-20 11:43:00"),
            @"[
                'x8-9132-44d8-9168-4f90e31616e1.jpg',
                'x8-9132-44d8-9168-4f90e31616e1.jpg'    
            ]"
        );
        Assert.Equal(vehicleOne, vehicleTwo);
    }

    [Fact]
    public void ShouldReturnFalseWhenComparingVehicleInstancesOfDifferentPropertyValues()
    {
        Vehicle vehicleTwo = new Vehicle(
            "3190df78-9132-44d8-9168-4f90e31616e2", "00003",
            "2150df78-9132-44d8-9168-4f90e31616e3", "7210df78-9132-44d8-9168-4f90e31616e1",
            "Addis Ababa", "SOME_VEHICLE_TYPE", "SOME_LOAD_TYPE_0", DateTime.Parse("04-05-2022"),
            "Make 1", "Model 1", "266KG", "Green", "7210df78-9132-44d8-9168-4f90e31616.jpg",
            "3210df78-9132-44d8-9168-4f90e31616.jpg", "5210df78-9132-44d8-9168-4f90e31616.jpg",
            DateTime.Parse("03-05-2023"), DateTime.Parse("08-05-2023"), DateTime.Parse("2023-04-20 11:49:00"),
            "[\"x8-9132-44d8-9168-4f90e31616e1.jpg\",\"x8-9132-44d8-9168-4f90e31616e1.jpg\"]"
        );

        Assert.NotEqual(vehicleOne, vehicleTwo);
    }

    [Fact]
    public void ShouldReturnFalseWhenComparingWithNullValue()
    {
        Assert.Equal(vehicleOne.Equals(null), false);
    }
}