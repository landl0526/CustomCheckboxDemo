using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CustomCheckboxDemo
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            List<ItemModel> list = new List<ItemModel>();
            for (int i=0; i<10; i++)
            {
                list.Add(new ItemModel { Name = "item" + i });
            }
            MyListView.ItemsSource = list;
		}
	}

    public class ItemModel : INotifyPropertyChanged
    {
        string name;
        public string Name
        {
            set
            {
                name = value;
                onPropertyChanged("Name");
            }
            get
            {
                return name;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void onPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public List<ItemModel> CheckedModels = new List<ItemModel>();
        public Command<ItemModel> HandleButtonCommand { set; get; }

        public ItemModel()
        {
            HandleButtonCommand = new Command<ItemModel>((model) =>
            {

            });
        }

        //public bool IsChecked { set; get; }
    }
}
