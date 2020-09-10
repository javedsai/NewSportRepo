using System;
using SportDirect.Core.Helpers;

namespace SportDirect.Core.Models.User
{
    public class UserBasicInfo : BindableBase
    {
        private string _profilePic;
        public string ProfilePic
        {
            get => _profilePic;
            set => SetProperty(ref _profilePic, value);
        }

        private string _userName;
        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }

        private string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public UserBasicInfo()
        {
        }
    }
}
