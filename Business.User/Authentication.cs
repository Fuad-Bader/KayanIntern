using Dapper;
using KayanIntern.DataLayer;
using KayanIntern.EntityModels;
using System.Linq;

namespace KayanIntern.Business.User
{
    public class Authentication
    {
        public Authentication() { }
        public bool Authenticate(string email,string password)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("Email", email);
            param.Add("Password", password);

            object obj = DAL.ReturnList<KayanIntern.EntityModels.User>("SignIn", param).FirstOrDefault<KayanIntern.EntityModels.User>();
            
            if (obj != null)
            {
                return true;
            }
            return false;
        }
    }
}
