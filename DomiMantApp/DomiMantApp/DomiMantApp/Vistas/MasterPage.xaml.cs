
namespace DomiMantApp.Vistas
{
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasterPage : MasterDetailPage
	{       
		public MasterPage ()
		{
            InitializeComponent();
            App.MDPageS = this;
            App.Navigator = Navigator;
        }
	}
}