using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DanFestaJuninaCore.Models
{
    public class MockDishRepository : IDishRepository
    {
        private Task<IEnumerable<Dish>> _dishList;

        public MockDishRepository()
        {
            IEnumerable<Dish> _dishListX;

            _dishListX = new List<Dish>()
            {
                new Dish() { Name = "Feijoada", Type = "Savoury", Price = "10.30", GlutenFree = "Y", DairyFree = "Y",
                             Vegetarian = "Y", InitialAvailable = "50", CurrentAvailable = "50", ImageName = "Feijao.jpg",
                             Description = "Feijoada", Descricao = "Feijoada", ActivityType = "1"},
                new Dish() { Name = "Batata", Type = "Savoury", Price = "10.30", GlutenFree = "Y", DairyFree = "Y",
                             Vegetarian = "Y", InitialAvailable = "50", CurrentAvailable = "50", ImageName = "Feijao.jpg",
                             Description = "Feijoada", Descricao = "Feijoada", ActivityType = "1"},
                new Dish() { Name = "Angu a baiana", Type = "Savoury", Price = "10.30", GlutenFree = "Y", DairyFree = "Y",
                             Vegetarian = "Y", InitialAvailable = "50", CurrentAvailable = "50", ImageName = "Feijao.jpg",
                             Description = "Feijoada", Descricao = "Feijoada", ActivityType = "1"},
                new Dish() { Name = "Feijao Tropeiro", Type = "Savoury", Price = "10.30", GlutenFree = "Y", DairyFree = "Y",
                             Vegetarian = "Y", InitialAvailable = "50", CurrentAvailable = "50", ImageName = "Feijao.jpg",
                             Description = "Feijoada", Descricao = "Feijoada", ActivityType = "1"}
            };

            _dishList = (Task<IEnumerable<Dish>>)_dishListX;
        }

        public Task<IEnumerable<Dish>> GetAllDishes(IOptions<DanAppSettings> danAppSettings)
        {
            return _dishList;
        }

        public Task<IEnumerable<Dish>> GetAllDishesdotnet(IOptions<DanAppSettings> danAppSettings)
        {
            return _dishList;
        }

        public Task<Dish> GetDish(string Name)
        {

            Dish _dish = new Dish();
            //_dish = _dishList.FirstOrDefault(e => e.Name == Name);
            return null;
        }

        public Task<Dish> UpdateDish()
        {
            throw new System.NotImplementedException();
        }

        public Task<Dish> UpdateDish(Dish dish)
        {
            throw new System.NotImplementedException();
        }
    }
}
