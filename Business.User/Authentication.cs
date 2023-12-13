using Dapper;
using KayanIntern.DataLayer;
using KayanIntern.EntityModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;

namespace KayanIntern.Business.User
{
    public class Authentication
    {
        public Authentication()
        {
        }
        public KayanIntern.EntityModels.User Login(KayanIntern.ViewModels.LoginVM loginVM)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("Email", loginVM.Email);
            param.Add("Password", loginVM.Password);

            try
            {
                var obj = DAL.ReturnList<KayanIntern.EntityModels.User>("SignIn", param).FirstOrDefault<KayanIntern.EntityModels.User>();
                return obj;
            }
            catch (Exception)
            {
                return new KayanIntern.EntityModels.User { Email = "error", Password = "error" };
            }


        }
    }
}
