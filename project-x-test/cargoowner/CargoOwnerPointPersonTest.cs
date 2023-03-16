using domain.cargoowner;

namespace project_x_test.cargoowner;
public class CargoOwnerPointPersonTest
{
    CargoOwnerPointPerson pointPersonOne = new CargoOwnerPointPerson(
        "position", "abebe", "0911041221", "address", "abebe@gmail.com"
    );

    [Fact]
    public void ShouldReturnTrueWhenComparingCargoOwnerInstancesOfSameValue()
    {
        var pointPersonTwo = new CargoOwnerPointPerson(
            "position", "abebe", "0911041221", "address", "abebe@gmail.com"
        );
        Assert.Equal(pointPersonOne, pointPersonTwo);
    }

    [Fact]
    public void ShouldReturnFalseWhenComparingCargoOwnerInstancesOfDifferentPropertyValues()
    {
        var pointPersonTwo = new CargoOwnerPointPerson(
            "position1", "abebed", "0911041220", "addresss", "daabebe@gmail.com"
        );
        Assert.NotEqual(pointPersonOne, pointPersonTwo);
    }

    [Fact]
    public void ShouldReturnFalseWhenComparingWithNullValue()
    {
        Assert.Equal(pointPersonOne.Equals(null), false);
    }
}