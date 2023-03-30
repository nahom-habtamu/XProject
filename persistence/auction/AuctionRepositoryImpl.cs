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

    const string baseGetSql = @"select id, cargoOwnerId, typeOfCargo, totalWeightOfCargo, deliveryplace, pickUpPlace, plannedPickUpDate, otherInformationAboutCargo,
        minpickuptime, maxpickuptime,minpriceperhundredkg as min, maxpriceperhundredkg as max  
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

    public Task Save(Auction entity)
    {
        throw new NotImplementedException();
    }
}