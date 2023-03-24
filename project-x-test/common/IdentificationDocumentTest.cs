using domain.common;

namespace project_x_test.common;
public class IdentificationDocumentTest
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

    [Fact]
    public void ShouldReturnTrueWhenComparingIdentificationDocumentInstancesOfSameValue()
    {
        var document = new List<string> { "11d2dd123320olk000l.jpg", "11d2dd123320olk0002.jpg", };
        Assert.Equal(
            new IdentificationDocument(document).Equals(new IdentificationDocument(document)
        ), true);
    }

    [Fact]
    public void ShouldReturnFalseWhenComparingIdentificationDocumentInstancesOfDifferentPropertyValues()
    {
        var documentOne = new List<string> { "11d2dd123320olk000l.jpg", "11d2dd123320olk0002.jpg", };
        var documentTwo = new List<string> { "11d2dd123320olk0003.jpg", "11d2dd123320olk0004.jpg", };

        Assert.Equal(
            new IdentificationDocument(documentOne).Equals(new IdentificationDocument(documentTwo)
        ), false);
    }

    [Fact]
    public void ShouldReturnFalseWhenComparingWithNullValue()
    {
        var document = new List<string> { "11d2dd123320olk000l.jpg", "11d2dd123320olk0002.jpg", };
        Assert.Equal(new IdentificationDocument(document).Equals(null), false);
    }
}