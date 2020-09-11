using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace SportDirect.Services
{
    public class ConnectivityService
    {
        public static bool IsConnected()
        {
            var current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                return true;
            }
            return false;
        }
    }
}
