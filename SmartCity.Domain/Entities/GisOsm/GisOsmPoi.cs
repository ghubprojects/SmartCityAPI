using NetTopologySuite.Geometries;

namespace SmartCity.Domain.Entities.GisOsm;

public class GisOsmPoi {
    // Primary Key
    public int Gid { get; set; }

    // OpenStreetMap ID
    public string OsmId { get; set; }

    // Code (classification code)
    public short Code { get; set; }

    // Feature Class
    public string FClass { get; set; }

    // Name of the POI
    public string Name { get; set; }

    // Geometry column (Multipolygon, stored using PostGIS)
    public MultiPolygon Geom { get; set; }
}
