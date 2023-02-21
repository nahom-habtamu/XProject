namespace domain.auction;

public interface AuctionRepository : DomainRepository<Auction>
{
    Task<Auction> GetAuctionsByCargoOwner(string id);
    Task<List<Auction>> GetAllAuctions();
}