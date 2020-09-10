using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SportDirect.Data.Models.Common
{
    public class CollectionFilterModel : BindableObject
    {
        //public CollectionFilterModel()
        //{
        //}

        //public CollectionFilterModel(List<Data> data,string attBName):base(data)
        //{
        //    AttributeName = attBName;
        //}
        private Data _selectedItem;

        public Data SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                _selectedItem.IsSelected = true;
                OnPropertyChanged();
            }
        }

        private List<Data> _datas;
        public List<Data> datas { get => _datas; set { _datas = value; OnPropertyChanged(); } }
        public string AttributeName { get; set; }

    }
    public class Data : BindableObject
    {
        private bool _isSelected;

        public bool IsSelected
        {
            get { return _isSelected; }
            set { _isSelected = value; OnPropertyChanged(); }
        }

        public string VarientId { get; set; }
        public string VarientName { get; set; }
        public string VarientValue { get; set; }
        public string BackColor { get; set; }
        private string _borderCol;

        public string BorderCol
        {
            get { return _borderCol; }
            set { _borderCol = value; OnPropertyChanged(nameof(BorderCol)); }
        }
    }
}
