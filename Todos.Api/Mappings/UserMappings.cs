using Todos.Api.Dtos;
using Todos.Core.Entities;

namespace Todos.Api.Mappings;

public static class UserMappings
{
    public static User ToUserEntity(this CreateUserDTO createUserDTO) => new User(createUserDTO.Name);

    public static ReadUserDTO ToReadUserDTO(this User user) => new ReadUserDTO
    {
        Id = user.Id,
        Name = user.Name,
        CreatedAt = user.CreatedAt,
    };
}