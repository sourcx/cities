using Microsoft.EntityFrameworkCore;

namespace AspNetCoreApp.Data;

public class MvcCityContext : DbContext
{
    public MvcCityContext(DbContextOptions<MvcCityContext> options)
        : base(options)
    {
    }

    public DbSet<AspNetCoreApp.Models.City> City { get; set; } = default!;
}
