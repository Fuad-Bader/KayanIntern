using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KayanIntern.KayanIntern.Controllers.Base
{
    [Authorize]
    public class DashboardController : AuthorizationController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }
    }
}
