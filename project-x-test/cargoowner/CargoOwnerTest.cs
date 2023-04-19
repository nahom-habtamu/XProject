using domain.cargoowner;

namespace project_x_test.cargoowner;
public class CargoOwnerTest
{
    CargoOwner cargoOwnerOne = new CargoOwner(
        "4650df78-9132-44d8-9168-4f90e31616e1",
        "Nahom", "0926849888", "nahomhab2626@gmail.com", "Specific Address", "asasasasasasasa.jpg", "username", "password",
        "abebe", "0911041221", "address", "abebe@gmail.com", "position"
    );

    [Fact]
    public void ShouldReturnTrueWhenComparingCargoOwnerInstancesOfSameValue()
    {
        var cargoOwnerTwo = new CargoOwner(
            "4650df78-9132-44d8-9168-4f90e31616e1",
            "Nahom", "0926849888", "nahomhab2626@gmail.com", "Specific Address", "asasasasasasasa.jpg", "username", "password",
            "abebe", "0911041221", "address", "abebe@gmail.com", "position"
        );
        Assert.Equal(cargoOwnerOne, cargoOwnerTwo);
    }

    [Fact]
    public void ShouldReturnFalseWhenComparingCargoOwnerInstancesOfDifferentPropertyValues()
    {
        var cargoOwnerTwo = new CargoOwner(
            "4650df78-9132-44d8-9168-4f90e31616e2",
            "Nahom", "0926849888", "nahomhab2626@gmail.com", "Specific Address", "asasasasasasasa.jpg", "username", "password",
            "abebe", "0911041221", "address", "abebe@gmail.com", "position"
        );
        Assert.NotEqual(cargoOwnerOne, cargoOwnerTwo);
    }

    [Fact]
    public void ShouldReturnFalseWhenComparingWithNullValue()
    {
        Assert.Equal(cargoOwnerOne.Equals(null), false);
    }
}