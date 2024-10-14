using Application.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebApi.Controllers;

[Route("api/cache-control")]
public class CacheController:ControllerBase
{
    private readonly IRedisCacheServices _redisCacheServices;

    public CacheController(IRedisCacheServices redisCacheServices)
    {
        _redisCacheServices = redisCacheServices;
    }

    [HttpGet]
    public async Task<IActionResult> GetData([BindRequired]string key)
    {
        return Ok(await _redisCacheServices.GetValueAsync(key));
    }
    
    [HttpPost]
    public async Task<IActionResult> SetData([BindRequired]string key,[BindRequired] string value)
    {
        await _redisCacheServices.SetValueAsync(key,value);

        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteData([BindRequired] string key)
    {
        await _redisCacheServices.ClearAsyn(key);

        return Ok();
    }
}