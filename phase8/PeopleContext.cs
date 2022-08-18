using Microsoft.EntityFrameworkCore;

namespace TopStudents;

public class PeopleContext : DbContext
{
    public DbSet<Student>? Students { get; set; }
    public DbSet<Grade>? Grades { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(@"Server=localhost;Database=postgres;Username=postgres;password=password");
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Grade>().HasKey(g=> new {g.StudentNumber, g.Lesson});
    }
    
}