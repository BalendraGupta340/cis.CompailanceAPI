using Microsoft.AspNetCore.Mvc;

namespace TruStage.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
