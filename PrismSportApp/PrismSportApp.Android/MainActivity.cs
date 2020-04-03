using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Prism;
using Prism.Ioc;
using ImageCircle.Forms.Plugin.Droid;
using FFImageLoading.Svg.Forms;
using Xamarin.Forms;
using Lottie.Forms.Droid;
using FFImageLoading.Forms.Platform;

namespace PrismSportApp.Droid
{
    [Activity(Label = "Xport", Icon = "@mipmap/futbol", Theme = "@style/MyTheme.Splash", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            SetTheme(Resource.Style.MainTheme);
            
            base.OnCreate(savedInstanceState);                  
            Forms.SetFlags("CarouselView_Experimental");
         
            Window.SetStatusBarColor(Android.Graphics.Color.ParseColor("#303F9F"));
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            AnimationViewRenderer.Init();
            ImageCircleRenderer.Init();
           
            CachedImageRenderer.Init(true);
            var ignore = typeof(SvgCachedImage);
            LoadApplication(new App(new AndroidInitialize()));
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public class AndroidInitialize : IPlatformInitializer
        {
            public void RegisterTypes(IContainerRegistry containerRegistry)
            {

            }
        }
    }
}