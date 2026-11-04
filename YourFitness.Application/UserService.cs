/**
 * Contains the business logic related to Users
 * Uses the repository to read and write Users, and applies the business rules
 */

 using YourFitness.Domain;

 namespace YourFitness.Application;

 public class UserService
{
    private readonly IUserRepository _repository;
    private readonly ITokenService _tokenService;

    public UserService(IUserRepository repository, ITokenService tokenService)
    {
        _repository = repository;
        _tokenService = tokenService;
    }

    // Create a new user
    public async Task Register(string username, string password)
    {
        var newUser = new User(username, password);
        _repository.AddUserAsync(newUser);
        await _repository.SaveChangesAsync();
    }

    // Get an existing user
    public async Task<string?> Login(string username, string password)
    {
        var existingUser = await _repository.GetUserAsync(username);

        if (existingUser is null ||  existingUser?.Password != password)
        {
            return null;
        }

        return _tokenService.CreateToken(existingUser);
    }
}