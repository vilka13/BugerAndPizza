using System;
using System.Collections.Generic;

namespace Restauracja_FasbiersPizza
{
    public class Drinks
    {
        public Drinks()
        {
        }
        public static List<(string drinksItemName, decimal drinksItemPrice, string drinksItemSize, decimal drinksItemSizePrice)> drinksItemsList = new List<(string drinksItemName, decimal drinksItemPrice, string drinksItemSize, decimal drinksItemSizePrice)>();

        public List<(string drinksItemName, decimal drinksItemPrice, string drinksItemSize, decimal drinksItemSizePrice)> AddDrinksItemToList(string drinksItemName, decimal drinksItemPrice, string drinksItemSize, decimal drinksItemSizePrice)
        {
            drinksItemsList.Add((drinksItemName, drinksItemPrice, drinksItemSize, drinksItemSizePrice));
            return drinksItemsList;
        }

        public static Order AddDrinksToDrinksListandDrinksOrder(Drinks drinks, Order order,int choiceItem, int choiceSize)
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
