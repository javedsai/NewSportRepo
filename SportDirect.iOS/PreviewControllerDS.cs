using System;
using Foundation;
using QuickLook;

namespace SportDirect.iOS
{
    public class PreviewControllerDS : QLPreviewControllerDataSource
    {
        private QLPreviewItem _item;

        public PreviewControllerDS(QLPreviewItem item)
        {
            _item = item;
        }

        public override IQLPreviewItem GetPreviewItem(QLPreviewController controller, nint index)
        {
            return _item;
        }

        public override nint PreviewItemCount(QLPreviewController controller)
        {
            return 1;
        }
    }
    public class QLPreviewItemFileSystem : QLPreviewItem
    {
        string _fileName, _filePath;

        public QLPreviewItemFileSystem(string fileName, string filePath)
        {
            _fileName = fileName;
            _filePath = filePath;
        }

        public override string ItemTitle
        {
            get
            {
                return _fileName;
            }
        }
        public override NSUrl ItemUrl
        {
            get
            {
                return NSUrl.FromFilename(_filePath);
            }
        }
    }
}
