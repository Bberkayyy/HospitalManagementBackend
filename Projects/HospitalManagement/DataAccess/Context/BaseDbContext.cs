using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DataAccess.Context;

public class BaseDbContext : DbContext
{
    public BaseDbContext(DbContextOptions<BaseDbContext> options) : base(options)
    {

    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Hospital> Hospitals { get; set; }
    public DbSet<Title> Titles { get; set; }
}
