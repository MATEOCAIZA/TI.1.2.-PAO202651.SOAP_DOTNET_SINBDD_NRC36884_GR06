using CLIMOV_CONUNI_SOAPDOTNET_GR01.Models;
using ServiceReference1;

namespace CLIMOV_CONUNI_SOAPDOTNET_GR01.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            LoadCategories();
        }

        private void LoadCategories()
        {
            CategoryPicker.ItemsSource = UnitCatalog.Categories;
            CategoryPicker.SelectedIndex = 0;
            LoadUnits(UnitCatalog.Categories[0]);
        }

        private void LoadUnits(string? category)
        {
            var units = UnitCatalog.GetUnits(category);
            FromPicker.ItemsSource = units;
            ToPicker.ItemsSource = units;

            if (units.Length > 0)
            {
                FromPicker.SelectedIndex = 0;
                ToPicker.SelectedIndex = units.Length > 1 ? 1 : 0;
            }
        }

        private void OnCategoryChanged(object sender, EventArgs e)
        {
            LoadUnits(CategoryPicker.SelectedItem?.ToString());
        }

        private async void OnConvertClicked(object sender, EventArgs e)
        {
            ErrorLabel.Text = string.Empty;

            var category = CategoryPicker.SelectedItem?.ToString();
            var fromUnit = FromPicker.SelectedItem?.ToString();
            var toUnit = ToPicker.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(category) || string.IsNullOrWhiteSpace(fromUnit) || string.IsNullOrWhiteSpace(toUnit))
            {
                ErrorLabel.Text = "Seleccione categoría y unidades.";
                return;
            }

            if (!double.TryParse(ValueEntry.Text, out var value))
            {
                ErrorLabel.Text = "Ingrese un valor numérico válido.";
                return;
            }

            try
            {
                ResultLabel.Text = "Convirtiendo...";
                using var client = new Service1Client();
                var result = await client.ConvertAsync(category, fromUnit, toUnit, value);
                ResultLabel.Text = $"{value:0.####} {fromUnit} = {result:0.####} {toUnit}";
            }
            catch (Exception ex)
            {
                ResultLabel.Text = "0";
                ErrorLabel.Text = ex.Message;
            }
        }

        private void OnClearClicked(object sender, EventArgs e)
        {
            CategoryPicker.SelectedIndex = 0;
            LoadUnits(UnitCatalog.Categories[0]);
            ValueEntry.Text = string.Empty;
            ResultLabel.Text = "0";
            ErrorLabel.Text = string.Empty;
        }

        private void OnLogoutClicked(object sender, EventArgs e)
        {
            Application.Current!.Windows[0].Page = new LoginPage();
        }
    }
}