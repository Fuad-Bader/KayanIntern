using Microsoft.AspNetCore.Mvc;

namespace KayanIntern.Controllers;

public class Login : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}