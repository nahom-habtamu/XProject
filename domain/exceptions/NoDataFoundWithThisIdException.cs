namespace domain.exceptions;

public class NoDataFoundWithThisIdException : Exception
{
    public NoDataFoundWithThisIdException(string entityName, string id)
        : base(entityName + " With Id: " + id +  " Is Not Found")
    {
    }
}