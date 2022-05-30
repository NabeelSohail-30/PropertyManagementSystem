using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PropertyManagementSystem;

namespace PropertyManagementSystemWebApp
{
    public partial class LoginForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LblError.Visible = false;
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            UserAccountsRepo user = new UserAccountsRepo();
            UserAccountsAuthenticateModel userModel = new UserAccountsAuthenticateModel();
            userModel = user.AuthenticateLogin(TxtUserName.Text, TxtPassword.Text);

            if(userModel.UserAccountId > 0)
            {
                Response.Redirect("https://www.Google.com");
            }

            if(userModel.UserAccountId == 0 && userModel.IsLogged == true && userModel.AllowMultipleLogin == false)
            {
                LblError.Text = "User Authentication Failed, User is already logged in";
                LblError.Visible = true;
            }

            if(userModel.UserAccountId == 0 && userModel.AccountLockedOut == true)
            {
                LblError.Text = "Your account is locked, Contact System Administration";
                LblError.Visible = true;
            }

            if (userModel.UserAccountId == 0 && userModel.Active == false)
            {
                LblError.Text = "Your account is not active, Contact System Administration";
                LblError.Visible = true;
            }

            if (userModel.UserAccountId == 0 && userModel.AccountLockedOut==false && userModel.Active == true)
            {
                LblError.Text = "Invalid Password, User Authentication Failed";
                LblError.Visible = true;
            }

            if(userModel.UserAccountId == 0 && userModel.Active == false && userModel.AccountLockedOut == true)
            {
                LblError.Text = "User Authentication Failed, User not found";
                LblError.Visible = true;
            }
        }
    }
}