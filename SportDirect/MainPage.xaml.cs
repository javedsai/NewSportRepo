using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportDirect.Interfaces;
using Xamarin.Forms;

namespace SportDirect
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : IMainView,IRootView
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = App.Locator.MainPage;
        }
    }
}
