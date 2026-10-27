using YourFitness.Domain;
namespace YourFitness.Application;

public interface IUserRepository
{
    // Create a new user for insertion
    void AddAsync(User user);

    // Looks up a user by primary key
    Task<User?> GetUserAsync(string id);

    // Persists all staged changes to the database
    Task SaveChangesAsync();
}
