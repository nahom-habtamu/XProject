using Dapper;
using domain.auction;

namespace persistence.auction;

public class AuctionRepositoryImpl : AuctionRepository
{
    private readonly DatabaseContext _context;

    public AuctionRepositoryImpl(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<Auction?> Get(string id)
    {
        var connection = _context.Get();
        var auction = (await connection.QueryAsync<Auction, PriceInterval, PickUpTimeInterval, Auction>(
        @"select id, cargoOwnerId, typeOfCargo, totalWeightOfCargo, deliveryplace, pickUpPlace, plannedPickUpDate, otherInformationAboutCargo,
            minpriceperhundredkg as min, maxpriceperhundredkg as max, 
            minpickuptime as min, minpickuptime as max from Auction Where id = 
        " + "'" + id + "'", (auction, priceInterval, pickUpTimeInterval) =>
        {
            auction.PriceIntervalPerHundredKiloGram = priceInterval;
            auction.PickUpTimeInterval = pickUpTimeInterval;
            return auction;
        }, splitOn: "id,min,min")).FirstOrDefault();

        return auction;
    }

    public async Task<List<Auction>> GetAllAuctions()
    {
        var connection = _context.Get();
        var auctions = (await connection.QueryAsync<Auction, PriceInterval, PickUpTimeInterval, Auction>(
        @"select id, cargoOwnerId, typeOfCargo, totalWeightOfCargo, deliveryplace, pickUpPlace, plannedPickUpDate, otherInformationAboutCargo,
            minpriceperhundredkg as min, maxpriceperhundredkg as max, 
            minpickuptime as min, minpickuptime as max from Auction
        ", (auction, priceInterval, pickUpTimeInterval) =>
        {
            auction.PriceIntervalPerHundredKiloGram = priceInterval;
            auction.PickUpTimeInterval = pickUpTimeInterval;
            return auction;
        }, splitOn: "id,min,min")).ToList();

        return auctions;
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