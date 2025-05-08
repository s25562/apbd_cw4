using WebApplication1.Modules;

namespace WebApplication1.Data;

public class DataStore
{
    public static List<Animal> _animals { get; set; } = new()
    {
        new Animal { _id = 1, _name = "Azor", _category = "Pies", _weight = 20, _color = "Brązowy" },
        new Animal { _id = 2, _name = "Mruczek", _category = "Kot", _weight = 4.5, _color = "Czarny" }
    };

    public static List<Visit> _visits { get; set; } = new()
    {
        new Visit { _id = 1, _animalId = 1, _date = DateTime.Now.AddDays(-10), _description = "Szczepienie", _price = 150 },
        new Visit { _id = 2, _animalId = 2, _date = DateTime.Now.AddDays(-5), _description = "Odrobaczanie", _price = 100 }
    };
}