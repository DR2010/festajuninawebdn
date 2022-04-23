using DanFestaJuninaCore.Models;
using DanFestaJuninaCore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DanFestaJuninaCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public ViewResult Index()
        {
            HomeDetailsViewModel ddvm = new HomeDetailsViewModel();
            ddvm.Info = new Helper.ControllerInfo();
            ddvm.Info.IsAdmin = "Yes";
            ddvm.Info.IsAnonymous = "No";
            ddvm.Info.Name = "Initial Page";
            ddvm.Info.Database = "DanCore";
            ddvm.Info.Organisation = "NotYetDBDriven";

            return View(ddvm);
        }

        //public ViewResult Index()
        //{
        //    var model = _employeeRepository.GetAllEmployee();
        //    return View(model);
        //}


        /// <summary>
        /// If we want to respect the type being requested
        /// http://localhost:5000/home/detailsobject
        /// http://localhost:1980/home/detailsobject
        /// 
        /// if the header "Accept" is not supplied, JSON is returned
        /// 
        /// header: Accept: application/xml
        /// http://localhost:5000/home/detailsjson
        /// http://localhost:1980/home/detailsjson
        /// </summary>
        /// <returns></returns>
        public ObjectResult DetailsObject()
        {
            Employee model = _employeeRepository.GetEmployee(1);

            return new ObjectResult(model);
        }

        /// <summary>
        /// Return JSON
        /// </summary>
        /// <returns></returns>
        public JsonResult DetailsJson()
        {
            Employee model = _employeeRepository.GetEmployee(1);

            return Json(model);
        }

        /// <summary>
        /// The details using ViewResult will invoke the /Views/Home/Details.cshtml and show details where markup is done
        /// http://localhost:1980/home/details
        /// </summary>
        /// <returns></returns>
        public ViewResult DetailsY()
        {
            Employee model = _employeeRepository.GetEmployee(1);
            return View(model);
        }

        /// <summary>
        /// Return Test.cshtml from the Views/Home folder
        /// It replaces the default file name with "Test" using an overload for the View method
        /// http://localhost:1980/home/detailsx
        /// </summary>
        /// <returns></returns>
        public ViewResult DetailsX()
        {
            Employee model = _employeeRepository.GetEmployee(1);
            return View("Test");
            //return View("MyViews/Test.cshtml"); // absolute path requires the file extension
            //return View("../../MyViews/Test");  // relative path doesn't require a file extension
        }

        public ViewResult DetailsM()
        {
            Employee model = _employeeRepository.GetEmployee(1);
            ViewBag.PageTitle = "Employee Details";

            return View(model);
        }

        public ViewResult Details()
        {

            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                EmployeeVM = _employeeRepository.GetEmployee(1),
                PageTitle = "Employee Details"
            };

            return View(homeDetailsViewModel);
        }
    }
}
