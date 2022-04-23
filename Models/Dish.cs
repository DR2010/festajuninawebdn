using System;
using System.Threading.Tasks;

namespace DanFestaJuninaCore.Models
{
    public class Dish
    {
        public string Id { get; set; }        // name of the dish - this is the KEY, must be unique
        public string Name { get; set; }        // name of the dish - this is the KEY, must be unique
        public string Type { get; set; }        // type of dish, includes drinks and deserts
        public string Price { get; set; }        // preco do prato multiplicar por 100 e nao ter digits
        public string GlutenFree { get; set; }        // Gluten free dishes
        public string DairyFree { get; set; }        // Dairy Free dishes
        public string Vegetarian { get; set; }        // Vegeterian dishes
        public string InitialAvailable { get; set; }        // Number of items initially available
        public string CurrentAvailable { get; set; }        // Currently available
        public string ImageName { get; set; }        // Image Name
        public string Description { get; set; }        // Description of the plate
        public string Descricao { get; set; }        // Descricao do prato
        public string ActivityType { get; set; }        // Descricao do activity
        public string ImageBase64 { get; set; }        // Image in base 64


    }
}
