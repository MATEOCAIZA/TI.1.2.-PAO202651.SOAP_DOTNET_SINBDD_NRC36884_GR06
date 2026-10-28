using System;
using System.Windows.Forms;
using ec.edu.monster.modelo;
using CLIESC_CONUNI_SOAPDOTNET_GR01.ServiceReference1;

namespace ec.edu.monster.vista
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadCategories();
        }

        private void LoadCategories()
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.AddRange(UnitCatalog.Categories);
            if (cmbCategory.Items.Count > 0)
            {
                cmbCategory.SelectedIndex = 0;
            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            var category = cmbCategory.SelectedItem as string;
            var units = UnitCatalog.GetUnits(category ?? string.Empty);

            cmbFrom.Items.Clear();
            cmbTo.Items.Clear();
            cmbFrom.Items.AddRange(units);
            cmbTo.Items.AddRange(units);

            if (cmbFrom.Items.Count > 0)
            {
                cmbFrom.SelectedIndex = 0;
            }

            if (cmbTo.Items.Count > 1)
            {
                cmbTo.SelectedIndex = 1;
            }
            else if (cmbTo.Items.Count > 0)
            {
                cmbTo.SelectedIndex = 0;
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtValue.Text, out var value))
            {
                MessageBox.Show("Valor invalido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var category = cmbCategory.SelectedItem as string;
            var fromUnit = cmbFrom.SelectedItem as string;
            var toUnit = cmbTo.SelectedItem as string;

            if (string.IsNullOrWhiteSpace(category) || string.IsNullOrWhiteSpace(fromUnit) || string.IsNullOrWhiteSpace(toUnit))
            {
                MessageBox.Show("Seleccione categoria y unidades.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var client = new Service1Client())
                {
                    var result = client.Convert(category, fromUnit, toUnit, value);
                    lblResult.Text = "Resultado: " + result + " " + toUnit;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Servicio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Program.RequestLogout();
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtValue.Clear();
            lblResult.Text = "Resultado:";
            if (cmbCategory.Items.Count > 0)
                cmbCategory.SelectedIndex = 0;
        }
    }
}
