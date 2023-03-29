using Dapper;
using domain.bid;

namespace persistence.bid;

public class BidRepositoryImpl : BidRepository
{
    private readonly DatabaseContext _context;

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
        var connection = _context.Get();
        var sql = @"select id, auctionId, driverId, pricePerKilogram, 
            additionalInformation from Bid WHERE driverId = " + "'" + id + "'";
        var bids = (await connection.QueryAsync<Bid>(sql)).ToList();
        return bids;
    }

    public Task<List<Bid>> GetBidsForAuction(string id)
    {
        throw new NotImplementedException();

    }

    public Task Save(Bid entity)
    {
        throw new NotImplementedException();
    }
}