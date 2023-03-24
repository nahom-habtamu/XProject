namespace domain.common;
public class IdentificationDocument
{
    public List<string> Value { get; }
    
    public IdentificationDocument(List<string> value)
    {
        if (value.Count == 2)
        {
            Value = value;
        }
        else
        {
            throw new InvalidDataException();
        }
    }
}