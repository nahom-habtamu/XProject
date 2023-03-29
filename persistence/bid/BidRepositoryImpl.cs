using domain.bid;

namespace persistence.bid;

public class BidRepositoryImpl : BidRepository
{

    public Task<Bid?> Get(string id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Bid>> GetBidsByDriver(string id)
    {
        throw new NotImplementedException();
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