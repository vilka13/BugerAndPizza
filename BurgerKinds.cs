using System;
namespace Restauracja_FasbiersPizza
{
    public class BurgerKinds
    {
        private string kindsName;
        private decimal kindsPrice;

        //default constructor
        public BurgerKinds()
        {
        }

        //overloaded constructor
        public BurgerKinds(string kindsName, decimal kindsPrice)
        {
            this.kindsName = kindsName;
            this.kindsPrice = kindsPrice;
        }

        public string KindsName { get => kindsName; set => kindsName = value; }
        public decimal KindsPrice { get => kindsPrice; set => kindsPrice = value; }
    }
}
