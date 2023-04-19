using Dapper;
using domain.cargoowner;

namespace persistence.cargoowner;
public class CargoOwnerRepositoryImpl : CargoOwnerRepository
{
    private readonly DatabaseContext _context;
    public CargoOwnerRepositoryImpl(DatabaseContext context)
    {
        _context = context;
    }

    private readonly string baseGetSql = @"select id, name, phoneNumber, email, specificAddress, tradeLicense, 
        userName, password, pointPersonName, pointPersonPhoneNumber,pointPersonSpecificAddress, pointPersonEmail, 
        pointPersonPosition from cargoowner";

    public async Task<CargoOwner?> Get(string id)
    {
        var connection = _context.Get();
        var sql = baseGetSql + " WHERE id = " + "'" + id + "'";
        var cargoOwner = (await QueryAndParseResult(sql)).FirstOrDefault();
        return cargoOwner;
    }

    public async Task<List<CargoOwner>> GetAllCargoOwners()
    {
        var cargoOwners = await QueryAndParseResult(baseGetSql);
        return cargoOwners.ToList();
    }

    private async Task<IEnumerable<CargoOwner>> QueryAndParseResult(string sql)
    {
        var connection = _context.Get();
        var cargoOwners = (await connection.QueryAsync<CargoOwner>(sql)).ToList();
        return cargoOwners;
    }

    public async Task Save(CargoOwner entity)
    {
        var sql = String.Format(
            @"insert into CargoOwner values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')
              on conflict (id) do update set(name, phoneNumber, email, specificAddress, tradeLicense, userName, password,
              pointPersonName, pointPersonPhoneNumber,pointPersonSpecificAddress, pointPersonEmail, 
              pointPersonPosition) = (excluded.name, excluded.phoneNumber, excluded.email,excluded.specificAddress, 
              excluded.tradeLicense, excluded.userName,excluded.password,excluded.pointPersonName, 
              excluded.pointPersonPhoneNumber,excluded.pointPersonSpecificAddress, 
              excluded.pointPersonEmail, excluded.pointPersonPosition)
            ;",
            entity.Id, entity.Name, entity.PhoneNumber.Value, entity.Email, entity.SpecificAddress,
            entity.TradeLicense, entity.UserName, entity.Password,
            entity.PointPersonName, entity.PointPersonPhoneNumber.Value,
            entity.PointPersonSpecificAddress, entity.PointPersonEmail, entity.PointPersonPosition
        );
        var connection = _context.Get();
        await connection.ExecuteAsync(sql);
    }
}