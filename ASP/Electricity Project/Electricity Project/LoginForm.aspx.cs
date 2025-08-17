using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Electricity_Project
{
    public partial class LoginForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPass.Text;

            if (username == "admin" && password == "admin123")
            {
                Response.Redirect("AdminForm.aspx");
            }
            else
            {
                lblMessage.Text = "Invalid login credentials.";
            }
        }

    }
}


