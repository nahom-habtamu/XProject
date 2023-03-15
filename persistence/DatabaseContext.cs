using Npgsql;

namespace persistence;

public class DatabaseContext
{
    private readonly NpgsqlConnection _context;

    public DatabaseContext(NpgsqlConnection context)
    {
        _context = context;
    }

    public NpgsqlConnection Get()
    {
        return _context;
    }
}