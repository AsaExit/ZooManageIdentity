using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ZooManage.Models;

namespace ZooManage.Data
{
    public class ZooManageDbContext: IdentityDbContext<AppUser>// step 2
    {
        public ZooManageDbContext(DbContextOptions<ZooManageDbContext> options) : base(options) { }
        public DbSet<Animal>? Animals { get; set; }
        public DbSet<Veterinary>? Veterinaries { get; set; }
        public DbSet<Continent>?Continetns  { get; set; }
        public DbSet<Country>? Countries { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);



        //    modelBuilder.Entity<Animal>().HasData(new Animal { Id = 1, AnimalName = "Tiger", Species = "Mammel", AnimalNickName = "Lilla Missen" });
        //    modelBuilder.Entity<Animal>().HasData(new Animal { Id = 2, AnimalName = "Cow", Species = "Mammel", AnimalNickName = "Muis" });

        //    modelBuilder.Entity<Veterinary>().HasData(new Veterinary { Id = 1,Name="Jonas Berg ", VetId="MPX-676A"});
        //}
    }
}
