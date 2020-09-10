using Acr.UserDialogs;
using SportDirect.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SportDirect.Areas.Views.MasterDetailsPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenuMaster : IMainView, IRootView
    {
        public MainMenuMaster()
        {
            InitializeComponent();
            BindingContext = App.Locator.MainMenuMaster; 
        }        
    }
}