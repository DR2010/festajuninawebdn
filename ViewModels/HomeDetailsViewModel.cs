using DanFestaJuninaCore.Models;

namespace DanFestaJuninaCore.ViewModels
{
    public class HomeDetailsViewModel
    {
        public Employee EmployeeVM { get; set; }
        public string PageTitle { get; set; }
        public Helper.ControllerInfo Info { get; set; }

    }
}
