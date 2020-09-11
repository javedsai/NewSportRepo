using Acr.UserDialogs;
using SportDirect.Data.Models.Request;
using SportDirect.Service.Interfaces;
using SportDirect.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SportDirect.Areas.ViewModels
{
    public class SortPageViewModel : BasePageViewModel
    {
        private IApiService _apiService;
        private SortPageModelRequest _sortPageModel;
        private string type;
        private ObservableCollection<SortPageModelRequest> _sortList;

        public ObservableCollection<SortPageModelRequest> SortList
        {
            get { return _sortList; }
            set { _sortList = value; RaisePropertyChanged(nameof(SortList)); }
        }
        public SortPageViewModel(IApiService apiService)
        {
            _apiService = apiService;
            InitilizeData(App.Locator.FeaturedProductPage._handler);
        }
        public void InitilizeData(string handler)
        {
            type = handler;
            SortList = new ObservableCollection<SortPageModelRequest>()
            {
                new SortPageModelRequest{   title="A-Z" , sortKey="TITLE" , Condition=false},
                new SortPageModelRequest{  title="Z-A" , sortKey="TITLE" , Condition=true},
                new SortPageModelRequest{  title="Low to High" , sortKey="PRICE" , Condition=false },
                new SortPageModelRequest{   title="High to Low" , sortKey="PRICE" , Condition=true},
           };
            RaisePropertyChanged(nameof(SortList));
        }
        public ICommand SortListCommand => new Command<SortPageModelRequest>(async (obj) =>
        {
            _sortPageModel = obj;
            await SortForCollection();
        });
        public async Task SortForCollection()
        {
            SortPageModelRequest sortPageModel = new SortPageModelRequest();
            sortPageModel = _sortPageModel;
            UserDialogs.Instance.ShowLoading();
            try
            {
                var name = _sortPageModel.sortKey;
                var condition = _sortPageModel.Condition.ToString().ToLower();
                char t = '"';
                type = t + type + t;
                string queryid_id = "{shop {name collectionByHandle(handle:" + type + ") {title products(first:20," + "sortKey:" + name + "," + "reverse: " + condition + " ) {pageInfo { hasNextPage hasPreviousPage }edges { cursor node {id productType description variants(first: 50){edges{node{id available title selectedOptions{name value} price image{id originalSrc}}}} title}}}}}}";
                // string queryid_id = "{ shop{ products(first: 50, query:" + type + ",sortKey:" + name + ",reverse:" + condition + "){edges{node{id images(first: 5){ edges {node{ id src}}} title productType description variants(first: 50){ edges{ node{ id  available price title selectedOptions{name value} image{ id originalSrc} } } }}}}}}";
                var res = await _apiService.GetCollectionListData(queryid_id);
                if (res != null)
                {
                    App.Locator.FeaturedProductPage.InitializeSortData(res.data.shop.collectionByHandle.products, type, name, condition);
                    // App.Locator.CollectionByList.InitializeSortData(res.data.shop.collectionByHandle.products.edges);
                    await App.Current.MainPage.Navigation.PopModalAsync();
                }
                else
                {
                    // getCategory.Clear();
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Internal server error");
            }
            UserDialogs.Instance.HideLoading();

        }
    }
}
