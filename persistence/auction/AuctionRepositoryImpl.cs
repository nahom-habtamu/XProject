using Dapper;
using domain.auction;

namespace persistence.auction;

public class AuctionRepositoryImpl : AuctionRepository
{
    private readonly DatabaseContext _context;

    public AuctionRepositoryImpl(DatabaseContext context)
    {
        _context = context;
    }

    const string baseGetSql = @"select id, cargoOwnerId, typeOfCargo, totalWeightOfCargo, deliveryplace, 
        pickUpPlace, plannedPickUpDate, otherInformationAboutCargo, minpickuptime, maxpickuptime, createdAt,
        minpriceperhundredkg as min, maxpriceperhundredkg as max
        from Auction";

    public async Task<Auction?> Get(string id)
    {
        var sql = baseGetSql + " where id = " + "'" + id + "'";
        var auction = (await QueryAndParseSelectRequest(sql)).FirstOrDefault();
        return auction;
    }

    public async Task<List<Auction>> GetAllAuctions()
    {
        var auctions = (await QueryAndParseSelectRequest(baseGetSql)).ToList();
        return auctions;
    }

    public async Task<List<Auction>> GetAuctionsByCargoOwner(string id)
    {
        var sql = baseGetSql + " where cargoOwnerId = " + "'" + id + "'";
        var auctions = (await QueryAndParseSelectRequest(sql)).ToList();
        return auctions;
    }

    private async Task<IEnumerable<Auction>> QueryAndParseSelectRequest(string sql)
    {
        var connection = _context.Get();
        var result = (await connection.QueryAsync<Auction, PriceInterval, Auction>(
            sql, (auction, priceInterval) =>
        {
            auction.PriceIntervalPerHundredKiloGram = priceInterval;
            return auction;
        }, splitOn: "id,min"));
        return result;
    }

    public async Task Save(Auction entity)
    {
        var sql = String.Format(
            @"insert into Auction values
              ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')
              on conflict (id) do update set(cargoOwnerId, typeOfCargo, totalWeightOfCargo, deliveryplace, 
              pickUpPlace, plannedPickUpDate, otherInformationAboutCargo, minpickuptime, maxpickuptime,
              minpriceperhundredkg, maxpriceperhundredkg, createdAt) = (excluded.cargoOwnerId, 
              excluded.typeOfCargo, excluded.totalWeightOfCargo,excluded.deliveryplace, 
              excluded.pickUpPlace, excluded.plannedPickUpDate, excluded.otherInformationAboutCargo, 
              excluded.minpickuptime, excluded.maxpickuptime,excluded.minpriceperhundredkg, 
              excluded.maxpriceperhundredkg,excluded.createdAt)
            ;",
            entity.Id, entity.CargoOwnerId!, entity.TypeOfCargo!,
            entity.TotalWeightOfCargo!, entity.DeliveryPlace!,
            entity.PickUpPlace!, entity.PlannedPickUpDate!,
            entity.OtherInformationAboutCargo!,
            entity.PriceIntervalPerHundredKiloGram!.Min, entity.PriceIntervalPerHundredKiloGram.Max,
            entity.MinPickUpTime!, entity.MaxPickUpTime!, entity.CreatedAt
        );
        var connection = _context.Get();
        await connection.ExecuteAsync(sql);
    }
}