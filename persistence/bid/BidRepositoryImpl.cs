using Dapper;
using domain.bid;

namespace persistence.bid;

public class BidRepositoryImpl : BidRepository
{
    private readonly DatabaseContext _context;

    private readonly string baseGetSql =
        @"select id, auctionId, driverId, pricePerKilogram, additionalInformation from Bid";

    public BidRepositoryImpl(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<Bid?> Get(string id)
    {
        string sql = baseGetSql + " where id = " + "'" + id + "'";
        return (await QuerySelectAndParse(sql)).FirstOrDefault();
    }

    public async Task<List<Bid>> GetBidsByDriver(string id)
    {
        string sql = baseGetSql + " where driverId = " + "'" + id + "'";
        List<Bid> bids = await QuerySelectAndParse(sql);
        return bids;
    }

    public async Task<List<Bid>> GetBidsForAuction(string id)
    {
        string sql = baseGetSql + " where auctionId = " + "'" + id + "'";
        List<Bid> bids = await QuerySelectAndParse(sql);
        return bids;
    }

    private async Task<List<Bid>> QuerySelectAndParse(string sql)
    {
        var connection = _context.Get();
        var bids = (await connection.QueryAsync<Bid>(sql)).ToList();
        return bids;
    }

    public async Task Save(Bid entity)
    {
        var sql = String.Format(
            @"insert into Bid values('{0}','{1}','{2}','{3}','{4}') on conflict (id) 
              do update set(auctionId, driverId, pricePerKilogram, additionalInformation) = 
              (excluded.auctionId, excluded.driverId, excluded.pricePerKilogram, excluded.additionalInformation)
            ;",
            entity.Id, entity.AuctionId, entity.DriverId, entity.PricePerKilogram, entity.AdditionalInformation
        );
        var connection = _context.Get();
        await connection.ExecuteAsync(sql);
    }
}