using domain.bid;

namespace persistence.bid;

public class BidRepositoryImpl : BidRepository
{
    private List<Bid> bids = new List<Bid>
    {
        new Bid("1","1",2000,"None"),
        new Bid("2","1",2000,"None"),
        new Bid("3","1",2000,"None"),
        new Bid("1","2",2000,"None"),
        new Bid("5","7",2000,"None"),
        new Bid("6","3",2000,"None"),
    };

    public Task<Bid?> Get(string id)
    {
        return Task.Run(() => bids.FirstOrDefault(b => b.Id.Equals(id)));
    }

    public Task<List<Bid>> GetBidsByDriver(string id)
    {
        return Task.Run(() => bids.Where(b => b.DriverId.Equals(id)).ToList());
    }

    public Task<List<Bid>> GetBidsForAuction(string id)
    {
        return Task.Run(() => bids.Where(b => b.AuctionId.Equals(id)).ToList());
    }

    public Task Save(Bid entity)
    {
        throw new NotImplementedException();
    }
}