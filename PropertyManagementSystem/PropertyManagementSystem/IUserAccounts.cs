using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagementSystem
{
    interface IUserAccounts
    {
        int AuthenticateLogin(string pUserName, string pPassword);  //returns UserAccountId

        UserAccountsModel GetUserById(int pUserAccountId);  //returns complete user detail against id
    }
}
