using KayanIntern.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KayanIntern.KayanIntern.Controllers
{

    public class RegistrationController : Controller
    {
        private readonly Repository.IUser.IUsers _User;

        public RegistrationController(Repository.IUser.IUsers user)
        {
            _User = user;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(string email, string password, string firstName, string lastName, DateTime birthday)
        {
            RegistrationVM registrationVM = new RegistrationVM();
            registrationVM.Email = email;
            registrationVM.Password = password;
            registrationVM.FirstName = firstName;
            registrationVM.LastName = lastName;
            registrationVM.Birthday = birthday;

            var user = _User.SignUp(registrationVM);


            if (user == null)
            {
                return RedirectToAction("Privacy", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Login");

            };
        }

    }
}

