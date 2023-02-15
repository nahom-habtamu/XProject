using domain.common;

namespace project_x_test.common;
public class PersonIdTest
{
    [Fact]
    public void ThrowsInvalidDataExceptionWhenPassedListIsNotEqualToTwoInlength()
    {
        var listOfImagesWithOneValue = new List<Uri> {
            new Uri("https://images.unsplash.com/photo-1671303286130-ff026be9407c?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxleHBsb3JlLWZlZWR8Mnx8fGVufDB8fHx8&auto=format&fit=crop&w=2000&q=60"),
        };
        var listOfImagesWithThreeValues = new List<Uri> {
            new Uri("https://images.unsplash.com/photo-1671303286130-ff026be9407c?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxleHBsb3JlLWZlZWR8Mnx8fGVufDB8fHx8&auto=format&fit=crop&w=2000&q=60"),
            new Uri("https://images.unsplash.com/photo-1671303286130-ff026be9407c?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxleHBsb3JlLWZlZWR8Mnx8fGVufDB8fHx8&auto=format&fit=crop&w=2000&q=60"),
            new Uri("https://images.unsplash.com/photo-1671303286130-ff026be9407c?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxleHBsb3JlLWZlZWR8Mnx8fGVufDB8fHx8&auto=format&fit=crop&w=2000&q=60"),
        };

        Assert.Throws<InvalidDataException>(() => new PersonId(listOfImagesWithOneValue));
        Assert.Throws<InvalidDataException>(() => new PersonId(listOfImagesWithThreeValues));
    }

    [Fact]
    public void SetsTheValueToItsPropetyWhenPassedListIsTwoInLength()
    {
        var listOfImagesWithTwoValues = new List<Uri> {
            new Uri("https://images.unsplash.com/photo-1671303286130-ff026be9407c?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxleHBsb3JlLWZlZWR8Mnx8fGVufDB8fHx8&auto=format&fit=crop&w=2000&q=60"),
            new Uri("https://images.unsplash.com/photo-1671303286130-ff026be9407c?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxleHBsb3JlLWZlZWR8Mnx8fGVufDB8fHx8&auto=format&fit=crop&w=2000&q=60"),
        };

        var id = new PersonId(listOfImagesWithTwoValues);
        Assert.Equal(id.Value.Count, listOfImagesWithTwoValues.Count);
    }
}