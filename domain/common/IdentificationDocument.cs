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

    public override bool Equals(object? obj)
    {
        if (obj == null)
            return false;

        if (ReferenceEquals(obj, this))
            return false;

        if (obj.GetType() != this.GetType())
            return false;

        var parsed = obj as IdentificationDocument;


        var x = this.Value[0].Equals(parsed!.Value[0]);
        var y = this.Value[1].Equals(parsed!.Value[1]);

        if (
            this.Value[0].Equals(parsed!.Value[0]) &&
            this.Value[1].Equals(parsed!.Value[1]))
        {
            return true;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return this.GetHashCode();
    }
}