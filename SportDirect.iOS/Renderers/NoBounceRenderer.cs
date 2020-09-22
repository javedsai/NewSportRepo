using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using SportDirect.iOS.Renderers;

[assembly: ExportRenderer(typeof(CollectionView), typeof(NoBounceRenderer))]
namespace SportDirect.iOS.Renderers
{
    public class NoBounceRenderer : CollectionViewRenderer
    {
        public NoBounceRenderer()
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<GroupableItemsView> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
                Controller.CollectionView.Bounces = false;
        }
    }
}
