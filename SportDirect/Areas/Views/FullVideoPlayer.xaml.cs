using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace IMS.Areas.Views
{
    public partial class FullVideoPlayer : ContentPage
    {
        public FullVideoPlayer()
        {
            InitializeComponent();
        }
        void VideoPlayer_PlayerStateChanged(System.Object sender, Octane.Xamarin.Forms.VideoPlayer.Events.VideoPlayerStateChangedEventArgs e)
        {
            if (e.CurrentState == Octane.Xamarin.Forms.VideoPlayer.Constants.PlayerState.Playing)
            {
                PlayBtn.IsVisible = false;
            }
            else
            {
                PlayBtn.IsVisible = true;
            }
        }

        void PlayBtn_Clicked(System.Object sender, System.EventArgs e)
        {
            if (VideoPlayer.State != Octane.Xamarin.Forms.VideoPlayer.Constants.PlayerState.Playing)
            {
                VideoPlayer.Play();
                PlayBtn.IsVisible = false;
            }
        }
    }

}
