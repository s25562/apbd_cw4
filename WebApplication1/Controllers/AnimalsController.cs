using System.Collections;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Modules;

namespace WebApplication1.Controllers;
[ApiController]
[Route("[controller]")]
public class AnimalsController
{
    

    [HttpGet]
    [Route("/GetAnimals")]
    public IActionResult GetAnimals()
    {
        return new OkObjectResult(DataStore._animals);
    }

    [HttpGet]
    [Route("/GetAnimals/{id}")]
    public IActionResult GetAnimal(int id)
    {
        List<Animal> animals = DataStore._animals.FindAll(x => x._id == id);
        if (animals.Count != 0) return new OkObjectResult(animals);
        else return new NotFoundResult();
    }



    [HttpPost]
    [Route("/AddAnimal")]
    public IActionResult AddAnimal(Animal animal)
    {
        DataStore._animals.Add(animal);
        return new OkObjectResult(DataStore._animals);
    }
    

    [HttpPut]
    [Route("/UpdateAnimal/{id}")]
    public IActionResult UpdateAnimal(int id, [FromBody] Animal updatedAnimal)
    {
        var existing = DataStore._animals.FirstOrDefault(a => a._id == id);
        if (existing == null) return new NotFoundResult();

        existing._name = updatedAnimal._name;
        existing._category = updatedAnimal._category;
        existing._weight = updatedAnimal._weight;
        existing._color = updatedAnimal._color;

        return new OkObjectResult(existing);
    }
    
    [HttpDelete]
    [Route("/DeleteAnimal/{id}")]
    public IActionResult DeleteAnimal(int id)
    {
        var existing = DataStore._animals.FirstOrDefault(a => a._id == id);
        if (existing == null) return new NotFoundResult();

        DataStore._animals.Remove(existing);

        return new OkResult();
    }
    
    [HttpGet]
    [Route("/GetAnimalsWithName/{name}")]
    public IActionResult GetAnimalWithName(string name)
    {
        List<Animal> animals = new List<Animal>();
        foreach (Animal animal in DataStore._animals)
            if (animal._name == name)
                animals.Add(animal);
            
        if(animals.Count != 0)
            return new OkObjectResult(animals);
        else return new NotFoundResult();
    }
}