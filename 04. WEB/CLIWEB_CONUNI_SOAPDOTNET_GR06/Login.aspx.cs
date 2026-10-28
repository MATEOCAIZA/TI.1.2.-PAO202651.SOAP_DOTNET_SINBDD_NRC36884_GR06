using System;
using System.Web.UI;

namespace ec.edu.monster.vista
{
    public partial class LoginGr06 : Page
    {
        private const string ValidUsername = "MONSTER";
        private const string ValidPassword = "MONSTER69";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["LoggedIn"] as bool? == true)
                Response.Redirect("~/Default.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim() == ValidUsername && txtPassword.Text == ValidPassword)
            {
                Session["LoggedIn"] = true;
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                lblError.Text = "&#10007; Error de credenciales. Intente de nuevo.";
                txtPassword.Text = string.Empty;
            }
        }
    }
}
