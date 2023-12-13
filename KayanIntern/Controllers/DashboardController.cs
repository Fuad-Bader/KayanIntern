using Microsoft.AspNetCore.Mvc;

namespace KayanInt2ern.KayanIntern.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
