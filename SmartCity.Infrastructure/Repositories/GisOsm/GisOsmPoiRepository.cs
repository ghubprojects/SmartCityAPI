using Dapper;
using SmartCity.Application.Abstractions.Repositories.GisOsm;
using SmartCity.Domain.Entities.GisOsm;
using System.Data;

namespace SmartCity.Infrastructure.Repositories.GisOsm;
public class GisOsmPoiRepository(IDbConnection dbConnection) : IGisOsmPoiRepository {
    private readonly IDbConnection _dbConnection = dbConnection;

    public async Task<List<GisOsmPoi>> GetPoisNearLocation(double latitude, double longitude, double radius) {
        const string sql = @"
            SELECT gid, osm_id, code, fclass, name, ST_Distance(geom::geography, ST_SetSRID(ST_MakePoint(@Longitude, @Latitude), 4326)::geography) AS distance
            FROM public.gis_osm_pois
            WHERE ST_DWithin(
                geom::geography,
                ST_SetSRID(ST_MakePoint(@Longitude, @Latitude), 4326)::geography,
                @Radius
            )";

        // Execute the query with Dapper
        var pois = await _dbConnection.QueryAsync<GisOsmPoi>(sql, new {
            Latitude = latitude,
            Longitude = longitude,
            Radius = radius
        });

        return pois.AsList(); // Convert to List and return
    }
}
