using asp.net.LearningProject.Models;
using asp.net.LearningProject.Models.AdressModels;


namespace asp.net.LearningProject.ViewModels
{
    public class EmployeeDetailsViewmodel
    {
        public Employee Employee { get; set; }

        public string Town { get; set; }

        public string PageTitle { get; set; }
    }
}
