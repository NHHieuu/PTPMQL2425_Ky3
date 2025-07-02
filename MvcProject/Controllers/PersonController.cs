using Microsoft.AspNetCore.Mvc;
using MvcProject.Models;

namespace MvcProject.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Person ps)
        {
            string Output = "Xinchao" + ps.PersonId + "ten là" + ps.FullName + "đến từ" + ps.Address;
            ViewBag.Message = Output;
            return View();
        }
    }
}
