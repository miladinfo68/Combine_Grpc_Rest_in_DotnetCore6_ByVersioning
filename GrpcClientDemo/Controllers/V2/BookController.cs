using Grpc.Net.Client;
using GrpcClientDemo.Mapper;
using GrpcShared;
using GrpcShared.Dtos;
using Microsoft.AspNetCore.Mvc;

using static GrpcShared.BookProtoService;

namespace GrpcClientDemo.Controllers.V2;



[ApiController]
[ApiVersion("2.0", Deprecated = false)]
[Route("api/v{version:apiVersion}/[controller]")]
public class BookController : Controller
{
    private readonly GrpcChannel _channel;
    private readonly ILogger<BookController> _logger;
    private readonly BookProtoServiceClient _client;

    public BookController(ILogger<BookController> logger)
    {
        _logger = logger;
        _channel = GrpcChannel.ForAddress("https://localhost:5001");
        _client ??= new BookProtoServiceClient(_channel);
    }



    [HttpGet("hc")] public string HealthCheck() => "API HealthCheck is OK";

    [HttpGet(Name = "GetBooks")]
    public async Task<IActionResult> GetAll()
    {
        var response = (await _client.GetAllAsync(new GetAllBooksRequest()))?.Books?.ToList();
        return Ok(response);
    }


    [HttpGet("{id}", Name = "GetBook")]
    public async Task<IActionResult> GetById(string id)
    {
        var response = (await _client.GetByIdAsync(new GetBookRequest { Id = id }))?.Book;
        if (response == null) return NotFound();
        return Ok(response);
    }


    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AddBookDto book)
    {
        var response = await _client.AddAsync(book.ToAddBookRequest());
        return Ok(response.Book);
    }


    [HttpPut]
    public async Task<IActionResult> Put([FromBody] EditBookDto book)
    {
        var response = (await _client.UpdateAsync(book.ToEditBookRequest()))?.Book;
        if (response == null) return NotFound();
        return NoContent();
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var flag = await _client.DeleteAsync(new DeleteBookRequest { Id = id });
        return Ok(flag);
    }


}