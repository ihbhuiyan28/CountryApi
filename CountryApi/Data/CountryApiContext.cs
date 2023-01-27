using Microsoft.EntityFrameworkCore;
using CountryApi.Models;

namespace CountryApi.Data;

public class CountryApiContext : DbContext
{
    public CountryApiContext(DbContextOptions<CountryApiContext> options)
        : base(options)
    {
    }
    public DbSet<Country> Countries { get; set; } = null!;
}
