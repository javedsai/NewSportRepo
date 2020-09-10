using System;
using System.IO;
using SportDirect.Core.Models.Enums;
using Xamarin.Forms;

namespace SportDirect.Core.Models.Media
{
    public class MediaFile
    {
        public string PreviewPath { get; set; }
        public string Path { get; set; }
        public MediaFileType Type { get; set; }
        public ImageSource ImageSource { get; set; }
        public Stream FileStream { get; set; }
    }
}
