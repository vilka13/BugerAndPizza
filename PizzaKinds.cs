using System;
using System.Collections.Generic;
using System.Globalization;

namespace Restauracja_FasbiersPizza
{
    public class PizzaKinds
    {
        private string kindsName;
        private decimal kindsPrice;

        //default constructor
        public PizzaKinds()
        {
        }

        //overloaded constructor
        public PizzaKinds(string kindsName, decimal kindsPrice)
        {
            this.kindsName = kindsName;
            this.kindsPrice = kindsPrice;
        }

        public string KindsName { get => kindsName; set => kindsName = value; }
        public decimal KindsPrice { get => kindsPrice; set => kindsPrice = value; }
    }
}


