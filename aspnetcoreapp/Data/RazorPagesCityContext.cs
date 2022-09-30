using Microsoft.EntityFrameworkCore;

namespace AspNetCoreApp.Data;

public class RazorPagesCityContext : DbContext
{
    public RazorPagesCityContext(DbContextOptions<RazorPagesCityContext> options)
        : base(options)
    {
    }

    public DbSet<AspNetCoreApp.Models.City> City { get; set; } = default!;
}
