﻿namespace KayanIntern.ViewModels
{
    public class LoginVM
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int IsAuthenticated { get; set; }
        public bool StayLoggedIn { get; set; }
    }
}
