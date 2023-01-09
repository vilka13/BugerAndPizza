using System;
using System.Collections.Generic;

namespace Restauracja_FasbiersPizza
{
    public class Pizza
    {
        public List<PizzaKinds> pizzaKindsList = new List<PizzaKinds>();

        public Pizza()
        {

        }

        public List<PizzaKinds> AddPizzaKinds(string pt, decimal price)
        {
            PizzaKinds pizzaKinds = new PizzaKinds();

            
            pizzaKinds.KindsName = pt;
            pizzaKinds.KindsPrice = price;
           
            pizzaKindsList.Add(pizzaKinds);

            return pizzaKindsList;
        }
        public void ClearPizzaKinds()
        {
            pizzaKindsList.Clear();
        }

        public void ShowPizza()
        {

            Console.Clear();
            foreach (PizzaKinds p in pizzaKindsList)
            {
                Console.WriteLine($"Pizza: {p.KindsName}, Cena pizzy : {p.KindsPrice}");
            }

        }


    }
}
