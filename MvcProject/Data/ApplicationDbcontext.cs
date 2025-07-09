using Microsoft.EntityFrameworkCore;
using MvcProject.Models;
namespace MvcProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Person> Person { get; set; }
        
        public DbSet<Thuchanh9th7> Thuchanh9th7 { get; set; }
    }
}