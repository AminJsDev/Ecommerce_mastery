using Microsoft.EntityFrameworkCore;

namespace EM.Data.Context
{
    public class EmContext : DbContext
    {
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<UserInRole> UserInRoles { get; set; }
        public DbSet<Role> Roles { get; set; }

        public EmContext(DbContextOptions<EmContext> options) : base(options)
        {


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
