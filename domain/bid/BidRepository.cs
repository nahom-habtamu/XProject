namespace domain.bid;

public interface BidRepository : DomainRepository<Bid>
{
    Task<List<Bid>> GetBidsByDriver(string id);
    Task<List<Bid>> GetBidsForAuction(string id);
}