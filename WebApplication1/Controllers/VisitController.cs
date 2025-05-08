using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Modules;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class VisitController
{
    
    [HttpGet]
    [Route("/GetVisits/{id}")]
    public ActionResult GetVisits(int id)
    {
        var existing = DataStore._visits.FirstOrDefault(a => a._id == id);
        if (existing == null) return new NotFoundResult();

        return new OkObjectResult(existing);
    }
    
    [HttpGet]
    [Route("/GetAllVisits")]
    public ActionResult GetAllVisits()
    { 
        return new OkObjectResult(DataStore._visits);
    }

    [HttpPost]
    [Route("/AddVisit")]
    public ActionResult AddVisit([FromBody] Visit visit)
    {
        visit._id = DataStore._visits.Max(v => v._id) + 1;
        DataStore._visits.Add(visit);
        return new OkObjectResult(visit);
    }
    
}