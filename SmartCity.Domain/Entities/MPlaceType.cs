using System;
using System.Collections.Generic;

#nullable disable

namespace SmartCity.Domain.Entities;

public partial class MPlaceType {
    public int TypeId { get; set; }

    public string TypeName { get; set; } = null!;

    public string Fclass { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastModifiedDate { get; set; }

    public string LastModifiedBy { get; set; }

    public bool DeleteFlag { get; set; }
}
