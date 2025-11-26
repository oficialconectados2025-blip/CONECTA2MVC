using Microsoft.AspNetCore.Mvc;

namespace CONECTA2MVC.Controllers
{
    public class VideosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
