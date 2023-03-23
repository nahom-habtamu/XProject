using Newtonsoft.Json;

namespace domain.common;

public class JsonListFormatter
{
    public List<string> Decode(string plainString)
    {
        return decodeStringToListOfString(plainString);
    }

    public bool CheckEqualityOfJsonLists(string str1, string str2)
    {
        var str1Splitted = decodeStringToListOfString(str1);
        var str2Splitted = decodeStringToListOfString(str2);

        var isStr1SubSetOfStr2 = str1Splitted
            .Where(tl => str2Splitted
            .Contains(tl))
            .Count() == str1Splitted.Count;

        var isStr2SubSetOfStr1 = str2Splitted
            .Where(tl => str1Splitted
            .Contains(tl))
            .Count() == str2Splitted.Count;

        var isEqualInLength = str1Splitted.Count == str2Splitted.Count;

        return isStr1SubSetOfStr2 && isStr2SubSetOfStr1 && isEqualInLength;
    }

    private List<string> decodeStringToListOfString(string plainString)
    {
        var deserialized = JsonConvert.DeserializeObject<List<String>>(plainString);
        if (deserialized == null) throw new InvalidCastException();
        return deserialized;
    }

    public string Encode(List<string> decodedString)
    {
        return JsonConvert.SerializeObject(decodedString);
    }
}