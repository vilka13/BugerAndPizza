using System;
using System.Collections.Generic;
namespace Restauracja_FasbiersPizza
{
    public class Drinks // Declaracja klasy
    {
        public static List<(string drinksItemName, decimal drinksItemPrice, string drinksItemSize, decimal drinksItemSizePrice)> drinksItemsList = new List<(string drinksItemName, decimal drinksItemPrice, string drinksItemSize, decimal drinksItemSizePrice)>(); // 
        public List<(string drinksItemName, decimal drinksItemPrice, string drinksItemSize, decimal drinksItemSizePrice)> AddDrinksItemToList(string drinksItemName, decimal drinksItemPrice, string drinksItemSize, decimal drinksItemSizePrice)
        {                                                                                                                // funkcja dodająca nowy element do listy
            drinksItemsList.Add((drinksItemName, drinksItemPrice, drinksItemSize, drinksItemSizePrice));
            return drinksItemsList;
        }
        public static Order AddDrinksToDrinksListandDrinksOrder(Drinks drinks, Order order,int choiceItem, int choiceSize) // funkcja dodająca nowy napój do listy napojów
        {
            drinks.AddDrinksItemToList
            (
                MenuItems.DrinksMenuItems.drinksMenuItemsList[choiceItem - 1].itemName,
                MenuItems.DrinksMenuItems.drinksMenuItemsList[choiceItem - 1].price,
                MenuItems.ItemSizes.itemSizesList[choiceSize - 1].itemName,
                MenuItems.ItemSizes.itemSizesList[choiceSize - 1].price
            );
            order.AddToDrinksOrder(drinks);
            return order;
        }
    }
}

// Każda właściwość ma swój własny getter i setter, które pozwalają na pobranie lub zmianę wartości właściwości.
