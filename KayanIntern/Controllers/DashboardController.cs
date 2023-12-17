using Microsoft.AspNetCore.Mvc;

namespace KayanIntern.KayanIntern.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
