namespace Application.Interfaces;

public interface IRedisCacheServices
{
    Task ClearAsyn(string key);
    Task<string> GetValueAsync(string key);
    Task<bool> SetValueAsync(string key, string value);
    void ClearAllAsyn();

}