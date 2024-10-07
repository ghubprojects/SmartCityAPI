using SmartCity.Domain.Common.Entities;

namespace SmartCity.Domain.Entities;

#nullable disable

public partial class PoiPhoto : BaseEntity {
    public int PhotoId { get; set; }

    public int DetailId { get; set; }

    public string Url { get; set; }

    public string Caption { get; set; }

    public virtual PoiDetail Detail { get; set; }
}
