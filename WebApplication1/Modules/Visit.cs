using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebApplication1.Modules;

public class Visit
{
    public DateTime _date { get; set; }
    public int _id { get; set; }
    public int _animalId { get; set; }
    public string _description { get; set; }
    public double _price { get; set; }
}