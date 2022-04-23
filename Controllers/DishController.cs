
using DanFestaJuninaCore.Models;
using DanFestaJuninaCore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading.Tasks;


namespace DanFestaJuninaCore.Controllers
{
    public class DishController : Controller
    {
        // The dependency is being injected at runtime
        // This is the important concept for this study

        private readonly IDishRepository _dishRepository;

        private IOptions<DanAppSettings> danAppSettings { get; set; }

        public DishController(IDishRepository dishRepository, IOptions<DanAppSettings> settings)
        {
            _dishRepository = dishRepository;
            danAppSettings = settings;
        }

        public async Task<IActionResult> Index()
        {
            //var model = await _dishRepository.GetAllDishes();
            //return View(model);

            var listofdishes = await _dishRepository.GetAllDishes(danAppSettings);

            DishDetailsViewModel ddvm = new DishDetailsViewModel();
            ddvm.DishVM = listofdishes;
            ddvm.Info = new Helper.ControllerInfo();
            ddvm.Info.IsAdmin = "Yes";
            ddvm.Info.IsAnonymous = "No";
            ddvm.Info.Name = "List of Dishes";

            return View("../../Views/Dish/DishListDetails", ddvm);
            //return View(ddvm);
        }

        public async Task<IActionResult> DishListPictures()
        {
            var listofdishes = await _dishRepository.GetAllDishes(danAppSettings);
             
            DishDetailsViewModel ddvm = new DishDetailsViewModel();
            ddvm.DishVM = listofdishes;
            ddvm.Info = new Helper.ControllerInfo();
            ddvm.Info.IsAdmin = "Yes";
            ddvm.Info.IsAnonymous = "No";
            ddvm.Info.Name = "List of Dishes";

            return View("../../Views/Dish/DishListPictures", ddvm);
        }

        public async Task<IActionResult> DishListDetails()
        {
            var listofdishes = await _dishRepository.GetAllDishes(danAppSettings);

            DishDetailsViewModel ddvm = new DishDetailsViewModel();
            ddvm.DishVM = listofdishes;
            ddvm.Info = new Helper.ControllerInfo();
            ddvm.Info.IsAdmin = "Yes";
            ddvm.Info.IsAnonymous = "No";
            ddvm.Info.Name = "List of Dishes";

            return View("../../Views/Dish/DishListDetails",ddvm);
        }
        
        public ViewResult Details()
        {

            DishDetailsViewModel dishDetailsViewModel = new DishDetailsViewModel();
            var sd = _dishRepository.GetDish("Feijoada");
            dishDetailsViewModel.SingleDish = sd.Result;
            dishDetailsViewModel.PageTitle = "Employee Details";

            return View(dishDetailsViewModel);
        }


        public async Task<IActionResult> DishUpdateDisplay()
        {
            var listofdishes = await _dishRepository.GetAllDishes(danAppSettings);

            DishDetailsViewModel ddvm = new DishDetailsViewModel();
            ddvm.DishVM = listofdishes;
            ddvm.Info = new Helper.ControllerInfo();
            ddvm.Info.IsAdmin = "Yes";
            ddvm.Info.IsAnonymous = "No";
            ddvm.Info.Name = "List of Dishes";
            ddvm.SingleDish = new Dish();

            // Have to use Linq to have access to the method extension endpoint
            //
            ddvm.SingleDish = ddvm.DishVM.First(); // Get first element

            return View("../../Views/Dish/DishUpdate", ddvm);
        }

        public async Task<IActionResult> DishViewDisplay()
        {
            var listofdishes = await _dishRepository.GetAllDishes(danAppSettings);

            DishDetailsViewModel ddvm = new DishDetailsViewModel();
            ddvm.DishVM = listofdishes;
            ddvm.Info = new Helper.ControllerInfo();
            ddvm.Info.IsAdmin = "Yes";
            ddvm.Info.IsAnonymous = "No";
            ddvm.Info.Name = "List of Dishes";
            ddvm.SingleDish = new Dish();

            string dishname = HttpContext.Request.Query["dishname"];

            // Have to use Linq to have access to the method extension endpoint
            //

            // Get first element
            // ddvm.SingleDish = ddvm.DishVM.First(); 

            // Get element using criteria
            ddvm.SingleDish = ddvm.DishVM.Single( dish => dish.Name == dishname); 

            return View("../../views/dish/dishupdate", ddvm);
        }

        [HttpPost]
        public async Task<IActionResult> DishUpdate()
        {
            // Get details from HTML form
            Dish dish = new Dish();
            dish.Id = Request.Form["dishid"];   
            dish.Name = Request.Form["dishname"];   
            dish.Type = Request.Form["dishtype"];
            dish.Price = Request.Form["dishprice"];
            dish.GlutenFree = Request.Form["dishglutenfree"];
            dish.DairyFree = Request.Form["dishdairyfree"];
            dish.Vegetarian = Request.Form["dishvegetarian"];

            dish.InitialAvailable = Request.Form["dishinitialavailable"];
            dish.CurrentAvailable = Request.Form["dishcurrentavailable"];
            dish.ImageName = Request.Form["dishimagename"];
            dish.Description = Request.Form["dishdescription"];
            dish.Descricao = Request.Form["dishdescricao"];
            dish.ActivityType= Request.Form["dishactivitytype"];

            dish.ActivityType = Request.Form["dishactivitytype"];
            dish.InitialAvailable = Request.Form["dishinitialavailable"];
            dish.CurrentAvailable = Request.Form["dishcurrentavailable"];

            var dishresult = await _dishRepository.UpdateDish(dish);

            // -------------------------------------------
            var listofdishes = await _dishRepository.GetAllDishes(danAppSettings);

            DishDetailsViewModel ddvm = new DishDetailsViewModel();
            ddvm.DishVM = listofdishes;
            ddvm.Info = new Helper.ControllerInfo();
            ddvm.Info.IsAdmin = "Yes";
            ddvm.Info.IsAnonymous = "No";
            ddvm.Info.Name = "List of Dishes";

            return View("../../Views/Dish/DishListDetails", ddvm);

        }

    }
}
