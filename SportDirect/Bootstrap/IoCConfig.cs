using System;
using System.Diagnostics;
using SportDirect.Services;
using SportDirect.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using SportDirect.Service.Interfaces;
using SportDirect.Service.Services;

namespace SportDirect.Bootstrap
{
    public class IoCConfig
    {
        public virtual void RegisterServices()
        {

            //SimpleIoc.Default.Register<IAuthenticationService, AuthenticationService>();
            try
            {
                SimpleIoc.Default.Register(() => new System.Net.Http.HttpClient());
            }
            catch (Exception e)
            {
                Debug.WriteLine($"already initiated ={e.Message}");
            }
            SimpleIoc.Default.Register<IApiService, ApiService>();
            SimpleIoc.Default.Register<INavigationService, NavigationService>();

            ////SimpleIoc.Default.Register<Param<object>>();
            //SimpleIoc.Default.Register<CurrentUser>();

        }

        /// <summary>
        /// Registers a single view model to the container
        /// </summary>
        /// <typeparam name="T">The view model type parameter.</typeparam>
        public void RegisterViewModel<T>() where T : ViewModelBase
        {
            SimpleIoc.Default.Register<T>();
        }

        /// <summary>
        /// Finds a single view model from the container by type
        /// </summary>
        /// <returns>The view model.</returns>
        /// <typeparam name="T">The view model type parameter.</typeparam>
        public T FindViewModel<T>() where T : ViewModelBase
        {
            return SimpleIoc.Default.GetInstance<T>();
        }
    }
}
