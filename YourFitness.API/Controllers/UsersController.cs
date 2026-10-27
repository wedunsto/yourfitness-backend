// Receives HTTP requests for Users and returns responses

using Microsoft.AspNetCore.Mvc;
using YourFitness.Application;
using YourFitness.Domain;

namespace YourFitness.API.controllers;

[ApiController]
[Route("yourfitness")]
public class UsersController : ControllerBase
{
    private readonly UserService _service;

    public UsersController(UserService service)
    {
        _service = service;
    }

    // Create a new user on yourfitness/register
    [HttpPost("register")]
    public async Task<IActionResult> Register(AuthenticateUserRequest request)
    {
        await _service.Register(request.username, request.password);
        return Ok();
    }

    // Log in an existing user on yourfitness/login
    [HttpPost("login")]
    public async Task<string> Login(AuthenticateUserRequest request)
    {
        var jsonWebToken = await _service.Login(request.username, request.password);
        return jsonWebToken;
    }
}