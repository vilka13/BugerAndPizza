
    using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Schema;


namespace Restauracja_FasbiersPizza
{
    
    public class Order

    {
        
        
        public List<Burger> MyBurgers = new List<Burger>();
        public List<Pizza> MyPizzas = new List<Pizza>();
        public List<Drinks> MyDrinks = new List<Drinks>();
        
        public Order()
        {

        }
        public void CheckTxt(string line)
        {
        string path = @"C:/checkk.txt";
        FileStream file = new FileStream(path, FileMode.Append);
        StreamWriter sw = new StreamWriter(file);
            
            sw.WriteLine(line);

        sw.Close();
        file.Close();

        }
        public string GetDateID()
        {
            DateTime now = DateTime.Now;

            Console.WriteLine("ID zamowiena: " + now.ToString("ddMMyyyyhhmmss"));
           
            string ID = now.ToString("ddMMyyyyhhmmss");
            return ID;
            
            


        }

        public void AddToPizzaOrder(Pizza pizza)
        {
            this.MyPizzas.Add(pizza);
        }
        public void AddToBurgerOrder(Burger burger)
        {
            this.MyBurgers.Add(burger);
        }
        public void AddToDrinksOrder(Drinks drinks)
        {
            this.MyDrinks.Add(drinks);
        }
        //


        //--------------Pizzas---------------------
        public void ShowPizzaOrder()
        {

            if (MyPizzas.Count > 0)
            {
                // Console.WriteLine($"My Pizza Order:");
                for (int i = 0; i < MyPizzas.Count; i++)
                {
                    Console.WriteLine($"Pizzas: {i + 1}                |                    |");
                    CheckTxt($"Pizzas: {i + 1}                |                    |");
                    foreach (PizzaKinds p in MyPizzas[i].pizzaKindsList)
                    {
                        Console.WriteLine($"\t{p.KindsName}|                    | {p.KindsPrice} $ ");
                        CheckTxt($"\t{p.KindsName}|                    | {p.KindsPrice} $ ");

                    }
                    CheckTxt("");
                }
            }


        }
        public Order BuildPizzaOrder(Order order, int choice, Pizza pizza)
        {
            Console.WriteLine("\nChoose your Pizza Toppings");
            MenuItems.CreateMenu(MenuItems.PizzaKindsMenuItems.pizzaKindsMenuItemsList);
            pizza = MenuItems.PizzaKindsMenuItems.ChoosePizzaKinds(choice, pizza);
            order.AddToPizzaOrder(pizza);
            return order;
        }

        //-----------------Burgers--------------------
        
        public void ShowBurgerOrder()
        {
            if (MyBurgers.Count > 0)
            {
                for (int i = 0; i < MyBurgers.Count; i++)
                {
                    Console.WriteLine($"Burgers: {i + 1}               |                    |");
                    
                    CheckTxt($"\nBurgers: {i + 1}               |                    |");
                    
                    foreach (BurgerKinds p in MyBurgers[i].burgerKindsList)
                    {
                        
                        
                        Console.WriteLine($"\t{p.KindsName}  |                    | {p.KindsPrice} $ ");
                        
                        CheckTxt($"\t{p.KindsName}  |                    | {p.KindsPrice} $ ");
                       
                    }
                    CheckTxt("");

                }
            }
        }
        public Order BuildBurgerOrder(Order order, int choice, Burger burger)
        {
            Console.WriteLine("\nChoose your Burger Toppings");
            MenuItems.CreateMenu(MenuItems.BurgerKindsMenuItems.burgerKindsMenuItemsList);
            burger = MenuItems.BurgerKindsMenuItems.ChooseBurgerKinds(choice, burger);
            order.AddToBurgerOrder(burger);
            return order;
        }

        //---------------Drinks---------------------
        public void ShowDrinksOrder()
        {
            if (MyDrinks.Count > 0)
            {
                Console.WriteLine($"Extra Items: {MyDrinks.Count}           |                    |");
                CheckTxt($"Extra Items: {MyDrinks.Count}           |                    |");
                for (int i = 0; i < Drinks.drinksItemsList.Count; i++)
                {
                    Console.WriteLine($"\t{Drinks.drinksItemsList[i].drinksItemName}        |  {Drinks.drinksItemsList[i].drinksItemSize}  | {Drinks.drinksItemsList[i].drinksItemSizePrice} $");

                    CheckTxt($"\t{Drinks.drinksItemsList[i].drinksItemName}        |  {Drinks.drinksItemsList[i].drinksItemSize}  | {Drinks.drinksItemsList[i].drinksItemSizePrice} $");
                }
                
            }
        }

