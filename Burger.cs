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

        public List<BurgerKinds> RemoveBurgerKinds(string pt, decimal price)
        {
            BurgerKinds burgerKinds = new BurgerKinds();

          
            burgerKinds.KindsName = pt;
            burgerKinds.KindsPrice = price;
            
            burgerKindsList.Remove(burgerKinds);

            return burgerKindsList;
        }
        public List<BurgerKinds> AddBurgerKinds(string pt, decimal price)
        {
            BurgerKinds burgerKinds = new BurgerKinds();

            
            burgerKinds.KindsName = pt;
            burgerKinds.KindsPrice = price;
            
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

