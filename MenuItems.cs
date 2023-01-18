using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Restauracja_FasbiersPizza
{
    public class MenuItems
    {
        public MenuItems() { }
    
        public static class MainMenuItems
        {
            public static List<(int index, string itemName, decimal price)> mainMenuItemsList = new List<(int index, string itemName, decimal price)>
            {
              (1, "Burgery",0m),
              (2, "Pizzy",0m),
              (3, "Napoj",0m),
              (4, "Zloż zamowienie",0m),
              (5, "ID search", 0m),
              (6, "Podaj co trzeba usunąć",0m),
            };

            
        }

        public static class PizzaKindsMenuItems
        {
            public static List<(int index, string itemName, decimal price)> pizzaKindsMenuItemsList = new List<(int index, string itemName, decimal price)>
            {
              (1, "Ser Parmezan     ",3.99m),
              (2, "Ser Mozzarella   ",3.99m),
              (3, "Boczek           ",5.99m),
              (4, "Szynka           ",5.99m),
              (5, "Kurczak          ",5.99m),
              (6, "Kabanosy         ",5.99m),
              (7, "Kielbasa Wiejska ",5.99m),
              (8, "Salami           ",5.99m),
              (9, "Krewetki         ",5.99m),
              (10,"Cebula           ",1.99m),
              (11,"Czosnek          ",1.99m),            
              (12,"Brokuly          ",1.99m),
              (13,"Papryka          ",2.99m),
              (14,"Kukurydza        ",2.99m),
              (15,"Pomidor          ",2.99m),
              (16,"Pieczarki        ",2.99m),
              (17,"Oliwki           ",3.99m),
              (18,"Fasola           ",2.99m),
              (19,"Ananas           ",3.99m),
              (20,"Ogorek           ",2.99m),
              (21,"Sos pomidorowy   ",1.99m),
              (22,"Sos czosnkowy    ",1.99m),
              (23,"Sos tzatziki     ",2.99m)
            };

            public static Pizza ChoosePizzaKinds(int kinds, Pizza pizza)
            {
                while (kinds != 0)
                {
                   Console.WriteLine("[0]Powrót do menu glównego");
                    while (!int.TryParse(Console.ReadLine(), out kinds))
                    {
                        Console.Clear();
                        Console.WriteLine("\nWybież pizzę: ");
                        CreateMenu(pizzaKindsMenuItemsList);
                        Console.WriteLine("[0] Powrót do menu glównego: ");
                        Console.WriteLine("Wybież pizzę: ");
                    }

                    Console.WriteLine("");
                    if (kinds > 0 && kinds <= pizzaKindsMenuItemsList.Count)
                    {
                        pizza.AddPizzaKinds
                        (
                            pizzaKindsMenuItemsList[kinds - 1].itemName,
                            pizzaKindsMenuItemsList[kinds - 1].price
                        );
                        Console.WriteLine($"\tTopping wybrany do tej pory:");
                        if (pizza.pizzaKindsList.Count < 0)
                        {
                            Console.WriteLine("\t* NIE MA *");
                        }
                        foreach (PizzaKinds p in pizza.pizzaKindsList)
                        {
                            Console.WriteLine($"\t\t\t{p.KindsName}");
                        }
                        Console.WriteLine();
                        CreateMenu(pizzaKindsMenuItemsList);
                    }
                    if (kinds > pizzaKindsMenuItemsList.Count)
                    {
                        Console.WriteLine("\nNie jest to prawidłowy wybór topping, proszę wybrać ponownie\n");

                        CreateMenu(pizzaKindsMenuItemsList);
                    }
                }
                return pizza;
            }

        }
        public static class BurgerKindsMenuItems
        {   
            public static List<(int index, string itemName, decimal price)> burgerKindsMenuItemsList = new List<(int index, string itemName, decimal price)>
            {
              (1, "Kotlet: Wołowy ",3.99m),
              (2, "Kotlet: Rostbef",3.99m),
              (3, "Kotlet: Atrykot",3.99m),
              (4, "Pomidor        ",0.99m),
              (5, "Ogorek         ",0.99m),
              (6, "Papryka        ",0.99m),
              (7, "Cebula         ",0.99m),
              (8, "Salat          ",0.99m),
              (9, "Ser            ",0.99m),
              (10,"Bekon          ",2.99m)
            };

            public static Burger ChooseBurgerKinds(int kinds, Burger burger)
            {
                while (kinds != 0)
                {
                    Console.WriteLine("[0] Powrót do menu glównego");
                    Console.WriteLine("Wybież burger: ");
                    while (!int.TryParse(Console.ReadLine(), out kinds))
                    {
                        Console.Clear();
                        Console.WriteLine("\nWybież burger");
                        CreateMenu(burgerKindsMenuItemsList);
                        Console.WriteLine("[0] Powrót do menu glównego");
                        Console.WriteLine("Wybież burger: ");
                    }

                    Console.WriteLine("");
                    if (kinds > 0 && kinds <= burgerKindsMenuItemsList.Count)
                    {
                        burger.AddBurgerKinds
                        (
                            burgerKindsMenuItemsList[kinds - 1].itemName,
                            burgerKindsMenuItemsList[kinds - 1].price
                        );
                        Console.WriteLine($"\tDodatki wybrane do tej pory:");
                        if (burger.burgerKindsList.Count < 0)
                        {
                            Console.WriteLine("\t* NIE MA *");
                        }
                        foreach (BurgerKinds b in burger.burgerKindsList)
                        {
                            Console.WriteLine($"\t\t\t{b.KindsName}");
                        }
                        Console.WriteLine();
                        CreateMenu(burgerKindsMenuItemsList);
                    }
                    if (kinds > burgerKindsMenuItemsList.Count)
                    {
                        Console.WriteLine("\nNie jest to prawidłowy wybór topping, proszę wybrać ponownie\n");
                        Console.WriteLine();
                        CreateMenu(burgerKindsMenuItemsList);
                    }
                }
                return burger;
            }

        }
        public static class DrinksMenuItems
        {
            public static List<(int index, string itemName, decimal price)> drinksMenuItemsList = new List<(int index, string itemName, decimal price)>
            {
              (1, "Coca-cola",2.00m),
              (2, "Pepsi    ",1.50m),
              (3, "Fanta    ",1.00m),
              (4, "Sprite   ",1.00m),
              (5, "Dr.Papper",3.00m)

            };

        }
        public static class ItemSizes
        {
            public static List<(int index, string itemName, decimal price)> itemSizesList = new List<(int index, string itemName, decimal price)>
            {
              (1, "Small    150 ml.",1.99m),
              (2, "Medium   300 ml.",2.99m),
              (3, "Large    500 ml.",3.99m),
              (4, "X-large  700 ml.",4.99m)
            };

        }
        public static void ChooseDrinksItemsMenu()
        {
            Console.WriteLine("\nWybież napój");
            MenuItems.CreateMenu(MenuItems.DrinksMenuItems.drinksMenuItemsList);
            Console.WriteLine("[0] Powrót do menu glównego");
        }
        public static void CreateMenu(List<(int index, string itemName, decimal price)> myList)
        {
            for (int i = 0; i < myList.Count; i++)
            {
                if (myList[i].itemName.ToLower() == "burgery" || myList[i].itemName.ToLower() == "pizzy" || myList[i].itemName.ToLower() == "napoj" 
                    || myList[i].itemName.ToLower() == "drink" || myList[i].itemName.ToLower() == "zloż zamowienie" || myList[i].itemName.ToLower() == "id search"
                    || myList[i].itemName.ToLower() == "podaj co trzeba usunąć")
                {
                    Console.WriteLine($"[{myList[i].index}] {myList[i].itemName}");
                }
                else 
                {
                    Console.WriteLine($"[{myList[i].index}] {myList[i].itemName} - {myList[i].price} zl");
                }


            }
        }

    }
}
