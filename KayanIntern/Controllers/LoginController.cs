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

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(string email, string password)
    {
        LoginVM loginVM = new LoginVM();
        loginVM.Email = email;
        loginVM.Password = password;

        var user = _User.Login(loginVM);


        if (user == null)
        {
            return RedirectToAction("Privacy", "Home");
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

            AuthenticationProperties properties = new AuthenticationProperties();

            if (rememberMe)
            {
                properties.AllowRefresh = true;
            }
            else
            {

                properties.AllowRefresh = false;

            }

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity), properties);
            return RedirectToAction("Index", "Dashboard");
        }

    }




}