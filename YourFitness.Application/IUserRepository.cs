using YourFitness.Domain;
namespace YourFitness.Application;

public interface IUserRepository
{
    // Create a new user for insertion
    void AddUserAsync(User user);

    // Looks up a user by username
    Task<User?> GetUserAsync(string username);

    // Persists all staged changes to the database
    Task SaveChangesAsync();
}
