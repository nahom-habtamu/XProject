using Dapper;
using Npgsql;
using domain.auction;

namespace persistence.auction;

public class AuctionRepositoryImpl : AuctionRepository
{
    public Task<Auction?> Get(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Auction>> GetAllAuctions()
    {
        using (var connection = new NpgsqlConnection("Server=localhost;Port=5432;Database=ProjectX;User Id=postgres;Password=root"))
        {
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