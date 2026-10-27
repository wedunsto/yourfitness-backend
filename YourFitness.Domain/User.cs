namespace YourFitness.Domain;

public class User
{
    public string Id { get; private set; } = "";
    public string Username { get; set; } = "";
    public string Password { get; set; } = "";
    public bool Onboarded { get; set; } = false;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    // Default constructor for EF Core
    private User() {}

    // Overloaded constructor for creating Users
    public User(string username, string password)
    {
        Username = username;
        Password = password;
    }
}
