using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProiectRestaurantWebAPI.Models;

namespace ProiectRestaurantWebAPI.Data
{
    public interface IRestService
    {
        Task<List<RestaurantList>> RefreshDataAsync();
        Task SaveRestaurantListAsync(RestaurantList item, bool isNewItem);
        Task DeleteRestaurantListAsync(int id);
    }
}
