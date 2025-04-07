using t2_3.Models;

namespace t2_3.Services;

public static class PizzaService
{
    static List<Pizza> Pizzas;
    static PizzaService()
    {
        Pizzas = new List<Pizza>
        {
            new Pizza {Id = 1, Name="n1"},
            new Pizza {Id = 2, Name="n2"}
        };
    }
    public static List<Pizza> GetALl() => Pizzas;
}