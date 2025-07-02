using Microsoft.AspNetCore.Mvc;

namespace MvcProject.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}