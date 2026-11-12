using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SirIthara.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{

    private static readonly List<User> users = new List<User>
        {
            new User
            {
                Id = 1,
                Name = "John Doe",
                Email = "john.doe@example.com"
            },
            new User
            {
                Id = 2,
                Name = "Jane Smith",
                Email = "jane.smith@example.com"
            },
            new User
            {
                Id = 3,
                Name = "Bob Johnson",
                Email = "bob.johnson@example.com"
            }
        };

    [HttpGet]
    public IActionResult Users()
    {

        return Ok(users);
    }

    [HttpGet("{id}")]
    public IActionResult GetUserById(int id)
    {
        List<User> users = new List<User>
        {
            new User
            {
                Id = 1,
                Name = "John Doe",
                Email = "john.doe@example.com" }
        };

        var user = users.FirstOrDefault(u => u.Id == id);


        if (user is null)
        {

            return NotFound("user not found");
        }

        return Ok(user);

    }

    [HttpPost]
    public IActionResult SaveUser([FromBody] User user)
    {

        var existingUser = users.FirstOrDefault(u => u.Email.Equals(user.Email, StringComparison.OrdinalIgnoreCase));


        if (existingUser is not null)
        {
            return BadRequest("User already exists");
        }


        users.Add(new User
        {
            Id = user.Id,
            Email = user.Email,
            Name = user.Email
        });

        return Ok("User Created");

    }


    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, [FromBody] User user)
    {
        var existingUser = users.FirstOrDefault(u => u.Id == id);
        if (existingUser is null)
        {
            return NotFound("User not found");
        }
        existingUser.Name = user.Name;
        existingUser.Email = user.Email;
        return Ok("User updated successfully");
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var existingUser = users.FirstOrDefault(u => u.Id == id);
        if (existingUser is null)
        {
            return NotFound("User not found");
        }
        users.Remove(existingUser);
        return Ok("User deleted successfully");
    }



    [HttpPost("UpdateProfile")]
    public IActionResult UpdateProfile([FromBody] UserProfie user)
    {
        var existingUser = users.FirstOrDefault(u => u.Id == user.Id);
        if (existingUser is null)
        {
            return NotFound("User not found");
        }
        existingUser.Name = user.Name;
        return Ok("User updated successfully");
    }
}


public class User
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [EmailAddress]
    public string Email { get; set; }
}

public class UserProfie
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
}