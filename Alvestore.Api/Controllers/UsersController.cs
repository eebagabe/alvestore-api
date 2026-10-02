using Alvestore.Api.DTOs;
using Alvestore.Api.Exceptions;
using Alvestore.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Alvestore.Api.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserRequest request)
    {
        try
        {
            var user = await _userService.CreateAsync(request);
            return Created($"/api/users/{user.id}", user);
        }
        catch (ConflictException ex)
        {
            return Conflict(new { message = ex.Message });
        }
    }
}