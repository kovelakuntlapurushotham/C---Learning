using Microsoft.EntityFrameworkCore;
using UserManagement.Models;

namespace UserManagement.Data
{
    public class UserManagementContext : DbContext
    {
        public UserManagementContext(DbContextOptions<UserManagementContext> options ): base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seeding the Role entity first
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    RoleName = "Admin"
                }
            );

            // Seeding the Users entity with hardcoded values
            modelBuilder.Entity<Users>().HasData(
                new Users
                {
                    Id = 1, // Make sure this ID is unique and doesn't conflict with other records
                    Name = "Raj",
                    Password = "raj123", // It's recommended to hash the password, but for seeding, you can leave it as plaintext
                    Email = "Raj@gmail.com",
                    IsUserAccountDeleted = false,
                    CreatedAt = new DateTime(2025, 3, 22), // Static DateTime value
                                                           // Assuming the Users table has a foreign key to Role
                    RoleId = 1 // Ensure you reference the RoleId if there's a relationship
                }
            );

            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Users> Users { get; set; }

        public DbSet<Role> Roles { get; set; }
    }
}
