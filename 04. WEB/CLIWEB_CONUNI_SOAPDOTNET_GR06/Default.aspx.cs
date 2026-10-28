using System;
using System.Web.UI;
using ec.edu.monster.modelo;
using CLIWEB_CONUNI_SOAPDOTNET_GR06.ServiceReference1;

namespace ec.edu.monster.vista
{
    public partial class DefaultConverter : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] as bool? != true)
            {
                Response.Redirect("~/Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                ddlCategory.DataSource = UnitCatalog.Categories;
                ddlCategory.DataBind();
                ddlCategory.SelectedIndex = 0;
                BindUnits();
            }
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindUnits();
        }

        protected void btnConvert_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            lblResult.Text = string.Empty;

            if (!double.TryParse(txtValue.Text, out var value))
            {
                lblError.Text = "Valor invalido.";
                return;
            }

            try
            {
                using (var client = new Service1Client())
                {
                    var result = client.Convert(ddlCategory.SelectedValue, ddlFrom.SelectedValue, ddlTo.SelectedValue, value);
                    lblResult.Text = "Resultado: " + result + " " + ddlTo.SelectedValue;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error: " + ex.Message;
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Login.aspx");
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtValue.Text = string.Empty;
            lblResult.Text = string.Empty;
            lblError.Text = string.Empty;
            ddlCategory.SelectedIndex = 0;
            BindUnits();
        }

        private void BindUnits()
        {
            var units = UnitCatalog.GetUnits(ddlCategory.SelectedValue);
            ddlFrom.DataSource = units;
            ddlFrom.DataBind();

            ddlTo.DataSource = units;
            ddlTo.DataBind();

            if (ddlTo.Items.Count > 1)
                ddlTo.SelectedIndex = 1;
        }
    }
}
