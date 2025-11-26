using Microsoft.AspNetCore.Mvc;

namespace CONECTA2MVC.Controllers
{
    public class CursesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
