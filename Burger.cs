using System;
using System.Collections.Generic;
namespace Restauracja_FasbiersPizza
{
    public class Burger // Declaracja klasy
    {
        public List<BurgerKinds> burgerKindsList = new List<BurgerKinds>(); // lista objektow
        public List<BurgerKinds> AddBurgerKinds(string pt, decimal price) // przyjmuje dwa argumenty:pt, price
        {
            BurgerKinds burgerKinds = new BurgerKinds();
            burgerKinds.KindsName = pt;
            burgerKinds.KindsPrice = price;
            burgerKindsList.Add(burgerKinds);
            return burgerKindsList; // Metoda zwraca listę
        }
    }
}
