using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace KayanIntern.KayanIntern.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
