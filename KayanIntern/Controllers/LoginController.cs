using KayanIntern.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KayanIntern.Controllers;

public class LoginController : Controller
{
    private readonly Repository.IUser.IUsers _User;

    public LoginController(Repository.IUser.IUsers user)
    {
        _User = user;
    }

    public IActionResult Index()
    {
        ClaimsPrincipal claimUser = HttpContext.User;

        if (claimUser.Identity.IsAuthenticated)
            return RedirectToAction("Index", "Dashboard");

        return View(new LoginVM { Email = "" });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(LoginVM loginVM)
    {
        var user = _User.Login(loginVM);

        if (user == null)
        {
            ModelState.AddModelError(String.Empty, "The Email or Password are incorrect");
            return View(new LoginVM { Email = "" });
        }
        else
        {
            var rememberMe = loginVM.RememberMe;
            List<Claim> claims = new List<Claim>() {
                    new Claim("Email", user.Email.ToString(), ClaimValueTypes.String),
                    new Claim("FirstName", user.FirstName.ToString(),ClaimValueTypes.String),
                    new Claim("LastName", user.LastName.ToString(), ClaimValueTypes.String),
                    new Claim("Birthday", user.Birthday.ToString(), ClaimValueTypes.String)

                };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                CookieAuthenticationDefaults.AuthenticationScheme);

            AuthenticationProperties properties = new AuthenticationProperties
            {
                AllowRefresh = true,
                IsPersistent = rememberMe
            };

            if (rememberMe)
            {
                properties.ExpiresUtc = DateTime.UtcNow.AddDays(3);
            }
            else
            {
                properties.IsPersistent = false;

            }

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity), properties);
            return RedirectToAction("Index", "Dashboard");
        }

    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        return RedirectToAction("Index", "Login");
    }
}