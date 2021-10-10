using Android.App;
using Android.OS;

namespace SiPA.Prism.Droid
{
    [Activity(
        Theme = "@style/MainTheme.Splash",
        MainLauncher = true,
        NoHistory = true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            System.Threading.Thread.Sleep(1800);
            StartActivity(typeof(MainActivity));
        }
    }
}
