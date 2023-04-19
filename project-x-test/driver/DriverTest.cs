using domain.driver;

namespace project_x_test.driver;
public class DriverTest
{
    Driver driverOne = new Driver(
        "7210df78-9132-44d8-9168-4f90e31616e1",
        "Nahom Habtamu", "0926849888", "nahom@gmail.com", "0",
        new DateTime(2023, 10, 9), "I dont know the address",
        "1250df78-9132-44d8-9168-4f90e31616e4.png","username","password"
    );

    [Fact]
    public void ShouldReturnTrueWhenComparingDriverInstancesOfSameValue()
    {
        Driver driverTwo = new Driver(
            "7210df78-9132-44d8-9168-4f90e31616e1",
            "Nahom Habtamu", "0926849888", "nahom@gmail.com", "0",
            new DateTime(2023, 10, 9), "I dont know the address",
            "1250df78-9132-44d8-9168-4f90e31616e4.png","username","password"
        );
        Assert.Equal(driverOne, driverTwo);
    }

    [Fact]
    public void ShouldReturnFalseWhenComparingDriverInstancesOfDifferentPropertyValues()
    {
        Driver driverTwo = new Driver(
            "7210df78-9132-44d8-9168-4f90e31616e2",
            "Gagim Habtamu", "0926849888", "nahom@gmail.com", "0",
            new DateTime(2023, 10, 9), "I dont know the address", 
            "1250df78-9132-44d8-9168-4f90e31616e4.png","username","password"
        );
        
        Assert.NotEqual(driverOne, driverTwo);
    }

    [Fact]
    public void ShouldReturnFalseWhenComparingWithNullValue()
    {
        Assert.Equal(driverOne.Equals(null), false);
    }
}