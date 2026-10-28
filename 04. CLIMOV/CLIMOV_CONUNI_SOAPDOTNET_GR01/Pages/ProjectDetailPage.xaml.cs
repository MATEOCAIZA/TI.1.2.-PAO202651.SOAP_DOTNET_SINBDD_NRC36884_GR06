using CLIMOV_CONUNI_SOAPDOTNET_GR01.Models;

namespace CLIMOV_CONUNI_SOAPDOTNET_GR01.Pages
{
    public partial class ProjectDetailPage : ContentPage
    {
        public ProjectDetailPage(ProjectDetailPageModel model)
        {
            InitializeComponent();

            BindingContext = model;
        }
    }
}
