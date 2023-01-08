using Dent.Areas.Identity.Pages;
using Dent.Areas.Identity.Pages.Account;
using Dent.Data.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Dent.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Form>().Property(z => z.Id).UseIdentityColumn();
            builder.Entity<Form>().Property(z => z.Name).HasMaxLength(128);
            builder.Entity<Form>().Property(z => z.Email).HasMaxLength(128);
            builder.Entity<Form>().HasData(new Form
            {
                Id = 1,
                Name = "First",
                PhoneNumber = 0,
                Email = "None",
                ChoseProcedure = "None",
                ChoseDoctor = "None",
                CheckDoctor = DateTime.Now.AddYears(-20),
                Price = 0,
                Comments = ""
            });
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("Identity");
            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });
            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });
            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });
            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });
        }
        public DbSet<Form> Forms { get; set; }

    }
}