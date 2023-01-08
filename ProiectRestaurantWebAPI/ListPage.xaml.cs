using ProiectRestaurantWebAPI.Models;


namespace ProiectRestaurantWebAPI;

public partial class ListPage : ContentPage
{
	public ListPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (RestaurantList)BindingContext;
        slist.Date = DateTime.UtcNow;
        await App.Database.SaveRestaurantListAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (RestaurantList)BindingContext;
        await App.Database.DeleteRestaurantListAsync(slist);
        await Navigation.PopAsync();
    }
}