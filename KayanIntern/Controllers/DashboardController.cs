using Microsoft.AspNetCore.Mvc;

namespace KayanIntern.KayanIntern.Controllers.Base
{
    public class DashboardController : AuthorizationController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
