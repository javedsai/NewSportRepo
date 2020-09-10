using SportDirect.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportDirect.Areas.ViewModels
{
   public class PrivacySecurityViewModel : BasePageViewModel
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

		public PrivacySecurityViewModel()
		{
			Title = "Privacy and Security Details";
			Descreptions = "Privacy has become a big issue online, especially with the big increase in cookie tracking for marketing and data collection purposes online. On top of this, Android phone users have the additional concern of rogue apps that might try to tap into your data directly. In order to protect your privacy there are, of course, basic phone, app, and browser settings that can help mitigate some of these issues. However, if you're serious about privacy, anonymity, and security, then you'll probably need to go a step further.Pourriez être vraiment surpris par votre prochain voyage lunaire ou encore par votre prochain tour de tapis volant! Pourriez être vraiment surpris par votre prochain voyage lunaire ou encore par votre prochain tour de tapis volant! Pourriez être vraiment Pourriez être vraiment surpris par votre prochain voyage lunaire ou encore par votre prochain tour de tapis volant! Pourriez être vraiment surpris par votre prochain voyage lunaire ou encore par votre prochain tour de tapis volant! vraiment surpris par votre prochain voyage lunaire ou encore par votre prochain tour de tapis volant! Pourriez être Pourriez être vraiment surpris par votre prochain voyage lunaire ou encore par votre prochain tour de tapis volant! Pourriez être vraiment surpris par votre prochain voyage lunaire ou encore par votre prochain tour de tapis volant! Pourriez être vraimen surpris par votre prochain voyage lunaire ou encore par votre prochain tour de tapis volant.";
		}
	}
}