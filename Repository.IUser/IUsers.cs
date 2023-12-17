namespace KayanIntern.Repository.IUser
{
    public interface IUsers
    {
        public KayanIntern.EntityModels.User Login(KayanIntern.ViewModels.LoginVM loginVM);
        public KayanIntern.EntityModels.User SignUp(KayanIntern.ViewModels.RegistrationVM registrationVM);
    }
}
