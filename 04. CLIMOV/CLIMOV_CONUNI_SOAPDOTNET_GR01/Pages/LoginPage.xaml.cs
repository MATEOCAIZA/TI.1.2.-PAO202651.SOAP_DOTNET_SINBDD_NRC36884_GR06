namespace CLIMOV_CONUNI_SOAPDOTNET_GR01.Pages
{
    public partial class LoginPage : ContentPage
    {
        private const string ValidUsername = "MONSTER";
        private const string ValidPassword = "MONSTER69";

        public LoginPage()
        {
            InitializeComponent();
        }

        private void OnLoginClicked(object sender, EventArgs e)
        {
            var username = UsernameEntry.Text?.Trim() ?? string.Empty;
            var password = PasswordEntry.Text ?? string.Empty;

            if (username == ValidUsername && password == ValidPassword)
            {
                Application.Current!.Windows[0].Page = new MainPage();
                return;
            }

            ErrorLabel.Text = "Error de credenciales. Intente de nuevo.";
            PasswordEntry.Text = string.Empty;
        }
    }
}