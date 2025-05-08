using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Modules;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class VisitController
{
    List<Visit> _visits = new List<Visit>();
    
    
    [HttpGet]
    [Route("/GetVisits/{id}")]
    public ActionResult GetVisits(int id)
    {
        var existing = DataStore._visits.FirstOrDefault(a => a._id == id);
        if (existing == null) return new NotFoundResult();

        return new OkObjectResult(existing);
    }
    
    [HttpGet]
    [Route("/GetAllVisits/")]
    public ActionResult GetAllVisits(int id)
    { 
        return new OkObjectResult(DataStore._visits);
    }

    [HttpPost]
    [Route("/AddVisit")]
    public ActionResult AddVisit(int id, [FromBody] Visit visit)
    {
        if (!DataStore._visits.Any(a => a._id == id))
        {
            visit._id = DataStore._visits.Max(v => v._id) + 1;
            visit._id = id;
            DataStore._visits.Add(visit);
            return new OkObjectResult(visit);
        }
        return new NotFoundResult();
    }
    
}