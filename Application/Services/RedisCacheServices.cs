using Application.Interfaces;
using StackExchange.Redis;

namespace QRMenuBackendProject.Application.Services;

public class RedisCacheServices : IRedisCacheServices
{
    private readonly IConnectionMultiplexer _connectionMultiplexer;
    private readonly IDatabaseAsync _databaseAsync;
    
    public RedisCacheServices(IConnectionMultiplexer connectionMultiplexer, IDatabaseAsync databaseAsync)
    {
        _connectionMultiplexer = connectionMultiplexer;
        _databaseAsync = connectionMultiplexer.GetDatabase();
    }

    public async Task ClearAsyn(string key)
    {
        await _databaseAsync.KeyDeleteAsync(key);
    }

    public async Task<string> GetValueAsync(string key)
    {
        return await _databaseAsync.StringGetAsync(key);
    }
    
    public async Task<bool> SetValueAsync(string key,string value)
    {
        return await _databaseAsync.StringSetAsync(key,value);
    }
    
    public void ClearAllAsyn()
    {
        var redisEndpoints = _connectionMultiplexer.GetEndPoints();
        foreach (var endpoint in redisEndpoints)
        {
            var redisServer = _connectionMultiplexer.GetServer(endpoint);
            redisServer.FlushAllDatabases();
        }
    }
}