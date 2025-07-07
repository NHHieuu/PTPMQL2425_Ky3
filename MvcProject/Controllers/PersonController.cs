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
        [HttpPost] //phương thức bên thực thi post từ view lên controller asp-action
        public IActionResult Index(Person ps) //asp-action ="Index" hành động trùng ở view
        {
            string Output = "Xin chào" +  ps.PersonId  +  "-"  + ps.FullName +  "-"  +  ps.Address;
            ViewBag.infoPerson = Output; //gửi dữ liệu từ controller về View
            return View();
        }
    }
}
