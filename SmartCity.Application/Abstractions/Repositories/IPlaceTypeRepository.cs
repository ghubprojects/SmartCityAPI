namespace SmartCity.Application.Abstractions.Repositories;

public interface IPlaceTypeRepository {
    Task<string?> GetFClassAsync(string type);
    Task<Dictionary<string, string>> GetTypeDictAsync();
}