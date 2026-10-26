using Microsoft.EntityFrameworkCore;
using YourFitness.Domain;
using YourFitness.Application;

namespace YourFitness.Infrastructure;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    // Creates a repository backed by the given EF Core context
    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    // Implement the AddAsync function from the repository interface
    public void AddAsync(User user)
        => _context.Users.Add(user);

    // Implement the GetByIdAsync function from the repository interface
    public Task<User?> GetUserAsync(string id)
        => _context.Users.FirstOrDefaultAsync(user => user.Id == id);

    // Implement the SaveChangesAsync function from the repository interface
    public Task SaveChangesAsync()
        => _context.SaveChangesAsync();
}