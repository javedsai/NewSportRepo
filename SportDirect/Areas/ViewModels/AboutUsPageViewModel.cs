using SportDirect.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportDirect.Areas.ViewModels
{
	public class AboutUsPageViewModel : BasePageViewModel
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

		public AboutUsPageViewModel()
		{
			Title = "About 3W Giant Mart";
			Descreptions = "Que celui-ci soit rond,Que celui-ci soit rond, rectangulaire ou carré, saviez-vous que, l’espace d’un moment, votre t rectangulaire ou carré, saviez-vous que, l’espace d’un moment, votre trampoline peut se transformer en un océan géant, où une multitude de poissons variés s’amuseront à virevolter? Les nouilles de piscine font de merveilleuses anguilles et les éponges colorés représentent tellement bien les poissons clown, les tortues et les étoiles de mer, etc. imagination des tout-petits est sans limite. Aidez-les à la développer encore plus; vous pourriez être vraiment surpris par votre prochain voyage lunaire ou encore par votre prochain tour de tapis volant!";
		}
	}
}