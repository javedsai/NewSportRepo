using SportDirect.Areas.Model;
using SportDirect.ViewModels;
using System.Collections.ObjectModel;

namespace SportDirect.Areas.ViewModels
{
    public class NotificationPageViewModel : BasePageViewModel
    {
        private ObservableCollection<NotificationModel> _notificationData;
        public ObservableCollection<NotificationModel> NotificationData
        {
            get { return _notificationData; }
            set { _notificationData = value; RaisePropertyChanged(); }
        }
        public NotificationPageViewModel()
        {
            NotificationData = GeNotificationData();
        }
        public ObservableCollection<NotificationModel> GeNotificationData()
        {
            return new ObservableCollection<NotificationModel>()
            {
            new NotificationModel() { Title = "Lorem ipsum dolor sit amet,data consectetur adipiscing elit. In facilisis nulla eu felis.",Date="5 min ago"},
            new NotificationModel() { Title = "Lorem ipsum dolor sit amet,data consectetur adipiscing elit. In facilisis nulla eu felis.",Date="5 min ago"},
            new NotificationModel() { Title = "Lorem ipsum dolor sit amet,data consectetur adipiscing elit. In facilisis nulla eu felis.",Date="5 min ago"},
            new NotificationModel() { Title = "Lorem ipsum dolor sit amet,data consectetur adipiscing elit. In facilisis nulla eu felis.",Date="5 min ago"},
            new NotificationModel() { Title = "Lorem ipsum dolor sit amet,data consectetur adipiscing elit. In facilisis nulla eu felis.",Date="5 min ago"},
            new NotificationModel() { Title = "Lorem ipsum dolor sit amet,data consectetur adipiscing elit. In facilisis nulla eu felis.",Date="5 min ago"},
            new NotificationModel() { Title = "Lorem ipsum dolor sit amet,data consectetur adipiscing elit. In facilisis nulla eu felis.",Date="5 min ago"},
            new NotificationModel() { Title = "Lorem ipsum dolor sit amet,data consectetur adipiscing elit. In facilisis nulla eu felis.",Date="5 min ago"},
            new NotificationModel() { Title = "Lorem ipsum dolor sit amet,data consectetur adipiscing elit. In facilisis nulla eu felis.",Date="5 min ago"},
            new NotificationModel() { Title = "Lorem ipsum dolor sit amet,data consectetur adipiscing elit. In facilisis nulla eu felis.",Date="5 min ago"},
            new NotificationModel() { Title = "Lorem ipsum dolor sit amet,data consectetur adipiscing elit. In facilisis nulla eu felis.",Date="5 min ago"},
         };
        }
    }
}