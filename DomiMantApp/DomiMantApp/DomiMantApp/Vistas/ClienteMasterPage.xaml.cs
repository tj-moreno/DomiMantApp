
namespace DomiMantApp.Vistas
{
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClienteMasterPage : MasterDetailPage
    {
        public ClienteMasterPage()
        {
            InitializeComponent();
            App.Navigator = Navigator;
        }
    }
}