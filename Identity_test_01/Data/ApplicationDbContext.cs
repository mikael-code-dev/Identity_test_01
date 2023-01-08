using Identity_test_01.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity_test_01.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            string adminRoleId = new Guid().ToString();
            string managerRoleId = new Guid().ToString();
            string customerRoleId = new Guid().ToString();
            string adminUserId = new Guid().ToString();
            string managerUserId = new Guid().ToString();
            string customerUserId = new Guid().ToString();

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = adminRoleId,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = managerRoleId,
                    Name = "Manager",
                    NormalizedName = "MANAGER"
                },
                new IdentityRole
                {
                    Id = customerRoleId,
                    Name = "Customer",
                    NormalizedName = "CUSTOMER"
                });

            PasswordHasher<ApplicationUser> hasher = new PasswordHasher<ApplicationUser>();

            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = adminUserId,
                    Email = "admin@admin.com",
                    NormalizedEmail = "ADMIN@ADMIN.COM",
                    UserName = "admin@admin.com",
                    NormalizedUserName = "ADMIN@ADMIN.COM",
                    FirstName = "Admin",
                    LastName = "Adminsson",
                    PasswordHash = hasher.HashPassword(null, "1234")
                },
                new ApplicationUser
                {
                    Id = managerUserId,
                    Email = "manager@manager.com",
                    NormalizedEmail = "MANAGER@MANAGER.COM",
                    UserName = "manager@manager.com",
                    NormalizedUserName = "MANAGER@MANAGER.COM",
                    FirstName = "Manager",
                    LastName = "Managersson",
                    PasswordHash = hasher.HashPassword(null, "1234")
                },
                new ApplicationUser
                {
                    Id = customerRoleId,
                    Email = "customer@customer.com",
                    NormalizedEmail = "CUSTOMER@CUSTOMER.COM",
                    UserName = "customer@customer.com",
                    NormalizedUserName = "CUSTOMER@CUSTOMER.COM",
                    FirstName = "Customer",
                    LastName = "Customersson",
                    PasswordHash = hasher.HashPassword(null, "1234")
                });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = adminUserId
                },
                new IdentityUserRole<string>
                {
                    RoleId = managerRoleId,
                    UserId = managerUserId
                },
                new IdentityUserRole<string>
                {
                    RoleId = customerRoleId,
                    UserId = customerUserId
                });
        }


    }
}
