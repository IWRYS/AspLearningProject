using asp.net.LearningProject.Models;
using Microsoft.EntityFrameworkCore;
using asp.net.LearningProject.Models.ModelBuilderExtentions;
using asp.net.LearningProject.Models.AdressModels;

namespace asp.net.LearningProject.Data
{
    public class MyProjectDBContext : DbContext
    {
        public MyProjectDBContext(DbContextOptions<MyProjectDBContext> options) 
            :base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasOne(x => x.Town).WithMany(x => x.Employees);
            modelBuilder.Seed();
                
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Town> Towns { get; set; }
    }
}
