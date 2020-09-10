using SportDirect.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportDirect.Areas.ViewModels
{
   public class OurPolicyViewModel : BasePageViewModel
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
		private string _descreptions1;
		public string Descreptions1
		{
			get { return _descreptions1; }
			set { _descreptions1 = value; RaisePropertyChanged(); }
		}
		private string _descreptions2;
		public string Descreptions2
		{
			get { return _descreptions2; }
			set { _descreptions2 = value; RaisePropertyChanged(); }
		}

		public OurPolicyViewModel()
		{
			Title = "Statement on Privacy";
			Descreptions = "Pourriez être vraiment surpris par votre prochain voyage lunaire ou encore par votre prochain tour de tapis volant! Pourriez être vraiment surpris par votre prochain voyage lunaire ou encore par votre prochain tour de tapis volant! Pourriez être vraiment surpris par votre prochain voyage lunaire ou encore par votre prochain tour de tapis volant!";
			Descreptions1 = "Pourriez être vraiment surpris par votre prochain voyage Pourriez être vraiment surpris par votre prochain voyage lunaire ou encore par votre prochain tour de tapis volant!";
			Descreptions2 = "Pourriez être vraiment surpris par votre prochain voyage lunaire ou encore par votre prochain tour de tapis volant!";
		}
	}
}