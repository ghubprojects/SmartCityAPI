using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.GeoJsonObjectModel;

namespace SmartCity.Domain.Entities.GisOsm;

#nullable disable

public class GadmLv1 {
    public ObjectId _id { get; set; }

    [BsonElement("type")]
    public string Type { get; set; } = "Feature";

    [BsonElement("geometry")]
    public GeoJsonGeometry<GeoJson2DCoordinates> Geometry { get; set; }

    [BsonElement("properties")]
    public GadmLv1Properties Properties { get; set; }
}

public class GadmLv1Properties {
    [BsonElement("GID_1")]
    public string Gid1 { get; set; }

    [BsonElement("GID_0")]
    public string Gid0 { get; set; }

    [BsonElement("COUNTRY")]
    public string Country { get; set; }

    [BsonElement("NAME_1")]
    public string Name1 { get; set; }

    [BsonElement("VARNAME_1")]
    public string Varname1 { get; set; }

    [BsonElement("NL_NAME_1")]
    public string NlName1 { get; set; }

    [BsonElement("TYPE_1")]
    public string Type1 { get; set; }

    [BsonElement("ENGTYPE_1")]
    public string EngType1 { get; set; }

    [BsonElement("CC_1")]
    public string Cc1 { get; set; }

    [BsonElement("HASC_1")]
    public string Hasc1 { get; set; }

    [BsonElement("ISO_1")]
    public string Iso1 { get; set; }
}
