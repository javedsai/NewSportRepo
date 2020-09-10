using Acr.UserDialogs;
using SportDirect.Areas.Model;
using SportDirect.Behaviors;
using SportDirect.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Xamarin.Forms;

namespace SportDirect.Areas.ViewModels
{
    public class BlogsDetailsPageViewModel : BasePageViewModel
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; RaisePropertyChanged(); }
        }
        private string image;
        public string Image
        {
            get { return image; }
            set { image = value; RaisePropertyChanged(); }
        }

        private string _descreptions;
        public string Descreptions
        {
            get { return _descreptions; }
            set { _descreptions = value; RaisePropertyChanged(); }
        }
        private string _date;
        public string Date
        {
            get { return _date; }
            set { _date = value; RaisePropertyChanged(); }
        }
        private string _dateImage;
        public string DateImage
        {
            get { return _dateImage; }
            set { _dateImage = value; RaisePropertyChanged(); }
        }
        private string _comment;
        public string Comment
        {
            get { return _comment; }
            set { _comment = value; RaisePropertyChanged(); }
        }
        private string _commentImage;
        public string CommentImage
        {
            get { return _commentImage; }
            set { _commentImage = value; RaisePropertyChanged(); }
        }
        private string _suggestionsTitle;
        public string SuggestionsTitle
        {
            get { return _suggestionsTitle; }
            set { _suggestionsTitle = value; RaisePropertyChanged(); }
        }
        private string _suggestions1;
        public string Suggestions1
        {
            get { return _suggestions1; }
            set { _suggestions1 = value; RaisePropertyChanged(); }
        }
        private string _suggestions2;
        public string Suggestions2
        {
            get { return _suggestions2; }
            set { _suggestions2 = value; RaisePropertyChanged(); }
        }
        private string _suggestions3;
        public string Suggestions3
        {
            get { return _suggestions3; }
            set { _suggestions3 = value; RaisePropertyChanged(); }
        }
        private string _suggestions4;
        public string Suggestions4
        {
            get { return _suggestions4; }
            set { _suggestions4 = value; RaisePropertyChanged(); }
        }
        private string readCommentDetails;
        public string ReadCommentDetails
        {
            get { return readCommentDetails; }
            set { readCommentDetails = value; RaisePropertyChanged(); }
        }
        private string _name; 
        public string Name
        {
            get { return _name; }
            set { _name = value; RaisePropertyChanged(); }
        }
        private string _email;
        public string Email 
        {
            get { return _email; }
            set { _email = value; RaisePropertyChanged(); }
        }
        private string _message;
        public string Message
        {
            get { return _message; }
            set { _message = value; RaisePropertyChanged(); }
        }
        private string _publishComment;
        public string PublishComment
        {
            get { return _publishComment; }
            set { _publishComment = value; RaisePropertyChanged(); }
        }
        public BlogsDetailsPageViewModel()
        {
            SuggestionsTitle = "Suggestions of exercises by our customers to help you spend the wait at home.";
            Suggestions1 = "1. Stretching exercises at home to warm up";
            Suggestions2 = "2. Make sure you are as flexible as possible for your weights";
            Suggestions3 = "3. Very good exercise with kettlebells. Pay attention to your back again. Take the right weights.";
            Suggestions4 = "4. Start your weights. Do not take the heaviest at first.";
            ReadCommentDetails = "do you have hexagonal dumbbell weights 10-20-25 -30 pounds or a small bar style kit for weights and two small bars? can you help me?";
        }
        internal void Init(BlogsModel blogsmdl)
        {
            Title = blogsmdl.Title;
            Image = blogsmdl.Images;
            Descreptions = blogsmdl.Descreptions;
            Date = blogsmdl.Date;
            DateImage = blogsmdl.DateImage;
            Comment = blogsmdl.Comment;
            CommentImage = blogsmdl.CommentImage;
            PublishComment = "Take note, comments must be approved before publishing.";
        }
        public ICommand GetBackCommand => new Command(async () =>
        {
            await App.Current.MainPage.Navigation.PopModalAsync();
        });
        public ICommand PublishCommand => new Command(async (obj) =>
        {
            if (string.IsNullOrEmpty(Name))
            {
                UserDialogs.Instance.Alert("Please enter name.", "Error", "Ok");
                return;
            }
            else if (string.IsNullOrEmpty(Email))
            {
                UserDialogs.Instance.Alert("Please enter emailid.", "Error", "Ok");
                return;
            }

            else if (!Regex.IsMatch(Email, RegexBehavior.emailRegex().ToString()))
            {
                UserDialogs.Instance.Alert("Please enter valid email id.");
                return;
            }
            else if (string.IsNullOrEmpty(Message))
            {
                UserDialogs.Instance.Alert("Please enter message.");
                return;
            }
            else
            {
                UserDialogs.Instance.ShowLoading();
                await UserDialogs.Instance.AlertAsync("Comment send successfully.");
                await App.Current.MainPage.Navigation.PopModalAsync();
                UserDialogs.Instance.HideLoading();
                Name = string.Empty;
                Email = string.Empty;
                Message = string.Empty;
            }          
        });
    }
}