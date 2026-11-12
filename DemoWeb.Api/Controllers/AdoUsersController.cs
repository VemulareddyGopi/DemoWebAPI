using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SirIthara.Api.Models;
using SirIthara.Api.Services;

namespace SirIthara.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdoUsersController(IUserService userService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Users()
    {
        var users = await userService.UsersAsync();
        return Ok(users);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await userService.UserByIdAsync(id);
        if (user is null)
        {
            return NotFound("User not found");
        }
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> SaveUser([FromBody] AdoUser user)
    {
        var result = await userService.SaveUserAsync(user);
        return Ok(result);
    }   

}
