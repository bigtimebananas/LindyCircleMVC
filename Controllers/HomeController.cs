using Microsoft.AspNetCore.Mvc;

namespace LindyCircleMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index() {
            return View();
        }
    }
}
