
using GrpcShared.Dtos;
using GrpcShared.Services;
using Microsoft.AspNetCore.Mvc;

namespace GrpcClientDemo.Controllers.V1;


[ApiController]
[ApiVersion("1.0")]
// [Route("api/[controller]")]
[Route("api/v{version:apiVersion}/[controller]")]
public class AuthorController : ControllerBase
{
    private readonly IAuthorapiService _authorapiService;
    public AuthorController(IAuthorapiService authorapiService)
    {
        _authorapiService = authorapiService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var res = await _authorapiService.GetAllAsync();
        return Ok(res);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(string id)
    {
        var res = await _authorapiService.GetByIdAsync(id);
        if (res is null) return NotFound();
        return Ok(res);
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] AddAuthorDto entity)
    {
        var res = await _authorapiService.AddAsync(entity);
        return Ok(res);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] EditAuthorDto entity)
    {
        var res = await _authorapiService.UpdateAsync(entity);
        return Ok(res);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(string id)
    {
        var res = await _authorapiService.DeleteAsync(id);
        return Ok(res);
    }

}