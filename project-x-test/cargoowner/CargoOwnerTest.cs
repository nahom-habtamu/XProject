using domain.cargoowner;

namespace project_x_test.cargoowner;
public class CargoOwnerTest
{
    CargoOwner cargoOwnerOne = new CargoOwner(
        "Nahom", "0926849888", "nahomhab2626@gmail.com", "Specific Address", "asasasasasasasa.jpg",
        new CargoOwnerPointPerson("position", "abebe", "0911041221", "address", "abebe@gmail.com"),
        "4650df78-9132-44d8-9168-4f90e31616e1"
    );

    [Fact]
    public void ShouldReturnTrueWhenComparingCargoOwnerInstancesOfSameValue()
    {
        var cargoOwnerTwo = new CargoOwner(
            "Nahom", "0926849888", "nahomhab2626@gmail.com", "Specific Address", "asasasasasasasa.jpg",
            new CargoOwnerPointPerson("position", "abebe", "0911041221", "address", "abebe@gmail.com"),
            "4650df78-9132-44d8-9168-4f90e31616e1"
        );
        Assert.Equal(cargoOwnerOne, cargoOwnerTwo);
    }

    [Fact]
    public void ShouldReturnFalseWhenComparingCargoOwnerInstancesOfDifferentPropertyValues()
    {
        var cargoOwnerTwo = new CargoOwner(
            "Nahom", "0926849888", "nahomhab2626@gmail.com", "Specific Address", "asasasasasasasa.jpg",
            new CargoOwnerPointPerson("position", "abebe", "0911041221", "address", "abebe@gmail.com"),
            "4650df78-9132-44d8-9168-4f90e31616e2"
        );
        Assert.NotEqual(cargoOwnerOne, cargoOwnerTwo);
    }

    [Fact]
    public void ShouldReturnFalseWhenComparingWithNullValue()
    {
        Assert.Equal(cargoOwnerOne.Equals(null), false);
    }
}