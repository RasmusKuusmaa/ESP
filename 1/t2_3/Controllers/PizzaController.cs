using Microsoft.AspNetCore.Mvc;
using t2_3.Models;
using t2_3.Services;

namespace t2_3.Controllers;

[ApiController]
[Route("pizza")]
public class PizzaController
{
    [HttpGet]
    public List<Pizza> GetAll() => PizzaService.GetALl();
}