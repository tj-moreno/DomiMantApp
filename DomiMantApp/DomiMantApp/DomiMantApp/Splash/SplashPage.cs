

namespace DomiMantApp.Splash
{
    using DomiMantApp.Modelos;
    using DomiMantApp.Repositorios;
    using DomiMantApp.VistasModelos;
    using Xamarin.Forms;
    using static Globals.Variables;
    using static Globals.Funciones;
    using DomiMantApp.Vistas;
    using FFImageLoading.Forms;
    using System.Collections.Generic;
    using System.Linq;

    public class SplashPage : ContentPage
    {
        //Image SplashImage;
        CachedImage img;

        public SplashPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            var sub = new AbsoluteLayout();

            img = new CachedImage {
                Source = "icon",
                WidthRequest = 250,
                HeightRequest = 250,
                RetryCount = 3,
                RetryDelay = 100,
                LoadingPlaceholder = "icon"
                //DownsampleToViewSize=true
            };
            
            AbsoluteLayout.SetLayoutFlags(img,
                AbsoluteLayoutFlags.PositionProportional);

            AbsoluteLayout.SetLayoutBounds(img,
                new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            sub.Children.Add(img);
            this.BackgroundColor = Color.FromHex("#000000");
            this.Content = sub;
        }

        protected override void OnAppearing()
        {
            //base.OnAppearing();
            //await img.ScaleTo(1, 3000);
            //await img.ScaleTo(0.9, 2600, Easing.Linear);
            //await img.ScaleTo(150, 1200, Easing.Linear);

            using (var repoUsuario = new Repositorio<Usuarios>(GetDbPath()))
            {
                UsuarioActual = ((List<Usuarios>)repoUsuario.Buscar(u => u.EnSeccion.Equals(true))).FirstOrDefault();                

                if (UsuarioActual != null)
                {
                    Moderador_De_Vistas.ObtenerInstancia().Registro = new RegistroViewModel();

                    switch (UsuarioActual.Tipo)
                    {
                        case TipoUsuario.Cliente:
                            Application.Current.MainPage = new ClienteMasterPage();
                            break;
                        case TipoUsuario.Suplidor:
                            Application.Current.MainPage = new MasterPage();
                            break;
                    }
                }
                else
                {
                    Moderador_De_Vistas.ObtenerInstancia().Login = new LoginViewModel();
                    Application.Current.MainPage = new NavigationPage(new LoginPage());
                }
            }
        }
    }
}

