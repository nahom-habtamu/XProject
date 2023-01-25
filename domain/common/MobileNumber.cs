using System.IO;
using System.Text.RegularExpressions;

namespace domain.common;
public class MobileNumber
{
    public string Value { get; }
    public MobileNumber(string number)
    {
        const string pattern = @"^(\+|0)(?:[0-9] ?){6,14}[0-9]$";
        if (Regex.IsMatch(number, pattern, RegexOptions.IgnoreCase))
        {
            Value = number;
        }
        else
        {
            throw new InvalidDataException();
        }
    }
}