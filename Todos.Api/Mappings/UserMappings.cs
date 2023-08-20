using Todos.Api.Dtos;
using Todos.Core.DTOs;

namespace Todos.Api.Mappings;

public static class UserMappings
{
    public static UserDTO ToUserDTO(this CreateUserDTO createUserDTO) => new UserDTO
    {
        Name = createUserDTO.Name
    };

    public static ReadUserDTO ToReadUserDTO(this UserDTO userDTO) => new ReadUserDTO
    {
        Id = userDTO.Id,
        Name = userDTO.Name,
        CreatedAt = userDTO.CreatedAt
    };
}