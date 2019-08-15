
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DomiMantApp
{
    using DomiMantApp.Splash;
    using DomiMantApp.Vistas;    
    using Xamarin.Forms;

    public partial class App : Application
    {        
        #region Constructor
        public App()
        {
            InitializeComponent();
            MainPage = new SplashPage(); //new NavigationPage(new LoginPage());
        }
        #endregion
        #region Propiedades
        public static NavigationPage Navigator
        {
            get;
            internal set;
        }
        #endregion
        #region Metodos
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        } 
        #endregion
    }
}
