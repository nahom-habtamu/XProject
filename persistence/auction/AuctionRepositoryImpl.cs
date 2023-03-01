using domain.auction;

namespace persistence.auction;

public class AuctionRepositoryImpl : AuctionRepository
{
    public Task<Auction?> Get(string id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Auction>> GetAllAuctions()
    {
        return Task.Run(() => new List<Auction>());
    }

    public Task<List<Auction>> GetAuctionsByCargoOwner(string id)
    {
        throw new NotImplementedException();
    }

    public Task Save(Auction entity)
    {
        throw new NotImplementedException();
    }
}