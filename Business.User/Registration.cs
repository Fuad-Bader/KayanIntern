using Dapper;
using KayanIntern.DataLayer;

namespace KayanIntern.Business.Users
{
    public class Registration
    {
        public Registration() { }

        public KayanIntern.EntityModels.User SignUp(KayanIntern.ViewModels.RegistrationVM registrationVM)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Email", registrationVM.Email);
            param.Add("@Password", registrationVM.Password);
            param.Add("@FirstName", registrationVM.FirstName);
            param.Add("@LastName", registrationVM.LastName);
            param.Add("@Id", registrationVM.ID);
            param.Add("@Birthday", registrationVM.Birthday);

            try
            {
                DAL.ExecuteWithoutReturn("SignUp", param);
                return new EntityModels.User()
                {
                    Email = registrationVM.Email,
                    Password = registrationVM.Password,
                    FirstName = registrationVM.FirstName,
                    LastName = registrationVM.LastName,
                    Birthday = registrationVM.Birthday,
                    ID = registrationVM.ID
                };
            }
            catch (Exception)
            {
                return new KayanIntern.EntityModels.User { Email = "GoofedUp", Password = "GoofedUp" };
            }

        }
    }
}
