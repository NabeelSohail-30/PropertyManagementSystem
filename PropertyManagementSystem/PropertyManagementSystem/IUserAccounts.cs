using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagementSystem
{
    interface IUserAccounts
    {
        UserAccountsAuthenticateModel AuthenticateLogin(string pUserName, string pPassword);  

        UserAccountsModel GetUserById(int pUserAccountId);  //returns complete user detail against id

        int AddUser(UserAccountsModel user);

        void SignOut();
    }
}
