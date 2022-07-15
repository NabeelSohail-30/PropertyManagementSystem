using PropertyManagementSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PropertyManagementSystemWebApp
{
    public partial class MainMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LblError.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            IUserAccountsRepo user = new UserAccountsRepo();    //Polymorphism
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

            //Get Role Default Page using userModel
            //if (userModel.UserAccountId > 0 && userModel.IsLogged == true && userModel.AccountLockedOut == false && userModel.Active == true)
            //{
            //    foreach (UserRolesModel role in userModel.UserRoles)
            //    {
            //        //Response.Write($"{role.RoleId} - {role.Role.RoleDescription} - {role.Role.DefaultPage} - {role.DefaultPageRole}<br>");
            //        if (role.DefaultPageRole)
            //        {
            //            Response.Redirect(role.Role.DefaultPage);
            //        }
            //    }
            //}

            //Get Default Page using UserRolesRepo.GetDefaultPage() Method after authentication

            if (userModel.UserAccountId > 0 && userModel.IsLogged == true && userModel.AccountLockedOut == false && userModel.Active == true)
            {
                Session["sUserModel"] = userModel;
                Session["sUserDefaulPage"] = user.GetDefaultPage(userModel.UserAccountId.ToString());
                FormsAuthentication.RedirectFromLoginPage(userModel.UserName, false);
                //Response.Redirect(user.GetDefaultPage(userModel.UserAccountId.ToString()));
                //Response.Redirect("MainMenu.aspx");
            }
        }
    }
}