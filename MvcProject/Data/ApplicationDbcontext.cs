using Microsoft.EntityFrameworkCore;
using MvcProject.Models;
namespace MvcProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Person> Person { get; set; }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Daily> DaiLy { get; set; }
        public DbSet<HeThongPhanPhoi> HeThongPhanPhois{ get; set; }
    }
}