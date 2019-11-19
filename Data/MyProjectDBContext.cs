using asp.net.LearningProject.Models;
using Microsoft.EntityFrameworkCore;
using asp.net.LearningProject.Models.ModelBuilderExtentions;
using asp.net.LearningProject.Models.AdressModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace asp.net.LearningProject.Data
{
    public class MyProjectDBContext : IdentityDbContext
    {
        public MyProjectDBContext(DbContextOptions<MyProjectDBContext> options) 
            :base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Employee>()
                .HasOne(x => x.Town)
                .WithMany(e => e.Employees)
                .HasForeignKey(x=>x.TownId);
            modelBuilder.Seed();
                
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Town> Towns { get; set; }
    }
}
