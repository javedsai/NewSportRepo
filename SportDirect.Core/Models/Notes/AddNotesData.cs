using System;
using System.IO;
using SportDirect.Core.Models.Enums;
using Xamarin.Forms;

namespace SportDirect.Core.Models.Notes
{
    public class AddNotesData
    {
        public string PreviewPath { get; set; }
        public string Path { get; set; }
        public NoteType Type { get; set; }
        public ImageSource ImageSource { get; set; }
        public Stream FileStream { get; set; }
        public string FileName { get; set; }
    }
}
