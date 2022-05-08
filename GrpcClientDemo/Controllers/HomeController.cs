using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GrpcClientDemo.Controllers.V2;

public class HomeController : Controller
{
    private readonly GrpcChannel channel;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        channel = GrpcChannel.ForAddress("https://localhost:5001");
    }

    [HttpGet, Route("[controller]/Index")]
    public IActionResult Index()
    {
        return View();
    }

}