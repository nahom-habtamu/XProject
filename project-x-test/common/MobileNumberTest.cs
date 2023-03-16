using domain.common;

namespace project_x_test.common;
public class MobileNumberTest
{
    [Fact]
    public void ThrowsInvalidDataExceptionWhenInputDoesntMatchRegexSpecified()
    {
        string invalidPhoneNumberValue = "0925-=266767";
        Assert.Throws<InvalidDataException>(() => new MobileNumber(invalidPhoneNumberValue));
    }

    [Fact]
    public void SetsTheValueToItsPropetyWhenInputMatchesRegexSpecified()
    {
        string correctPhoneNumberValue = "0926849888";
        var phoneNumber = new MobileNumber(correctPhoneNumberValue);
        Assert.Equal(phoneNumber.Value, correctPhoneNumberValue);
    }

    [Fact]
    public void ShouldReturnTrueWhenComparingCargoOwnerInstancesOfSameValue()
    {
        Assert.Equal(
            new MobileNumber("0926849888").Equals(new MobileNumber("0926849888")
        ), true);
    }

    [Fact]
    public void ShouldReturnFalseWhenComparingCargoOwnerInstancesOfDifferentPropertyValues()
    {
        Assert.Equal(
            new MobileNumber("0926849888").Equals(new MobileNumber("0926849880")
        ), false);
    }

    [Fact]
    public void ShouldReturnFalseWhenComparingWithNullValue()
    {
        Assert.Equal(new MobileNumber("0926849888").Equals(null), false);
    }
}