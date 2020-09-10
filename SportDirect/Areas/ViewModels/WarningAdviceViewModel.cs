using SportDirect.Areas.Model;
using SportDirect.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SportDirect.Areas.ViewModels
{
  public  class WarningAdviceViewModel : BasePageViewModel
	{
		private string _title;
		public string Title
		{
			get { return _title; }
			set { _title = value;RaisePropertyChanged(); }
		}
		private string _title1;
		public string Title1
		{
			get { return _title1; }
			set { _title1 = value;RaisePropertyChanged(); }
		}

		public WarningAdviceViewModel()
		{
			Title = "Que celui-ci soit rond, rectangulaire ou carré, saviez-vous que, l’espace d’un moment, votre trampoline peut se transformer en un océan géant, où une multitude de poissons variés s’amuseront à virevolter? Les nouilles de piscine font de merveilleuses anguilles et les éponges colorés représentent tellement bien les poissons clown, les tortues et les étoiles de mer, etc. imagination des tout-petits est sans limite. vous pourriez être vraiment surpris par votre prochain voyage lunaire ou encore par votre prochain tour de tapis volant!";
			Title1 = "Dummay data multitude de poissons variés s’amuseront à virevolter? Les nouilles de piscine font de merveilleuses anguilles et les éponges colorés représentent tellement bien les poissons clown, les tortues et les étoiles de mer, etc. imagination des tout-petits est sans limite. Aidez-les à la développer encore plus; vous pourriez être vraiment surpris par votre prochain voyage lunaire ou encore par votre prochain tour de tapis volant!";
		}  
	}
}