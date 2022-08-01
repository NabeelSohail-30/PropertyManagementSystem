using PropertyManagementSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PropertyManagementSystemWebApp
{
    public partial class Master_Dashboard : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignout_Click(object sender, EventArgs e)
        {
            IUserAccountsRepo user = new UserAccountsRepo();    //Polymorphism
            UserAccountsModel userModel = new UserAccountsModel();

            userModel = (UserAccountsModel)Session["sUserModel"];

            user.SignOut(userModel.UserAccountId);

            Response.Redirect("MainMenu.aspx");
        }
    }
}