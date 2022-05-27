using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyManagementSystem;

namespace PropertyManagementSystem
{
    class UserAccountsModel : UserAccountsAuthenticateModel
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public char PasswordSalt { get; set; }
        public string Mobile { get; set; }
        public bool TwoFactorAuthentication { get; set; }
        public int WrongAttempts { get; set; }
        public DateTime LastLoginDateTime { get; set; }
        public DateTime LastLoggedOutDateTime { get; set; }
        public bool IsLogged { get; set; }
        public bool AllowMultipleLogin { get; set; }
    }
}

