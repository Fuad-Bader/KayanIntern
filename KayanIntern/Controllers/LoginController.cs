using Dapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace KayanIntern.Controllers;

public class LoginController : Controller
{
    private readonly Repository.IUser.IUsers _User;

    public LoginController(Repository.IUser.IUsers user) 
    { 
        _User = user;
    }

    public IActionResult Login()
    {
        ClaimsPrincipal claimUser = HttpContext.User;

        if (claimUser.Identity.IsAuthenticated)
            return RedirectToAction("Index", "Home");

        return View();
    }
    [HttpPost]
    public IActionResult Login(string email, string password)
    {
        if (!_User.Login(email, password))
        {
            return RedirectToAction("Privacy", "Home");
        }
        return RedirectToAction("Index", "Home");
    }

    


}