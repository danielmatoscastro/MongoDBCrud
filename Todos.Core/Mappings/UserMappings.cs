using Todos.Core.DTOs;
using Todos.Core.Entities;

namespace Todos.Core.Mappings;

public static class UserMappings
{
    public static UserDTO ToUserDTO(this User user) => new UserDTO
    {
        Id = user.Id,
        Name = user.Name,
        CreatedAt = user.CreatedAt
    };

    public static User ToUserEntity(this UserDTO userDTO) => new User(userDTO.Name);
}