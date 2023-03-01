namespace domain.auction;

public interface AuctionRepository : DomainRepository<Auction>
{
    Task<List<Auction>> GetAuctionsByCargoOwner(string id);
    Task<List<Auction>> GetAllAuctions();
}