using domain.vehicleowner;

namespace project_x_test.vehicleowner;
public class VehicleOwnerTest
{
    VehicleOwner ownerOne = new VehicleOwner(
        "2150df78-9132-44d8-9168-4f90e31616e1",
        "Vehicle Owner 1", "0926849881", "vo1@gmail.com", "VO1 Company",
        "['2150df78-9132-44d8-9168-4f90e31616e1.jpg','2150df78-9132-44d8-9168-4f90e31616e1.jpg']",
        "vehicleowner-1", "vehicleowner1pass"
    );

    [Fact]
    public void ShouldReturnTrueWhenComparingVehicleOwnerInstancesOfSameValue()
    {
        var ownerTwo = new VehicleOwner(
            "2150df78-9132-44d8-9168-4f90e31616e1",
            "Vehicle Owner 1", "0926849881", "vo1@gmail.com", "VO1 Company",
            "['2150df78-9132-44d8-9168-4f90e31616e1.jpg','2150df78-9132-44d8-9168-4f90e31616e1.jpg']",
            "vehicleowner-1", "vehicleowner1pass"
        );
        Assert.Equal(ownerOne, ownerTwo);
    }

    [Fact]
    public void ShouldReturnFalseWhenComparingVehicleOwnerInstancesOfDifferentPropertyValues()
    {
        var ownerTwo = new VehicleOwner(
            "2150df78-9132-44d8-9168-4f90e31616e2",
            "Vehicle Owner 2", "0926849882", "vo2@gmail.com", "VO2 Company",
            "['2150df78-9132-44d8-9168-4f90e31616e2.jpg','2150df78-9132-44d8-9168-4f90e31616e2.jpg']",
            "vehicleowner-2", "vehicleowner2pass"
        );

        Assert.NotEqual(ownerOne, ownerTwo);
    }

    [Fact]
    public void ShouldReturnFalseWhenComparingWithNullValue()
    {
        Assert.Equal(ownerOne.Equals(null), false);
    }
}