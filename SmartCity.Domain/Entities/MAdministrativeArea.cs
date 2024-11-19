using System;
using System.Collections.Generic;

#nullable disable

namespace SmartCity.Domain.Entities;

public partial class MAdministrativeArea {
    public int AreaId { get; set; }

    public string AreaName { get; set; } = null!;

    public string AreaType { get; set; } = null!;

    public string EngType { get; set; }

    public int? ParentId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime LastModifiedDate { get; set; }

    public int LastModifiedBy { get; set; }

    public bool DeleteFlag { get; set; }

    public virtual ICollection<MAdministrativeArea> InverseParent { get; set; } = new List<MAdministrativeArea>();

    public virtual MAdministrativeArea Parent { get; set; }
}
