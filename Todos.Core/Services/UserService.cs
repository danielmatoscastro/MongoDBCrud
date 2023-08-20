using Todos.Core.DTOs;
using Todos.Core.Entities;
using Todos.Core.Exceptions;
using Todos.Core.Mappings;
using Todos.Core.Repositories;

namespace Todos.Core.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserDTO> GetById(Guid id)
    {
        var userEntity = await _userRepository.GetById(id);
        if (userEntity == null)
        {
            throw new EntityNotFoundException(typeof(User), id);
        }

        return userEntity.ToUserDTO();
    }

    public async Task<UserDTO> Create(UserDTO userDTO)
    {
        var userEntity = userDTO.ToUserEntity();
        userEntity = await _userRepository.Create(userEntity);
        return userEntity.ToUserDTO();
    }
}