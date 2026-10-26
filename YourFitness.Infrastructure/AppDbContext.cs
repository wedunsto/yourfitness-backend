using Microsoft.EntityFrameworkCore;
using YourFitness.Domain;

namespace YourFitness.Infrastructure;

public class AppDbContext: DbContext
{
    public AppDbContext (DbContextOptions<AppDbContext> options): base(options) { }

    public DbSet<User> Users => Set<User>();

    // Explicit field-to-column mapping
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(user =>
        {
            // Map the User entity class to the users database table name
            user.ToTable("users");

            // Map the primary key
            user.HasKey(user => user.Id);

            // Map User property 'Id' to database column 'id'
            user.Property(user => user.Id).HasColumnName("id");

            // Map User property 'Username' to database column 'username'
            user.Property(user => user.Username).HasColumnName("username");

            // Map User property 'Password' to database column 'password'
            user.Property(user => user.Password).HasColumnName("password");

            // Map User property 'Onboarded' to database column 'onboarded'
            user.Property(user => user.Onboarded).HasColumnName("onboarded");

            // Map User property 'CreatedAt' to database column 'created_at'
            user.Property(user => user.CreatedAt).HasColumnName("created_at");

            // Map User property 'UpdatedAt' to database column 'updated_at'
            user.Property(user => user.UpdatedAt).HasColumnName("updated_at");
        });
    }
}
