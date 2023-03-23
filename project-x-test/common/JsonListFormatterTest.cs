using domain.common;

namespace project_x_test.common;

public class JsonListFormatterTest
{
    [Fact]
    public void CheckingEqualityOfListsOfSameValuesShouldReturnTrue()
    {
        var jsonListFormatter = new JsonListFormatter();

        var stringOne = "[\"2150df78-9132-44d8-9168-4f90e31616e1.jpg\",\"2150df78-9132-44d8-9168-4f90e31616e1.jpg\"]";
        var stringTwo = "[\"2150df78-9132-44d8-9168-4f90e31616e1.jpg\",\"2150df78-9132-44d8-9168-4f90e31616e1.jpg\"]";

        Assert.True(jsonListFormatter.CheckEqualityOfJsonLists(stringOne, stringTwo));
    }

    [Fact]
    public void CheckingEqualityOfListsOfDiffrentValuesShouldReturnFalse()
    {
        var jsonListFormatter = new JsonListFormatter();

        var stringOne = "[\"2150df78-9132-44d8-9168-4f90e31616e1.jpg\",\"2150df78-9132-44d8-9168-4f90e31616e1.jpg\"]";
        var stringTwo = "[\"2150df78-9132-44d8-9168-4f90e31616e2.jpg\",\"2150df78-9132-44d8-9168-4f90e31616e1.jpg\"]";

        Assert.False(jsonListFormatter.CheckEqualityOfJsonLists(stringOne, stringTwo));
    }

    [Fact]
    public void EncodingListOfStringShouldReturnProperString()
    {
        var jsonListFormatter = new JsonListFormatter();

        var actual = jsonListFormatter.Encode(new List<string> {
            "2150df78-9132-44d8-9168-4f90e31616e1.jpg",
            "2150df78-9132-44d8-9168-4f90e31616e1.jpg"
        });

        var expected = "[\"2150df78-9132-44d8-9168-4f90e31616e1.jpg\",\"2150df78-9132-44d8-9168-4f90e31616e1.jpg\"]";
        Assert.Equal(actual, expected);

    }

    [Fact]
    public void DecodingStringShouldReturnProperList()
    {
        var jsonListFormatter = new JsonListFormatter();

        var actual = jsonListFormatter.Decode("[\"2150df78-9132-44d8-9168-4f90e31616e1.jpg\",\"2150df78-9132-44d8-9168-4f90e31616e1.jpg\"]");
        var expected = new List<string> {
            "2150df78-9132-44d8-9168-4f90e31616e1.jpg",
            "2150df78-9132-44d8-9168-4f90e31616e1.jpg"
        };

        Assert.True(actual.First().Equals(expected.First()));
        Assert.True(actual.Last().Equals(expected.Last()));

    }
}