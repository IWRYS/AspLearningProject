using asp.net.LearningProject.Models.AdressModels;
using Microsoft.EntityFrameworkCore;

namespace asp.net.LearningProject.Models.ModelBuilderExtentions
{
    public static class ModelBuilderExtentions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Town>().HasData(
               new Town
               {
                   TownId = 1,
                   Region = "Region1",
                   Name = "Town1"
               },
               new Town
               {
                   TownId = 2,
                   Region = "Region2",
                   Name = "Town3"

               },
               new Town
               {
                   TownId = 3,
                   Region = "Region3",
                   Name = "Town3"

               });

            modelBuilder.Entity<Employee>().HasData(
            new Employee
            {
                EmployeeId = 1,
                Name = "George",
                Department = Models.EmployeesModels.Enums.Departament.Accounting,
                Email = "george@email.com",
                 TownId =2
            },
             new Employee
             {
                 EmployeeId = 2,
                 Name = "Pesho",
                 Department = Models.EmployeesModels.Enums.Departament.HR,
                 Email = "pesho@email.com",
                 TownId =1
                 

             }
            );

        }
    }
}
