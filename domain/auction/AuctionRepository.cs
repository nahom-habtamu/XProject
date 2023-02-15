namespace domain.auction;

public interface AuctionRepostory : DomainRepository<Auction>
{
    Task<Auction> GetAuctionsByCargoOwner(string id);
    Task<List<Auction>> GetAllAuctions();
}