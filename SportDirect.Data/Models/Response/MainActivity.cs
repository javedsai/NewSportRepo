using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Plugin.Permissions;
using Plugin.CurrentActivity;
using IMS.ViewModels;
using IMS.Droid.Renderers;
using Android.Content;
using IMS.Droid.Services;
using CarouselView.FormsPlugin.Android;
using Acr.UserDialogs;
using Octane.Xamarin.Forms.VideoPlayer.Android;
using Xamarin.Forms;

namespace IMS.Droid
{
    [Activity(Label = "IMS Consulting Group", Icon = "@drawable/AppIcon", Theme = "@style/MainTheme.Splash", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private AndroidIoCConfig _iocConfig;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            _iocConfig = new AndroidIoCConfig(this);
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            var pixelWidth = (double)Resources.DisplayMetrics.WidthPixels;
            var pixelHeight = (double)Resources.DisplayMetrics.HeightPixels;
            var density = (double)Resources.DisplayMetrics.Density;
            App.MainPageScreenWidth = (double)((pixelWidth - 0.5f) / density);
            App.MainPageScreenHeight = (double)((pixelHeight - 0.5f) / density);
            App.Locator = new ViewModelLocator(_iocConfig);
            base.SetTheme(Resource.Style.MainTheme);
            base.OnCreate(savedInstanceState);
            Rg.Plugins.Popup.Popup.Init(this, savedInstanceState);
            Forms.SetFlags("IndicatorView_Experimental");
            Forms.SetFlags("CollectionView_Experimental");
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            CarouselViewRenderer.Init();
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(enableFastRenderer: false);
            ImageCircleRenderer.Init();
            UserDialogs.Init(this);
            FormsVideoPlayer.Init();
            XF.Material.Droid.Material.Init(this, savedInstanceState);
            
            CrossCurrentActivity.Current.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

      
        public override void OnBackPressed()
        {
            if (Rg.Plugins.Popup.Popup.SendBackPressed(base.OnBackPressed))
            {
                System.Diagnostics.Debug.WriteLine("Android back button: There are some pages in the PopupStack");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Android back button: There are not any pages in the PopupStack");
            }
        }
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            MultiMediaPickerService.SharedInstance.OnActivityResult(requestCode, resultCode, data);
        }
    }
}