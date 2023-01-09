using System;
using System.Collections.Generic;

namespace Restauracja_FasbiersPizza
{
    public class Burger
    {

        public List<BurgerKinds> burgerKindsList = new List<BurgerKinds>();

        public Burger()
        {

        }

        public List<BurgerKinds> AddBurgerKinds(string pt, decimal price)
        {
            BurgerKinds burgerKinds = new BurgerKinds();

            //assign the burger topping variables
            burgerKinds.KindsName = pt;
            burgerKinds.KindsPrice = price;
            //return burger topping
            burgerKindsList.Add(burgerKinds);

            return burgerKindsList;
        }
        public void ClearBurgerKinds()
        {
            burgerKindsList.Clear();
        }

        public void ShowBurger()
        {

            Console.Clear();
            foreach (BurgerKinds p in burgerKindsList)
            {
                Console.WriteLine($"BurgerTopping: {p.KindsName}, BurgerToppingPrice : {p.KindsPrice}");
            }

        }



    }
}
