using asp.net.LearningProject.Models.AdressModels;
using System.Collections.Generic;

namespace asp.net.LearningProject.Models.TownsModels
{
    public interface ITownRepository 
    {
        Town GetEmployee(int id);

        IEnumerable<Town> GetTowns();

        Town Add(Town town);

        Town Update(Town townChanges);

        Town Delete(int id);
    }
}
