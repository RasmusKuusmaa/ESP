using T2.Models;
using T2.Services;
using Microsoft.AspNetCore.Mvc;

namespace T2.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    public PizzaController()
    {
    }
     [HttpGet]
    public ActionResult<List<Pizza>> GetAll() =>  
        PizzaService.GetAll();
    
    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id)
    {
        var pizza = PizzaService.Get(id);
        if (pizza == null)
        {
            return NotFound();
        }
        return pizza;;
    }
}