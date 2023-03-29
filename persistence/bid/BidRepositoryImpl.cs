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

    public Task<Bid?> Get(string id)
    {
        throw new NotImplementedException();
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

    public Task Save(Bid entity)
    {
        throw new NotImplementedException();
    }
}