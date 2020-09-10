using System;
using System.Threading.Tasks;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms;
using XF.Material.Forms.UI.Dialogs;
using XF.Material.Forms.UI.Dialogs.Configurations;

namespace SportDirect.Helpers
{
    public static class PermissionUtil
    {

        public static async Task<PermissionStatus> CheckPermissions(Permission permission)
        {
            var permissionStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(permission);
            bool request = false;
            if (permissionStatus == PermissionStatus.Denied)
            {
                if (Device.RuntimePlatform == Device.iOS)
                {

                    var title = $"{permission} Permission";
                    var question = $"To use this plugin the {permission} permission is required. Please go into Settings and turn on {permission} for the app.";
                    var positive = "Settings";
                    var negative = "Maybe Later";
                    var task = Application.Current?.MainPage?.DisplayAlert(title, question, positive, negative);
                    if (task == null)
                        return permissionStatus;

                    var result = await task;
                    if (result)
                    {
                        CrossPermissions.Current.OpenAppSettings();
                    }

                    return permissionStatus;
                }

                request = true;

            }

            if (request || permissionStatus != PermissionStatus.Granted)
            {
                var newStatus = await CrossPermissions.Current.RequestPermissionsAsync(permission);

                if (!newStatus.ContainsKey(permission))
                {
                    return permissionStatus;
                }

                permissionStatus = newStatus[permission];

                if (newStatus[permission] != PermissionStatus.Granted)
                {
                    permissionStatus = newStatus[permission];
                    var title = $"{permission} Permission";
                    var question = $"To use the plugin the {permission} permission is required.";
                    var positive = "Settings";
                    var negative = "Maybe Later";
                    var task = Application.Current?.MainPage?.DisplayAlert(title, question, positive, negative);
                    if (task == null)
                        return permissionStatus;

                    var result = await task;
                    if (result)
                    {
                        CrossPermissions.Current.OpenAppSettings();
                    }
                    return permissionStatus;
                }
            }

            return permissionStatus;
        }


        public static async Task<bool> CheckPermissionsForPicDocAsync()
        {
            var alertDialogConfiguration = new MaterialAlertDialogConfiguration
            {
                BackgroundColor = (Color)App.AppInstance.Resources["PrimaryColor"],
                TitleTextColor = (Color)App.AppInstance.Resources["Text2ColorBold"],
                MessageTextColor = (Color)App.AppInstance.Resources["Text2Color"],
                TintColor = (Color)App.AppInstance.Resources["Text2ColorBold"],
                CornerRadius = 8,
                ButtonAllCaps = false
            };
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);
                if (status == PermissionStatus.Denied)
                {
                    if (Device.RuntimePlatform == Device.iOS)
                    {
                       var result = await MaterialDialog.Instance.ConfirmAsync(message: "Storage Permission is required. Please go into Settings and turn on Storage for the app.",
                                    confirmingText: "Settings",
                                    dismissiveText: "Maybe Later", configuration: alertDialogConfiguration);
                        if (result == true)
                        {
                            CrossPermissions.Current.OpenAppSettings();
                        }
                        return false;
                    }
                }
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Storage))
                    {
                        await MaterialDialog.Instance.AlertAsync("Storage permission is needed for file picking", configuration: alertDialogConfiguration);
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Storage);

                    if (results.ContainsKey(Permission.Storage))
                    {
                        status = results[Permission.Storage];
                    }
                }

                if (status == PermissionStatus.Granted)
                {
                    return true;
                }
                else if (status != PermissionStatus.Unknown)
                {
                    await MaterialDialog.Instance.AlertAsync("Storage permission was denied.", configuration: alertDialogConfiguration);
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static async Task<bool> CheckPermissionsForCameraAsync()
        {
            var alertDialogConfiguration = new MaterialAlertDialogConfiguration
            {
                BackgroundColor = (Color)App.AppInstance.Resources["PrimaryColor"],
                TitleTextColor = (Color)App.AppInstance.Resources["Text2ColorBold"],
                MessageTextColor = (Color)App.AppInstance.Resources["Text2Color"],
                TintColor = (Color)App.AppInstance.Resources["Text2ColorBold"],
                CornerRadius = 8,
                ButtonAllCaps = false
            };
            try
            {
                var storageStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);
                var cameraStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
                if (storageStatus == PermissionStatus.Denied|| cameraStatus == PermissionStatus.Denied)
                {
                    if (Device.RuntimePlatform == Device.iOS)
                    {
                        var result = await MaterialDialog.Instance.ConfirmAsync(message: "Storage & Camera Permission is required. Please go into Settings and turn on Storage,Camera for the app.",
                                     confirmingText: "Settings",
                                     dismissiveText: "No",configuration: alertDialogConfiguration);
                        if (result == true)
                        {
                            CrossPermissions.Current.OpenAppSettings();
                        }
                        return false;
                    }
                }
                if (storageStatus != PermissionStatus.Granted || cameraStatus != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Storage))
                    {
                        await MaterialDialog.Instance.AlertAsync("Storage & Camera permission is needed for to access camera", configuration: alertDialogConfiguration);
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Camera, Permission.Storage });
                    if (results.ContainsKey(Permission.Storage))
                    {
                        storageStatus = results[Permission.Storage];
                    }
                    if(results.ContainsKey(Permission.Camera))
                    {
                        cameraStatus = results[Permission.Camera];
                    }
                }

                if (storageStatus == PermissionStatus.Granted && cameraStatus == PermissionStatus.Granted)
                {
                    return true;
                }
                else if (storageStatus != PermissionStatus.Unknown|| cameraStatus != PermissionStatus.Unknown)
                {
                    await MaterialDialog.Instance.AlertAsync("Permission was denied.", configuration: alertDialogConfiguration);
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
