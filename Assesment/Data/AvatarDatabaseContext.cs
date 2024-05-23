using Assesment.Models;
using Microsoft.EntityFrameworkCore;

namespace Assesment.Data;

public class AvatarDatabaseContext : DbContext
{
    private readonly string _DBPath;

    public DbSet<AvatarImage> AvatarInfo { get; set; } = default;

    public AvatarDatabaseContext()
    {
        // TODO: This should be moved to configuration file
        _DBPath = "AvatarData.db";
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite($"Data Source={_DBPath}");
    }
}
