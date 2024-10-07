namespace SmartCity.Domain.Common.Entities;

public class BaseEntity {
    public virtual DateTime CreatedDate { get; set; }

    public virtual int CreatedBy { get; set; }

    public virtual DateTime LastModifiedDate { get; set; }

    public virtual int LastModifiedBy { get; set; }

    public virtual bool DeleteFlag { get; set; }
}
