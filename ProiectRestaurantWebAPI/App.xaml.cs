using ProiectRestaurantWebAPI.Data;

namespace ProiectRestaurantWebAPI
{
    public partial class App : Application
    {
        public static FoodListDatabase Database { get; private set; }
        public App()
        {
            Database = new FoodListDatabase(new RestService());
            MainPage = new NavigationPage(new ListEntryPage());
        }
    }
}