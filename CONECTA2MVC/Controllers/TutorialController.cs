using Microsoft.AspNetCore.Mvc;

namespace CONECTA2MVC.Controllers
{
    public class TutorialController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
