using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DanFestaJuninaCore.Models
{
    public interface IDishRepository
    {
        Task<Dish> GetDish(string Name);
        Task<IEnumerable<Dish>> GetAllDishes(IOptions<DanAppSettings> settings);
        Task<IEnumerable<Dish>> GetAllDishesdotnet(IOptions<DanAppSettings> settings);
        Task<Dish> UpdateDish( Dish dish );
        
    }
}
