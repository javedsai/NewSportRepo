using System;
using System.Collections.Generic;
using System.Linq;
using CarouselView.FormsPlugin.iOS;
using SportDirect.iOS.Renderers;
using SportDirect.ViewModels;
using Foundation;
using UIKit;
using Acr.UserDialogs;

namespace SportDirect.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        private iOSIoCConfig _iocConfig;
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            _iocConfig = new iOSIoCConfig();
            App.Locator = new ViewModelLocator(_iocConfig);
            App.MainPageScreenWidth = (double)UIScreen.MainScreen.Bounds.Width;
            App.MainPageScreenHeight = (double)UIScreen.MainScreen.Bounds.Height;
            Rg.Plugins.Popup.Popup.Init();
            global::Xamarin.Forms.Forms.SetFlags("CollectionView_Experimental");
            global::Xamarin.Forms.Forms.SetFlags("IndicatorView_Experimental");
            global::Xamarin.Forms.Forms.Init();
            CarouselViewRenderer.Init();
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init();
            ImageCircleRenderer.Init();
            XF.Material.iOS.Material.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