        public Order BuildDrinksOrder(int choiceItem, int choiceSize,Order order,Drinks drinks)
        {
            while (choiceItem != 0)
            {
                MenuItems.ChooseDrinksItemsMenu();          
                while (!int.TryParse(Console.ReadLine(), out choiceItem))
                {
                    Console.Clear();
                    MenuItems.ChooseDrinksItemsMenu();
                }
                if (choiceItem > 0 && choiceItem <= MenuItems.DrinksMenuItems.drinksMenuItemsList.Count)
                {
                    Console.WriteLine($"Choice of Extra: {MenuItems.DrinksMenuItems.drinksMenuItemsList[choiceItem - 1].itemName}\n");
                    Console.WriteLine("Item Size: ");
                    MenuItems.CreateMenu(MenuItems.ItemSizes.itemSizesList);
                    while (!int.TryParse(Console.ReadLine(), out choiceSize))
                    {
                        Console.Clear();
                        Console.WriteLine($"Choice of Extra: {MenuItems.DrinksMenuItems.drinksMenuItemsList[choiceItem - 1].itemName}\n");
                        Console.WriteLine("Item Size: ");
                        MenuItems.CreateMenu(MenuItems.ItemSizes.itemSizesList);

                        while (choiceSize > MenuItems.ItemSizes.itemSizesList.Count)
                        {
                            Console.WriteLine("\tNot a valid Size, please choose a valid option: ");
                            while (!int.TryParse(Console.ReadLine(), out choiceSize)) { }
                        }
                    }

                    if (choiceSize > 0 && choiceSize <= MenuItems.ItemSizes.itemSizesList.Count)
                    {
                        Console.WriteLine($"Chosen Size: {MenuItems.ItemSizes.itemSizesList[choiceSize - 1].itemName}\n");
                        order = Drinks.AddDrinksToDrinksListandDrinksOrder(drinks,order,choiceItem,choiceSize);
                    }

                }
                if (choiceItem > MenuItems.DrinksMenuItems.drinksMenuItemsList.Count || choiceSize > MenuItems.ItemSizes.itemSizesList.Count)
                {
                    Console.WriteLine("Not a valid option, Please Choose Again");
                }
            }
            return order;
        }
        public void TopCheck()
        {
            Console.WriteLine("______________________________________________________");
            Console.WriteLine("------------------------------------------------------");
            CheckTxt("______________________________________________________");
            CheckTxt("------------------------------------------------------");


            Console.WriteLine("\n     Dziękujemy za wybranie naszej restauracji!\n               **** Twój paragon ****\n");
            CheckTxt("\n     Dziękujemy za wybranie naszej restauracji!\n               **** Twój paragon ****\n");
            CheckTxt("ID zamowienia: " + GetDateID());
            Console.WriteLine("______________________________________________________");
            Console.WriteLine("------------------------------------------------------");
            CheckTxt("______________________________________________________");
            CheckTxt("------------------------------------------------------");
        }

        public decimal CheckOut(decimal personMoney)
        {
            decimal itemsTotal = 0;
            


            for (int i = 0; i < Drinks.drinksItemsList.Count; i++)
            {

                itemsTotal += Drinks.drinksItemsList[i].drinksItemSizePrice;

            }

            for (int i = 0; i < MyBurgers.Count; i++)
            {

                foreach (BurgerKinds p in MyBurgers[i].burgerKindsList)
                {
                    itemsTotal += p.KindsPrice;

                }
            }

            for (int i = 0; i < MyPizzas.Count; i++)
            {

                foreach (PizzaKinds p in MyPizzas[i].pizzaKindsList)
                {
                    itemsTotal += p.KindsPrice;
                }
            }
            Console.WriteLine("______________________________________________________");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine($"\nOrder Total: {itemsTotal} $\n");
            Console.WriteLine("______________________________________________________");
            Console.WriteLine("------------------------------------------------------");
            CheckTxt("______________________________________________________");
            CheckTxt("------------------------------------------------------");
            CheckTxt($"\nOrder Total: {Convert.ToString(itemsTotal)} $\n");
            CheckTxt("______________________________________________________");
            CheckTxt("------------------------------------------------------");
            return itemsTotal;
            

        }

        public void ClearAllOrdersAndList()
        {
            MyDrinks.Clear();
            MyBurgers.Clear();
            MyPizzas.Clear();
            Drinks.drinksItemsList.Clear();
        }

        public void SearchID()
        {
            string[] words = File.ReadAllText(@"C:\checkk.txt").Split(' ');

            Console.Write("Podaj ID zamowienia: ");
            string ID = Console.ReadLine();
            bool condition = false;

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Contains(ID) == true)
                {   
                  
                    condition = true;
                    break;
                }
                else
                {
                    condition = false;

                }

            }
            if (condition == true)
            {
                Console.WriteLine(ID + " was found");
            }
            else
            {
                Console.WriteLine(ID + " not found");
            }
            
        }
        


    }
}
