using System.IO;
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
}