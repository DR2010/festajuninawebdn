using DanFestaJuninaCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DanFestaJuninaCore.ViewModels
{
    public class DishDetailsViewModel
    {
        public IEnumerable<Dish> DishVM { get; set; }
        public Dish SingleDish { get; set; }
        public string PageTitle { get; set; }

        public Helper.ControllerInfo Info { get; set; }
    }
}
