    using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Schema;
using static System.Net.Mime.MediaTypeNames;
namespace Restauracja_FasbiersPizza
{
    public class Order
    {
        public List<Burger> MyBurgers = new List<Burger>();
        public List<Pizza> MyPizzas = new List<Pizza>();
        public List<Drinks> MyDrinks = new List<Drinks>();
        public void CheckTxt(string line) //rekord zamowienia w txt 
        {
        string path = @"C:/check.txt";
        FileStream file = new FileStream(path, FileMode.Append);
        StreamWriter sw = new StreamWriter(file);
        sw.WriteLine(line);
        sw.Close();
        file.Close();
        }
        public string GetDateID() // ID wedlug biezacej daty
        {
            DateTime now = DateTime.Now;
            Console.WriteLine("ID zamowiena: " + now.ToString("ddMMyyyyhhmmss"));
            string ID = now.ToString("ddMMyyyyhhmmss");
            return ID;
        }
        public void AddToPizzaOrder(Pizza pizza)// dodawanie do koszyka pizz
        {
            this.MyPizzas.Add(pizza);
        }
        public void AddToBurgerOrder(Burger burger)// dodawanie do koszyka burgerow
        {
            this.MyBurgers.Add(burger);
        }
        public void AddToDrinksOrder(Drinks drinks)// dodawanie do koszyka napojow
        {
            this.MyDrinks.Add(drinks);
        }
        //--------------Pizzas---------------------
        public void ShowPizzaOrder()
        {
            if (MyPizzas.Count > 0)
            {
 
                for (int i = 0; i < MyPizzas.Count; i++)
                {
                    Console.WriteLine($"Pizzas: {i + 1}                |                    |");
                    CheckTxt($"Pizzas: {i + 1}                |                    |");
                    foreach (PizzaKinds p in MyPizzas[i].pizzaKindsList)
                    {
                        Console.WriteLine($"\t{p.KindsName}|                    | {p.KindsPrice} zl ");
                        CheckTxt($"\t{p.KindsName}|                    | {p.KindsPrice} zl ");
                    }
                    CheckTxt("");
                }
            }
        }
        public void ShowPizzasOrder()
        {
            if (MyPizzas.Count > 0)
            {
                
                for (int i = 0; i < MyPizzas.Count; i++)
                {
                    Console.WriteLine($"Pizzas: {i + 1}                |                    |");
                    foreach (PizzaKinds p in MyPizzas[i].pizzaKindsList)
                    {
                        Console.WriteLine($"\t{p.KindsName}|                    | {p.KindsPrice} zl ");
                    }
                }
            }
        }
        public Order BuildPizzaOrder(Order order, int choice, Pizza pizza)
        {
            Console.WriteLine("\nZrób swója własna, niepowtarzalna pizze");
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
                        Console.WriteLine($"\t{p.KindsName}  |                    | {p.KindsPrice} zl ");
                        CheckTxt($"\t{p.KindsName}  |                    | {p.KindsPrice} zl ");
                    }
                    CheckTxt("");
                }
            }
        }
        public void ShowBurgersOrder()
        {
            if (MyBurgers.Count > 0)
            {
                for (int i = 0; i < MyBurgers.Count; i++)
                {
                    Console.WriteLine($"Burgers: {i + 1}               |                    |");
                    foreach (BurgerKinds p in MyBurgers[i].burgerKindsList)
                    {
                        Console.WriteLine($"\t{p.KindsName}  |                    | {p.KindsPrice} zl ");
                    }
                }
            }
        }
        public Order BuildBurgerOrder(Order order, int choice, Burger burger)
        {
            Console.WriteLine("\nZrób swój własny, niepowtarzalny burger");
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
                Console.WriteLine($"Napoje: {MyDrinks.Count}                |                    |");
                CheckTxt($"Napoje: {MyDrinks.Count}                |                    |");
                for (int i = 0; i < Drinks.drinksItemsList.Count; i++)
                {
                    Console.WriteLine($"\t{Drinks.drinksItemsList[i].drinksItemName}        |  {Drinks.drinksItemsList[i].drinksItemSize}  | {Drinks.drinksItemsList[i].drinksItemSizePrice} zl");
                    CheckTxt($"\t{Drinks.drinksItemsList[i].drinksItemName}        |  {Drinks.drinksItemsList[i].drinksItemSize}  | {Drinks.drinksItemsList[i].drinksItemSizePrice} zl");
                }
            }
        }
        public void ShowDrinkssOrder()
        {
            if (MyDrinks.Count > 0)
            {
                Console.WriteLine($"Napoje: {MyDrinks.Count}                |                    |");
                for (int i = 0; i < Drinks.drinksItemsList.Count; i++)
                {
                    Console.WriteLine($"\t{Drinks.drinksItemsList[i].drinksItemName}        |  {Drinks.drinksItemsList[i].drinksItemSize}  | {Drinks.drinksItemsList[i].drinksItemSizePrice} $");
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
                    Console.WriteLine($"Wybierz: {MenuItems.DrinksMenuItems.drinksMenuItemsList[choiceItem - 1].itemName}\n");
                    Console.WriteLine("Rozmiar: ");
                    MenuItems.CreateMenu(MenuItems.ItemSizes.itemSizesList);
                    while (!int.TryParse(Console.ReadLine(), out choiceSize))
                    {
                        Console.Clear();
                        Console.WriteLine($"Wybież Napoj: {MenuItems.DrinksMenuItems.drinksMenuItemsList[choiceItem - 1].itemName}\n");
                        Console.WriteLine("Rozmiar: ");
                        MenuItems.CreateMenu(MenuItems.ItemSizes.itemSizesList);
                        while (choiceSize > MenuItems.ItemSizes.itemSizesList.Count)
                        {
                            Console.WriteLine("\tNie jest to prawidłowy rozmiar, proszę wybrać prawidłową opcję: ");
                            while (!int.TryParse(Console.ReadLine(), out choiceSize)) { }
                        }
                    }
                    if (choiceSize > 0 && choiceSize <= MenuItems.ItemSizes.itemSizesList.Count)
                    {
                        Console.WriteLine($"Wybrany Rozmiar: {MenuItems.ItemSizes.itemSizesList[choiceSize - 1].itemName}\n");
                        order = Drinks.AddDrinksToDrinksListandDrinksOrder(drinks,order,choiceItem,choiceSize);
                    }
                }
                if (choiceItem > MenuItems.DrinksMenuItems.drinksMenuItemsList.Count || choiceSize > MenuItems.ItemSizes.itemSizesList.Count)
                {
                    Console.WriteLine("Nie jest to prawidłowa opcja, Wybierz ponownie");
                }
            }
            return order;
        }
        //-------------------------------------
        public void TopCheck()
        {
            CheckTxt("ID zamowienia: " + GetDateID());
            Console.WriteLine("______________________________________________________");
            CheckTxt("______________________________________________________");
            Console.WriteLine("\n     Dziękujemy za wybranie naszej restauracji!\n               **** Twój paragon ****\n");
            CheckTxt("\n     Dziękujemy za wybranie naszej restauracji!\n               **** Twój paragon ****\n");
            Console.WriteLine("______________________________________________________");
            CheckTxt("______________________________________________________");
        }
        public decimal CheckOut() //suma zamowienia
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
            Console.WriteLine($"\nSuma: {itemsTotal} $\n");
            Console.WriteLine("______________________________________________________");
            Console.WriteLine("------------------------------------------------------");
            CheckTxt("______________________________________________________");
            CheckTxt($"\nSuma: {Convert.ToString(itemsTotal)} $\n");
            CheckTxt("______________________________________________________");
            CheckTxt("------------------------------------------------------");
            return itemsTotal;
        }
        public void ClearAllOrdersAndList() // Wyczyszczenie listy po zamowienu
        {
            MyDrinks.Clear();
            MyBurgers.Clear();
            MyPizzas.Clear();
            Drinks.drinksItemsList.Clear();
        }
        public void loadFileAndSelectID() // ID search
        {
            List<string> lines = new List<string>();
            StreamReader streamReader = new StreamReader(File.Open(@"C:\check.txt", FileMode.OpenOrCreate));
            while(!streamReader.EndOfStream)
            {
                lines.Add(streamReader.ReadLine());
            }
            streamReader.Close();
            Console.Write("Podaj ID zamowienia: ");
            string ID = Console.ReadLine();
            if (ID.Length < 14 || ID.Length >14)
            {
                Console.WriteLine("\nNieprawidlowy ID");
            }
            else
            {
                int index = FindLine(lines.ToArray(), "ID zamowienia: " + ID);
                int indexTwo = FindLineTwo(lines.ToArray(), index);
                while (index - 1 != indexTwo - 1)
                {
                    index++;
                    string secondLine = File.ReadLines(@"C:\check.txt").ElementAtOrDefault(index);
                    Console.WriteLine(secondLine);
                }
                Console.WriteLine();
            }
        }
        private int FindLine(string[] source, string line)
        {
            for(int i = 0; i < source.Length;i++)
            {
                if (source[i] == line)
                    return i;
            }
            return -1;
        }
        private int FindLineTwo(string[] source, int Index) 
        {
            if(Index != -1) {
                for (int i = Index + 1; i < source.Length; i++)
                {
                    if (source[i].Contains("------------------------------------------------------"))
                        return i;
                }
            }
            return -1;
        }
        public void ShowFinalOrder() //pokaz finalnego zamowienia
        {
            ShowBurgersOrder();
            ShowPizzasOrder();
            ShowDrinkssOrder();
        }
    }
}
