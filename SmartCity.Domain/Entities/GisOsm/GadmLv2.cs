using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.GeoJsonObjectModel;

namespace SmartCity.Domain.Entities.GisOsm;

#nullable disable

public class GadmLv2 {
    public ObjectId _id { get; set; }

    [BsonElement("type")]
    public string Type { get; set; } = "Feature";

    [BsonElement("geometry")]
    public GeoJsonGeometry<GeoJson2DCoordinates> Geometry { get; set; }

    [BsonElement("properties")]
    public GadmLv2Properties Properties { get; set; }
}

public class GadmLv2Properties {
    [BsonElement("GID_2")]
    public string Gid2 { get; set; }

    [BsonElement("GID_0")]
    public string Gid0 { get; set; }

    [BsonElement("COUNTRY")]
    public string Country { get; set; }

    [BsonElement("GID_1")]
    public string Gid1 { get; set; }

    [BsonElement("NAME_1")]
    public string Name1 { get; set; }

    [BsonElement("NL_NAME_1")]
    public string NlName1 { get; set; }

    [BsonElement("NAME_2")]
    public string Name2 { get; set; }

    [BsonElement("VARNAME_2")]
    public string Varname2 { get; set; }

    [BsonElement("NL_NAME_2")]
    public string NlName2 { get; set; }

    [BsonElement("TYPE_2")]
    public string Type2 { get; set; }

    [BsonElement("ENGTYPE_2")]
    public string EngType2 { get; set; }

    [BsonElement("CC_2")]
    public string Cc2 { get; set; }

    [BsonElement("HASC_2")]
    public string Hasc2 { get; set; }
}
