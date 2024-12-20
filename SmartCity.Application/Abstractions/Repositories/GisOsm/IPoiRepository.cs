﻿using MongoDB.Driver.GeoJsonObjectModel;
using SmartCity.Domain.Entities.GisOsm;

namespace SmartCity.Application.Abstractions.Repositories.GisOsm;

public interface IPoiRepository {
    //Task<List<Poi>> GetNearSphereAsync(double latitude, double longitude, string type, double radius);
    //Task<List<Poi>> GetWithinAreaAsync(GeoJsonGeometry<GeoJson2DCoordinates> geometry);
    Task<List<Poi>> GetAllAsync(string? fClass, GeoJsonGeometry<GeoJson2DCoordinates>? areaGeometry, double lat, double lon, double distance);
}
