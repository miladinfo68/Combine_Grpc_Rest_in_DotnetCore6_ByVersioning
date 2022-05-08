using Grpc.Net.Client;
using GrpcClientDemo.Mapper;
using GrpcShared;
using GrpcShared.Dtos;
using Microsoft.AspNetCore.Mvc;

using static GrpcShared.AuthorProtoService;

namespace GrpcClientDemo.Controllers.V2;



[ApiController]
[ApiVersion("2.0", Deprecated = false)]
[Route("api/v{version:apiVersion}/[controller]")]
public class AuthorController : Controller
{
    private readonly GrpcChannel _channel;
    private readonly ILogger<AuthorController> _logger;
    private readonly AuthorProtoServiceClient _client;

    public AuthorController(ILogger<AuthorController> logger)
    {
        _logger = logger;
        _channel = GrpcChannel.ForAddress("https://localhost:5001");
        _client ??= new AuthorProtoServiceClient(_channel);
    }



    [HttpGet("hc")] public string HealthCheck() => "API HealthCheck is OK";

    [HttpGet(Name = "GetAuthors")]
    public async Task<IActionResult> GetAll()
    {
        var response = (await _client.GetAllAsync(new GetAllAuthorsRequest()))?.Authors?.ToList();
        return Ok(response);
    }


    [HttpGet("{id}", Name = "GetAuthor")]
    public async Task<IActionResult> GetById(string id)
    {
        var response = (await _client.GetByIdAsync(new GetAuthorRequest { Id = id }))?.Author;
        if (response == null) return NotFound();
        return Ok(response);
    }


    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AddAuthorDto author)
    {
        var response = await _client.AddAsync(author.ToAddAuthorRequest());
        return Ok(response?.Id);
    }


    [HttpPut]
    public async Task<IActionResult> Put([FromBody] EditAuthorDto author)
    {
        var response = (await _client.UpdateAsync(author.ToEditAuthorRequest()))?.Author;
        if (response == null) return NotFound();
        //return NoContent();
        var res = response != null ? new { id = response.Id, name = response.Name }: null;
        return Ok(res);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var flag = await _client.DeleteAsync(new DeleteAuthorRequest { Id = id });
        return Ok(flag);
    }


}