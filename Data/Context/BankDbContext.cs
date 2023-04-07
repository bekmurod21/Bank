using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context;

public class BankDbContext:DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string path = "Server=localhost; Database=Bank; User Id=postgres; password=Bekmurod21";
        optionsBuilder.UseNpgsql(path);
    }
    
    public DbSet<User> Users { get; set; }
}
