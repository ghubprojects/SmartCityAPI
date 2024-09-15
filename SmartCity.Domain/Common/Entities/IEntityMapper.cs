namespace SmartCity.Domain.Common.Entities;

public interface IEntityMapper<T> {
    T ToEntity();
}
