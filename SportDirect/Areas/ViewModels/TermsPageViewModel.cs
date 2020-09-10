using SportDirect.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportDirect.Areas.ViewModels
{
   public class TermsPageViewModel : BasePageViewModel
    {
		private string _title;
		public string Title
		{
			get { return _title; }
			set { _title = value; RaisePropertyChanged(); }
		}
		private string _descreptions;
		public string Descreptions
		{
			get { return _descreptions; }
			set { _descreptions = value; RaisePropertyChanged(); }
		}

		public TermsPageViewModel()
		{
			Title = "PLEASE PRVIEW THE FOLLOWING USER TERMS AND CONDITIONS.";
			Descreptions = "Pourriez être vraiment surpris par votre prochain voyage lunaire ou encore par votre prochain tour de tapis volant!";
		}
	}
}