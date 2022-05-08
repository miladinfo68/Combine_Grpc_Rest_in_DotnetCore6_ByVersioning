using GrpcShared.Dtos;
using GrpcShared.Services;
using Microsoft.AspNetCore.Mvc;

namespace GrpcClientDemo.Controllers.V1;


[ApiController]
[ApiVersion("1.0")]
// [Route("api/[controller]")]
[Route("api/v{version:apiVersion}/[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookapiService _bookapiService;
    public BookController(IBookapiService bookapiService)
    {
        _bookapiService = bookapiService;
    }


    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var res = await _bookapiService.GetAllAsync();
        return Ok(res);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(string id)
    {
        var res = await _bookapiService.GetByIdAsync(id);
        if (res is null) return NotFound();
        return Ok(res);
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] AddBookDto entity)
    {
        var res = await _bookapiService.AddAsync(entity);
        return Ok(res);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] EditBookDto entity)
    {
        var res = await _bookapiService.UpdateAsync(entity);
        return Ok(res);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(string id)
    {
        var res = await _bookapiService.DeleteAsync(id);
        return Ok(res);
    }

}