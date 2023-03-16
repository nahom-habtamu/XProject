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

    public override bool Equals(object? obj)
    {
        if (obj == null)
            return false;

        if (ReferenceEquals(obj, this))
            return false;

        if (obj.GetType() != this.GetType())
            return false;

        var parsed = obj as MobileNumber;
        
        if (this.Value.Equals(parsed?.Value))
        {
            return true;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return this.Value.GetHashCode();
    }
}