﻿namespace KayanIntern.ViewModels
{
    public class LoginVM
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAuthenticated { get; set; }
        public bool RememberMe { get; set; }
    }
}
