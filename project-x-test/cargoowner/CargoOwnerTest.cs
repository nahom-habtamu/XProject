using domain.cargoowner;

namespace project_x_test.cargoowner;
public class CargoOwnerTest
{
    [Fact]
    public void ShouldReturnTrueWhenComparingCargoOwnerInstancesOfSameValue()
    {
        var cargoOwnerOne = new CargoOwner(
            "Nahom", "0926849888", "nahomhab2626@gmail.com", "Specific Address", "asasasasasasasa.jpg",
            new CargoOwnerPointPerson("position", "abebe", "0911041221", "address", "abebe@gmail.com"),
            "4650df78-9132-44d8-9168-4f90e31616e1"
        );

        var cargoOwnerTwo = new CargoOwner(
            "Nahom", "0926849888", "nahomhab2626@gmail.com", "Specific Address", "asasasasasasasa.jpg",
            new CargoOwnerPointPerson("position", "abebe", "0911041221", "address", "abebe@gmail.com"),
            "4650df78-9132-44d8-9168-4f90e31616e1"
        );

        Assert.Equal(cargoOwnerOne.Equals(cargoOwnerTwo), true);

    }

    [Fact]
    public void ShouldReturnFalseWhenComparingCargoOwnerInstancesOfDifferentPropertyValues()
    {
        var cargoOwnerOne = new CargoOwner(
            "Nahom", "0926849888", "nahomhab2626@gmail.com", "Specific Address", "asasasasasasasa.jpg",
            new CargoOwnerPointPerson("position", "abebe", "0911041221", "address", "abebe@gmail.com"),
            "4650df78-9132-44d8-9168-4f90e31616e1"
        );

        var cargoOwnerTwo = new CargoOwner(
            "Nahom", "0926849888", "nahomhab2626@gmail.com", "Specific Address", "asasasasasasasa.jpg",
            new CargoOwnerPointPerson("position", "abebe", "0911041221", "address", "abebe@gmail.com"),
            "4650df78-9132-44d8-9168-4f90e31616e2"
        );

        Assert.Equal(cargoOwnerOne.Equals(cargoOwnerTwo), false);
    }

    [Fact]
    public void ShouldReturnFalseWhenComparingWithNullValue()
    {
        var cargoOwnerOne = new CargoOwner(
            "NahomAbbee", "0926849888", "nahomhab2626@gmail.com", "Specific Address", "asasasasasasasa.jpg",
            new CargoOwnerPointPerson("position", "abebe", "0911041221", "address", "abebe@gmail.com"),
            "4650df78-9132-44d8-9168-4f90e31616e1"
        );
        Assert.Equal(cargoOwnerOne.Equals(null), false);
    }
}