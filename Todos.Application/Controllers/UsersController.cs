using Microsoft.AspNetCore.Mvc;
using Todos.Application.Dtos;
using Todos.Application.Mappings;
using Todos.Domain.Repositories;

namespace Todos.Application.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UsersController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(string id)
    {
        var userEntity = await _userRepository.GetById(id);
        if (userEntity == null)
        {
            return NotFound();
        }

        return Ok(userEntity.ToReadUserDTO());
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserDTO createUserDTO)
    {
        var userEntity = createUserDTO.ToUserEntity();
        userEntity = await _userRepository.Create(userEntity);
        return CreatedAtAction(nameof(GetUser), new { id = userEntity.Id }, userEntity.ToReadUserDTO());
    }
}