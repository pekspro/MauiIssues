using GeneralDatabase.CompiledModel;
using Microsoft.EntityFrameworkCore;

namespace GeneralDatabase;

public sealed class GeneralDatabaseContext : DbContext
{
    public string FileName;

    public GeneralDatabaseContext()
    {
        FileName = "?";
    }

    public GeneralDatabaseContext(string basePath)
    {
        FileName = Path.Combine(basePath, "generaldb.sqlite");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Command to update compiled model:
        // dotnet ef dbcontext optimize --context GeneralDatabaseContext --output-dir GeneralDatabase\CompiledModel --namespace MauiIssues.GeneralDatabase.CompiledModel

        optionsBuilder
            // .UseModel(GeneralDatabaseContextModel.Instance)
            .UseSqlite($"Data Source={FileName};");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {        
    }

    public DbSet<Blog> Blog { get; set; } = null!;
}
