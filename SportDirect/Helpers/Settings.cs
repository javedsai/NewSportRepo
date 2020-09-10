using Plugin.Settings;
using Plugin.Settings.Abstractions;
using SportDirect.Data.Models.Response;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SportDirect.Helpers
{
   public class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }
      
        public static bool StoreData
        {
            get => AppSettings.GetValueOrDefault(nameof(StoreData),false);
            set => AppSettings.AddOrUpdateValue(nameof(StoreData), value);
        }
        public static bool IsWalkthroughCompleted
        {
            get => AppSettings.GetValueOrDefault(nameof(IsWalkthroughCompleted), false);
            set => AppSettings.AddOrUpdateValue(nameof(IsWalkthroughCompleted), value);
        }
        public static bool IsDarkMode
        {
            get => AppSettings.GetValueOrDefault(nameof(IsDarkMode), false);
            set => AppSettings.AddOrUpdateValue(nameof(IsDarkMode), value);
        }
        public static bool OrderNotiOnOffIsToggled
        {
            get => AppSettings.GetValueOrDefault(nameof(OrderNotiOnOffIsToggled), false);
            set => AppSettings.AddOrUpdateValue(nameof(OrderNotiOnOffIsToggled), value);
        }
        public static bool OffersNotiOnOffIsToggled
        {
            get => AppSettings.GetValueOrDefault(nameof(OffersNotiOnOffIsToggled), false);
            set => AppSettings.AddOrUpdateValue(nameof(OffersNotiOnOffIsToggled), value);
        }
        public static string notificationOnOff
        {
            get => AppSettings.GetValueOrDefault(nameof(notificationOnOff), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(notificationOnOff), value);

        }
        public static string orderNotiOnOff
        {
            get => AppSettings.GetValueOrDefault(nameof(orderNotiOnOff), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(orderNotiOnOff), value);

        }
        public static string offersNotiOnOff
        {
            get => AppSettings.GetValueOrDefault(nameof(offersNotiOnOff), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(offersNotiOnOff), value);

        }

        public static string Customer_Access_Token
        {
            get => AppSettings.GetValueOrDefault(nameof(Customer_Access_Token), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(Customer_Access_Token), value);
        }

        public static string Customer_FName
        {
            get => AppSettings.GetValueOrDefault(nameof(Customer_FName), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(Customer_FName), value);
        }

        public static string Customer_LName
        {
            get => AppSettings.GetValueOrDefault(nameof(Customer_LName), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(Customer_LName), value);
        }

        public static string Customer_Mobile
        {
            get => AppSettings.GetValueOrDefault(nameof(Customer_Mobile), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(Customer_Mobile), value);
        }
        public static string Customer_Email
        {
            get => AppSettings.GetValueOrDefault(nameof(Customer_Email), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(Customer_Email), value);
        }

        public static string Customer_Id
        {
            get => AppSettings.GetValueOrDefault(nameof(Customer_Id), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(Customer_Id), value);
        }
        public static string CheckoutId
        {
            get => AppSettings.GetValueOrDefault(nameof(CheckoutId), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(CheckoutId), value);
        }
        public static string AddressId
        {
            get => AppSettings.GetValueOrDefault(nameof(AddressId), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(AddressId), value);
        }

    }
}
