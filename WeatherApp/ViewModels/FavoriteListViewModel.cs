using System;
using System.Collections.ObjectModel;
using WeatherApp.Models;

namespace WeatherApp.ViewModels
{
    public class FavoriteListViewModel : BaseViewModel
    {
        private FavoriteListModel favoriteListModel1 { get; set; }
        private ObservableCollection<FavoriteListModel> _favoriteListModelCollection;
        public ObservableCollection<FavoriteListModel> favoriteListModelCollection
        {
            get { return _favoriteListModelCollection; }
            set
            {
                SetProperty(ref _favoriteListModelCollection, value);
            }
        }

        public FavoriteListViewModel(FavoriteListModel favoriteListModel)
        {

            favoriteListModel1 = favoriteListModel;
            favoriteListModelCollection = new ObservableCollection<FavoriteListModel>();

            favoriteListModelCollection.Add(new FavoriteListModel
            {
                MaxTemp = favoriteListModel1.MaxTemp,
                MinTemp = favoriteListModel1.MinTemp,
                Temperature = favoriteListModel1.Temperature,
                ImageUrl = favoriteListModel1.ImageUrl
            }); 
        }
    }
}
