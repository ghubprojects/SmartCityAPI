using MongoDB.Driver;
using SmartCity.Domain.Entities.GisOsm;

namespace SmartCity.Infrastructure.DataContext;

public class GisOsmContext(IMongoClient mongoClient) {
    private readonly IMongoDatabase _database = mongoClient.GetDatabase("gis_osm");

    public IMongoCollection<Poi> Poi => _database.GetCollection<Poi>("pois");

    public IMongoCollection<GadmLv1> GadmLv1 => _database.GetCollection<GadmLv1>("gadm_lv1");

    public IMongoCollection<GadmLv2> GadmLv2 => _database.GetCollection<GadmLv2>("gadm_lv2");
}
