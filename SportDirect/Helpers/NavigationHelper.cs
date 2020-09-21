using System;
using System.Linq;
namespace SportDirect.Helpers
{
    public class NavigationHelper
    {
        public static bool CheckType(Type type)
        {
            if (App.Current.MainPage.Navigation.NavigationStack.Count > 0)
                return App.Current.MainPage.Navigation.NavigationStack.Last().GetType() != type;
            else
                return true;
        }
    }
}
