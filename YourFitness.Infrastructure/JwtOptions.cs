namespace YourFitness.Infrastructure;

// JWT goes in Infrastructure because it depends on an external library

public class JwtOptions
{
    public string Issuer { get; set; } = "";
	public string Audience { get; set; } = "";
	public string SigningKey { get; set; } = "";
	public int ExpiryMinutes { get; set; } = 0;
}