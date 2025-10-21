using MicroLibraryAPI.Infrastructure.Data;
using MicroLibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroLibraryAPI.Features.Users.Repositories;

public class UserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User?> GetUser(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<User?> PostUser(User user)
    {
        _context.Add(user);
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<User?> PutUser(int id, User userUpdate)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
        {
            return null;
        }

        user.Email = userUpdate.Email;
        user.UserType = userUpdate.UserType;

        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<bool> DeleteUser(int id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
        {
            return false;
        }

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return true;
    }
}