using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asp.net.LearningProject.Data;
using asp.net.LearningProject.Models.AdressModels;

namespace asp.net.LearningProject.Models.TownsModels
{
    public class SQLTownRepository : ITownRepository
    {
        private readonly MyProjectDBContext context;

        public SQLTownRepository(MyProjectDBContext context)
        {
            this.context = context;
        }
        public Town Add(Town town)
        {
            context.Towns.Add(town);
            context.SaveChanges();
            return town;
        }

        public Town Delete(int id)
        {
          var townToDelete =  context.Towns.Find(id);
            if(townToDelete != null)
            {
                context.Towns.Remove(townToDelete);
                context.SaveChanges();
            }

            return townToDelete;

        }

        public Town GetEmployee(int id)
        {
            return context.Towns.Find(id);
        }

        public IEnumerable<Town> GetTowns()
        {
            return context.Towns;
        }

        public Town Update(Town townChanges)
        {
            var town = context.Towns.Attach(townChanges);
            town.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return townChanges;
        }
    }
}
