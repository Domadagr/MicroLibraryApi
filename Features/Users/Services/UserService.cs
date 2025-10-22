using MicroLibraryAPI.Features.Users.Repositories;
using MicroLibraryAPI.Models;

namespace MicroLibraryAPI.Features.Users.Services;

public class UserService
{
    private readonly UserRepository _userRepository;

    public UserService(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<User>> GetUsers()
    {
        return await _userRepository.GetUsers();
    }

    public async Task<User?> GetUser(int id)
    {
        return await _userRepository.GetUser(id);
    }

    public async Task<User?> PostUser(User user)
    {
        return await _userRepository.PostUser(user);
    }

    public async Task<User?> PutUser(int id, User user)
    {
        return await _userRepository.PutUser(id, user);
    }

    public async Task<User?> DeleteUser(int id)
    {
        return await _userRepository.DeleteUser(id);
    }
}