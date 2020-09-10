using System;
using System.Collections.Generic;
using SportDirect.Areas.Views;
using SportDirect.Interfaces;
using Xamarin.Forms;
using XF.Material.Forms.UI;

namespace SportDirect
{
    public partial class AppShell : Shell,IRootView,IMainView, IShelll
    {
        Dictionary<string, Type> routes = new Dictionary<string, Type>();
        public Dictionary<string, Type> Routes { get { return routes; } }
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
            if (this.BindingContext is null)
            {
                this.BindingContext = App.Locator.AppShellPage;
            }
        }
        void RegisterRoutes()
        {
            routes.Add("home", typeof(Home));
            routes.Add("offersPage", typeof(OffersPage));
            routes.Add("blogsPage", typeof(BlogsPage)); 
            routes.Add("profilePage", typeof(ProfilePage));
            foreach (var item in routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }
    }
}
