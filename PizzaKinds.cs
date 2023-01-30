using System;
using System.Collections.Generic;
using System.Globalization;
namespace Restauracja_FasbiersPizza
{
    public class PizzaKinds
    {
        private string kindsName;
        private decimal kindsPrice;
        public string KindsName { get => kindsName; set => kindsName = value; }
        public decimal KindsPrice { get => kindsPrice; set => kindsPrice = value; }
    }
}
