using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProiectRestaurantWebAPI.Models;

namespace ProiectRestaurantWebAPI.Data
{
    public class FoodListDatabase
    {
        IRestService restService;
        public FoodListDatabase(IRestService service)
        {
            restService = service;
        }
        public Task<List<RestaurantList>> GetRestaurantListsAsync()
        {
            return restService.RefreshDataAsync();
        }

        public Task SaveRestaurantListAsync(RestaurantList item, bool isNewItem = true)
        {
            return restService.SaveRestaurantListAsync(item, isNewItem);
        }
        public Task DeleteRestaurantListAsync(RestaurantList item)
        {
            return restService.DeleteRestaurantListAsync(item.ID);
        }
    }
}
