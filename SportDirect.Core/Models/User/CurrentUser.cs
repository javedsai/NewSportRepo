using System;
using SportDirect.Core.Helpers;
using SportDirect.Core.Models.Authentication;
using SportDirect.Core.Models.Common;

namespace SportDirect.Core.Models.User
{
    public class CurrentUser : BindableBase
    {

        private StudentDetail _currentStudentDetails;
        public StudentDetail CurrentStudentDetails { get => _currentStudentDetails; set { SetProperty(ref _currentStudentDetails, value); } }

        public CurrentUser()
        {

        }
        public CurrentUser(StudentDetail studnetDetail)
        {
            CurrentStudentDetails = studnetDetail;
        }
    }
}
