using Dapper;
using domain.vehicleowner;

namespace persistence.vehicleowner;
public class VehicleOwnerRepositoryImpl : VehicleOwnerRepository
{
    private readonly DatabaseContext _context;

    public VehicleOwnerRepositoryImpl(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<VehicleOwner?> Get(string id)
    {
        var connection = _context.Get();
        var sql = @"select id, name, phoneNumber, email, companyName, tradeLicense, 
                    userName, password from VehicleOwner 
                    WHERE id = " + "'" + id + "'";
        var vehicleOwner = (await connection.QueryAsync<VehicleOwner>(sql)).FirstOrDefault();
        return vehicleOwner;
    }

    public Task<List<VehicleOwner>> GetAllVehicleOwners()
    {
        throw new NotImplementedException();
    }

    public async Task Save(VehicleOwner entity)
    {
        var sql = String.Format(
            @"insert into VehicleOwner values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}') on conflict (id)
              do update set(name, phoneNumber, email, companyName, tradeLicense, userName, password) = 
              (excluded.name, excluded.phoneNumber, excluded.email, excluded.companyName, 
               excluded.tradeLicense, excluded.userName, excluded.password)
            ;",
            entity.Id, entity.Name, entity.PhoneNumber.Value, entity.Email, entity.CompanyName,
            entity.TradeLicense, entity.UserName, entity.Password
        );
        var connection = _context.Get();
        await connection.ExecuteAsync(sql);
    }
}