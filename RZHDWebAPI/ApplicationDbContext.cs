using Microsoft.EntityFrameworkCore;

using RZHDWebAPI.Models;

namespace RZHDWebAPI
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
    }

}
