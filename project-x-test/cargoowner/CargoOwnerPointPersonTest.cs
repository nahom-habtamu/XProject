using domain.cargoowner;

namespace project_x_test.cargoowner;
public class CargoOwnerPointPersonTest
{
    [Fact]
    public void ShouldReturnTrueWhenComparingCargoOwnerInstancesOfSameValue()
    {
        var pointPersonOne = new CargoOwnerPointPerson(
            "position", "abebe", "0911041221", "address", "abebe@gmail.com"
        );
        var pointPersonTwo = new CargoOwnerPointPerson(
            "position", "abebe", "0911041221", "address", "abebe@gmail.com"
        );

        Assert.Equal(pointPersonOne.Equals(pointPersonTwo), true);
    }

    [Fact]
    public void ShouldReturnFalseWhenComparingCargoOwnerInstancesOfDifferentPropertyValues()
    {
        var pointPersonOne = new CargoOwnerPointPerson(
            "position", "abebe", "0911041221", "address", "abebe@gmail.com"
        );
        var pointPersonTwo = new CargoOwnerPointPerson(
            "position1", "abebe", "0911041221", "address", "abebe@gmail.com"
        );
        Assert.Equal(pointPersonOne.Equals(pointPersonTwo), false);
    }

    [Fact]
    public void ShouldReturnFalseWhenComparingWithNullValue()
    {
        var pointPersonOne = new CargoOwnerPointPerson(
            "position", "abebe", "0911041221", "address", "abebe@gmail.com"
        );
        Assert.Equal(pointPersonOne.Equals(null), false);
    }
}