using KayanIntern.Business.User;
using KayanIntern.EntityModels;
using KayanIntern.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Security.AccessControl;
using System.Security.Claims;

namespace KayanIntern.Provider.User
{
    public class Users : KayanIntern.Repository.IUser.IUsers
    {
        public KayanIntern.EntityModels.User Login(LoginVM loginVM)
        {
            Authentication authentication = new Authentication();
            var user = authentication.Login(loginVM);

            if (user != null)
            {
                return user;
            }

            else
            {
                return null;
            }
        }
    }
}
