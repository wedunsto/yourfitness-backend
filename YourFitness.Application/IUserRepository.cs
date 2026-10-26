using YourFitness.Domain;
namespace YourFitness.Application;

public class IUserRepository
{
    // Create a new user for insertion
    void AddSync(User user);

    // Looks up a user by primary key
    Task<User?> GetByIdAsync(string id);

    // Persists all staged changes to the database
    Task SaveChangesAsync();
}
