using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Plugin.Multilingual;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SportDirect.Resources
{
    /// <summary>
    /// Markup extension that exposes resource files to XAML.
    /// Taken from https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/localization/text?tabs=windows#localizing-xaml
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Xaml.IMarkupExtension" />
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        private const string ResourceId = "SportDirect.Resources.AppResources";

        private static readonly Lazy<ResourceManager> _resmgr = new Lazy<ResourceManager>(() =>
            new ResourceManager(ResourceId, typeof(TranslateExtension).GetTypeInfo().Assembly), true);

        public TranslateExtension()
        {
            _resmgr.Value.IgnoreCase = true;
        }
        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            CultureInfo ci;

            if (Text == null || !_resmgr.IsValueCreated)
                return "";

            try
            {
                ci = CrossMultilingual.Current.CurrentCultureInfo;
            }
            catch
            {
                ci = CultureInfo.CurrentCulture;
            }


            var translation = _resmgr.Value.GetString(Text, ci);

            if (translation == null)
                translation = Text;

            return translation;
        }
    }
}
