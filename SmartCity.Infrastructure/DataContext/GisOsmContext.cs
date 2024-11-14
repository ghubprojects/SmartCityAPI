using MongoDB.Driver;
using SmartCity.Domain.Entities.GisOsm;

namespace SmartCity.Infrastructure.DataContext;

public class GisOsmContext(IMongoClient mongoClient) {
    private readonly IMongoDatabase _database = mongoClient.GetDatabase("gis_osm");

    public IMongoCollection<Poi> Poi => _database.GetCollection<Poi>("pois");
}
