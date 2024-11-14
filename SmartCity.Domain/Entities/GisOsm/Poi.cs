using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.GeoJsonObjectModel;

namespace SmartCity.Domain.Entities.GisOsm;

#nullable disable

public class Poi {
    public ObjectId _id { get; set; }

    [BsonElement("type")]
    public string Type { get; set; } = "Feature";

    [BsonElement("geometry")]
    public GeoJsonGeometry<GeoJson2DCoordinates> Geometry { get; set; }

    [BsonElement("properties")]
    public Properties Properties { get; set; }
}

public class Properties {
    [BsonElement("osm_id")]
    public string OsmId { get; set; }

    [BsonElement("code")]
    public int Code { get; set; }

    [BsonElement("fclass")]
    public string Fclass { get; set; }

    [BsonElement("name")]
    public string Name { get; set; }
}
