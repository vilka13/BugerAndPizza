using System;
namespace Restauracja_FasbiersPizza
{
    public class BurgerKinds // Deklaracja klasy BurerKinds
    {
        private string kindsName;
        private decimal kindsPrice;
        public string KindsName { get => kindsName; set => kindsName = value; }
        public decimal KindsPrice { get => kindsPrice; set => kindsPrice = value; }
    }
}
// Każda właściwość ma swój własny getter i setter, które pozwalają na pobranie lub zmianę wartości właściwości.
