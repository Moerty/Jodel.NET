using Jodel.NET.Api.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Jodel.NET.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ApiControllerBase
{
    private readonly ILogger<UserController> _logger;

    public UserController(
        ILogger<UserController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        return Ok();
    }
}