namespace YourFitness.Domain;

public class User
{
    public string Id { get; private set; } = "";
    public string Username { get; set; } = "";
    public bool Onboarded { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now; 
}
