using System;
using System.Collections.Generic;
namespace Restauracja_FasbiersPizza
{
    public class Pizza
    {
        public List<PizzaKinds> pizzaKindsList = new List<PizzaKinds>();
        public List<PizzaKinds> AddPizzaKinds(string pt, decimal price)
        {
            PizzaKinds pizzaKinds = new PizzaKinds();
            pizzaKinds.KindsName = pt;
            pizzaKinds.KindsPrice = price;
            pizzaKindsList.Add(pizzaKinds);
            return pizzaKindsList;
        }
    }
}
