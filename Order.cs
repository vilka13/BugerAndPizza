
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
        public void ShowPizzasOrder()
        {

            if (MyPizzas.Count > 0)
            {
                // Console.WriteLine($"My Pizza Order:");
                for (int i = 0; i < MyPizzas.Count; i++)
                {
                    Console.WriteLine($"Pizzas: {i + 1}                |                    |");
                    
                    foreach (PizzaKinds p in MyPizzas[i].pizzaKindsList)
                    {
                        Console.WriteLine($"\t{p.KindsName}|                    | {p.KindsPrice} $ ");
                   

                    }
                  
                }
            }


        }
        public Order BuildPizzaOrder(Order order, int choice, Pizza pizza)
        {
            Console.WriteLine("\nWybierz dodatki do pizzy");
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
        public void ShowBurgersOrder()
        {
            if (MyBurgers.Count > 0)
            {
                for (int i = 0; i < MyBurgers.Count; i++)
                {
                    Console.WriteLine($"Burgers: {i + 1}               |                    |");

                  

                    foreach (BurgerKinds p in MyBurgers[i].burgerKindsList)
                    {


                        Console.WriteLine($"\t{p.KindsName}  |                    | {p.KindsPrice} $ ");

                     

                    }
         

                }
            }
        }
        public Order BuildBurgerOrder(Order order, int choice, Burger burger)
        {
            Console.WriteLine("\nWybierz dodatki do Burgera");
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
                Console.WriteLine($"Drinks Items: {MyDrinks.Count}           |                    |");
                CheckTxt($"Drinks Items: {MyDrinks.Count}           |                    |");
                for (int i = 0; i < Drinks.drinksItemsList.Count; i++)
                {
                    Console.WriteLine($"\t{Drinks.drinksItemsList[i].drinksItemName}        |  {Drinks.drinksItemsList[i].drinksItemSize}  | {Drinks.drinksItemsList[i].drinksItemSizePrice} $");

                    CheckTxt($"\t{Drinks.drinksItemsList[i].drinksItemName}        |  {Drinks.drinksItemsList[i].drinksItemSize}  | {Drinks.drinksItemsList[i].drinksItemSizePrice} $");
                }
                
            }
        }
        public void ShowDrinkssOrder()
        {
            if (MyDrinks.Count > 0)
            {
                Console.WriteLine($"Napoj Items: {MyDrinks.Count}           |                    |");

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
                        Console.WriteLine("Item Size: ");
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

        public void IdSearch()

        {
            string fileName = @"C:\checkk.txt";

            string line;
            string lines = " ";
            

            StreamReader sr = new StreamReader(fileName);
            while ((line = sr.ReadLine()) != null)
            {
                lines += line;
                if (lines.Contains("ID"))
                {
                    Console.WriteLine(lines);
                }
                else
                {
                    
                }
                
            }

            //foreach (string line in lines)
            //{

            //    if (lines.Contains("ID"))
            //    {
            //        Console.WriteLine(lines);
            //    }
            //    else
            //    {
            //        Array.Clear(lines);
            //        break;
            //    }

            //    //Console.WriteLine(line);
            //}

        }

        public void ClearAllOrdersAndList()
        {
            MyDrinks.Clear();
            MyBurgers.Clear();
            MyPizzas.Clear();
            Drinks.drinksItemsList.Clear();
        }

        public void loadFileAndSelectID()
        {
            List<string> lines = new List<string>();

            StreamReader streamReader = new StreamReader(File.Open(@"C:\checkk.txt", FileMode.OpenOrCreate));

            while (!streamReader.EndOfStream)
            {
                lines.Add(streamReader.ReadLine());
            }

            streamReader.Close();

            Console.Write("Podaj ID zamowienia: ");
            string ID = Console.ReadLine();

            int index = FindLine(lines.ToArray(), "ID zamowienia: " + ID);

            Console.WriteLine(index);
            int indextwo = FindLineTwo(lines.ToArray(), index);
            Console.WriteLine(indextwo);

            string[] check;






        }

        private int FindLine(string[] source, string line)
        {

            for (int i = 0; i < source.Length; i++)
            {


                if (source[i] == line)
                    return i;

            }



            return -1;
        }
        private int FindLineTwo(string[] source, int Index)
        {

            for (int i = 0; i < source.Length; i++)
            {


                if (source[i] == line)
                    return i;

            }



            return -1;
        }
        private int FindLineTwo(string[] source, int Index)
        {

            for (int i = Index + 1; i < source.Length; i++)
            {


                if (source[i].Contains("ID"))
                    return i;

            }



            return -1;
        }


    }
}
