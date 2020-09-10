using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SportDirect.Core.Models.Media;

namespace SportDirect.Core.Interfaces
{
    public interface IMultiMediaPickerService
    {
        event EventHandler<MediaFile> OnMediaPicked;
        event EventHandler<IList<MediaFile>> OnMediaPickedCompleted;
        Task<IList<MediaFile>> PickPhotosAsync();
        Task<IList<MediaFile>> PickVideosAsync();
        void Clean();
    }
}
