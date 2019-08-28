
namespace DomiMantApp.Droid
{
    using System.Threading.Tasks;
    using Android.App;
    using Android.Content;
    using Android.OS;

    [Activity(Label ="DomiMant App", Theme ="@style/Theme.Splash", MainLauncher =false, NoHistory =true)]
    public class SplashActivity: Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            StartActivity(typeof(MainActivity));
        }

        //protected override void OnResume()
        //{
        //    base.OnResume();
        //    Task startupwork = new Task(() => { SimulateStarUp(); });
        //    startupwork.Start();
        //}

        //async void SimulateStarUp()
        //{
        //    await Task.Delay(200);
        //    StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        //}
    }
}