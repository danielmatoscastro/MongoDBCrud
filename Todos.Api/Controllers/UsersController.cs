using Microsoft.AspNetCore.Mvc;
using Todos.Api.Dtos;
using Todos.Api.Mappings;
using Todos.Core.Repositories;
using Todos.Core.Services;

namespace Todos.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UsersController : ControllerBase
{
    private readonly UserService _userService;

    public UsersController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetUser(Guid id)
    {
        var userDTO = await _userService.GetById(id);
        return Ok(userDTO.ToReadUserDTO());
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserDTO createUserDTO)
    {
        var userDTO = createUserDTO.ToUserDTO();
        userDTO = await _userService.Create(userDTO);
        return CreatedAtAction(nameof(GetUser), new { Id = userDTO.Id }, userDTO.ToReadUserDTO());
    }
}