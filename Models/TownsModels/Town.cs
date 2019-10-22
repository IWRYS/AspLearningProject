using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace asp.net.LearningProject.Models.AdressModels
{
    public class Town
    {
        public int TownId { get; set; }

        public string Region { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Employee> Employees { get; set; }

    }


}
