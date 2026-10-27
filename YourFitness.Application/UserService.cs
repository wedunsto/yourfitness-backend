/**
 * Contains the business logic related to Users
 * Uses the repository to read and write Users, and applies the business rules
 */

 using YourFitness.Domain;

 namespace YourFitness.Application;

 public class UserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    // Create a new user
    public async void Register(string username, string password)
    {
        var newUser = new User(username, password);
        _repository.AddUserAsync(newUser);
        await _repository.SaveChangesAsync();
    }

    // Get an existing user
    public async Task<string> Login(string username, string password)
    {
        var existingUser = await _repository.GetUserAsync(username);

        if (existingUser?.Password != password)
        {
            return "Invalid credentials";
        }
        return "Valid credentials";
    }
}