using Microsoft.AspNetCore.Mvc;

namespace MvcProject.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DonVi()
        {
            return View();
        }
    }
}