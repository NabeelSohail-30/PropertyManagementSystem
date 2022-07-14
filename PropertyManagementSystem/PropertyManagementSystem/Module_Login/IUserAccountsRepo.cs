using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagementSystem
{
    public interface IUserAccountsRepo
    {
        UserAccountsModel AuthenticateLogin(string pUserName, string pPassword);

        UserAccountsModel Find(int pUserAccountId);  //returns complete user detail against id
        UserAccountsModel Find(string pUserName);  //returns complete user detail against username

        int AddUser(UserAccountsModel user);
        string GetDefaultPage(int pRoleId);
        string GetDefaultPage(string pUserAccountId);

        void SignOut(int UserId);
    }
}
