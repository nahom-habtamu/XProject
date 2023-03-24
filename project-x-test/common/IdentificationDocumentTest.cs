using domain.common;

namespace project_x_test.common;
public class PersonIdTest
{
    [Fact]
    public void ThrowsInvalidDataExceptionWhenPassedListIsNotEqualToTwoInlength()
    {
        var listOfImagesWithOneValue = new List<string> {
           "1671303286130-ff026be9407c.jpg",
        };
        var listOfImagesWithThreeValues = new List<string> {
           "1671303286130-ff026be9407c.png",
           "1671303286130-ff026be9407c.jpg",
           "1671303286130-ff026be9407c.jpg",
        };

        Assert.Throws<InvalidDataException>(() => new IdentificationDocument(listOfImagesWithOneValue));
        Assert.Throws<InvalidDataException>(() => new IdentificationDocument(listOfImagesWithThreeValues));
    }

    [Fact]
    public void SetsTheValueToItsPropetyWhenPassedListIsTwoInLength()
    {
        var listOfImagesWithTwoValues = new List<string> {
           "1671303286130-ff026be9407c.jpg",
           "1671303286130-ff026be9407c.jpg",
        };

        var id = new IdentificationDocument(listOfImagesWithTwoValues);
        Assert.Equal(id.Value.Count, listOfImagesWithTwoValues.Count);
    }
}