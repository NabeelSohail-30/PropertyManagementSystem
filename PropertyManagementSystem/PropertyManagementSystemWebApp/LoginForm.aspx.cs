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
            UserAccountsModel userModel = new UserAccountsModel();

            try
            {
                userModel = user.AuthenticateLogin(TxtUserName.Text, TxtPassword.Text);
            }
            catch (NullReferenceException)
            {
                LblError.Text = "User Name or Password cannot be NULL";
                LblError.Visible = true;
            }
            catch (Exception ex)
            {
                LblError.Text = ex.Message;
                LblError.Visible = true;
            }

            if(userModel.UserAccountId > 0 && userModel.IsLogged == true && userModel.AccountLockedOut == false && userModel.Active == true)
            {
                Response.Redirect("https://www.Google.com");
            }
            
        }
    }
}