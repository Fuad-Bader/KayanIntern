using KayanIntern.Business.User;
using KayanIntern.Business.Users;
using KayanIntern.ViewModels;

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

        public KayanIntern.EntityModels.User SignUp(RegistrationVM registrationVM)
        {
            Registration registration = new Registration();
            var user = registration.SignUp(registrationVM);

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
