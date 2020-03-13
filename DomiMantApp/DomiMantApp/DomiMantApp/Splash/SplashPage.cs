

namespace DomiMantApp.Splash
{
    using DomiMantApp.Modelos;
    using DomiMantApp.Repositorios;
    using DomiMantApp.VistasModelos;
    using Xamarin.Forms;
    using static Globals.Variables;
    using static Globals.Funciones;
    using DomiMantApp.Vistas;    
    using System.Collections.Generic;
    using System.Linq;
    using Lottie.Forms;

    public class SplashPage : ContentPage
    {
        //Image SplashImage;
        AnimationView img;

        public SplashPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            var sub = new AbsoluteLayout();

            img = new AnimationView {
                Animation= "loading-animation.json",
                Loop=true,
                AutoPlay=true,
                HeightRequest=250,
                WidthRequest=250
            };
                        
            AbsoluteLayout.SetLayoutFlags(img,
                AbsoluteLayoutFlags.PositionProportional);

            AbsoluteLayout.SetLayoutBounds(img,
                new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            sub.Children.Add(img);
            this.BackgroundColor = Color.FromHex("#000000");
            this.Content = sub;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await img.ScaleTo(1, 3000);
            await img.ScaleTo(0.9, 2600, Easing.Linear);
            await img.ScaleTo(150, 1200, Easing.Linear);

            using (var repoUsuario = new Repositorio<Usuarios>(GetDbPath()))
            {
                UsuarioActual = ((List<Usuarios>)repoUsuario.Buscar(u => u.EnSeccion.Equals(true))).FirstOrDefault();                

                if (UsuarioActual != null)
                {                    
                    Moderador_De_Vistas.ObtenerInstancia().Registro = new RegistroViewModel((int)TipoRegistroUsuarios.AgregarUsuario);

                    switch (UsuarioActual.Tipo)
                    {
                        case (int)TipoUsuario.Cliente:                            
                            Application.Current.MainPage = new ClienteMasterPage();
                            break;
                        case (int)TipoUsuario.Suplidor:
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

