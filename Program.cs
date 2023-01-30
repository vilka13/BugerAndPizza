using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
namespace Restauracja_FasbiersPizza
{
    class Program
    {
        static void Main(string[] args) //menu
            {
                Console.Clear();

                Order order = new Order();
                bool payed = false;
                int input = 1;
                while (input != 0)
                {
                    Console.WriteLine("___________________MENU___________________");
                    MenuItems.CreateMenu(MenuItems.MainMenuItems.mainMenuItemsList);
                    Console.WriteLine("[0] Wyjż z Restauranu");
                    Console.Write("Wybież opcje: ");
                    while (!int.TryParse(Console.ReadLine(), out input))
                    {
                        Console.Clear();
                        Console.WriteLine("Wybież dania");
                        MenuItems.CreateMenu(MenuItems.MainMenuItems.mainMenuItemsList);
                        Console.WriteLine("[0] Powrót do MENU");
                        Console.WriteLine("Wpisałeś nieprawidłowe znaczenie");
                        Console.Write("Wpisz ponownie");
                    }
                    Console.WriteLine("");
                switch (input)
                {
                    case 1: // Burger items
                        Burger burger = new Burger();
                        int choice = 1;
                        order.BuildBurgerOrder(order, choice, burger);
                        Console.Clear();
                        order.ShowFinalOrder();
                        break;
                    case 2: // Pizzaa items
                        Pizza pizza = new Pizza();
                        choice = 1;
                        order.BuildPizzaOrder(order, choice, pizza);
                        Console.Clear();
                        order.ShowFinalOrder();
                        break;
                    case 3: // Drings items
                        Drinks drinks = new Drinks();
                        int choiceItem = 1;
                        int choiceSize = 1;
                        order.BuildDrinksOrder(choiceItem, choiceSize, order, drinks);
                        Console.Clear();
                        order.ShowFinalOrder();
                        break;
                    case 4: //Checkout
                        Console.Clear();
                        order.TopCheck();
                        order.ShowBurgerOrder();
                        order.ShowPizzaOrder();
                        order.ShowDrinksOrder();   
                        
                        order.CheckOut();
                        Console.WriteLine("\nZapraszamy ponownie\n Naciśnij 0, aby wyjść....\n");
                        Console.ReadLine();
                        Console.Clear();
                        order.ClearAllOrdersAndList();
                        payed = true;
                        break;
                    case 5: //Search ID
                        Console.Clear();
                        order.loadFileAndSelectID();
                        break;
                    case 6: // Usuniecie dania
                        Console.Clear();
                        order.ShowFinalOrder();
                        Console.WriteLine("1:Bubger\n2:Pizzy\n3:Napoj ");
                        Console.Write("Poday co usunac: ");
                        int u = -1;
                        try {
                            string f = Console.ReadLine();
                            u = Convert.ToInt32(f);
                        }
                        catch (System.OverflowException) 
                        {
                            Console.Clear();
                            Console.WriteLine("\nNieprawildlowa liczba");
                        }
                        catch (System.FormatException) 
                        {
                            Console.Clear();
                            Console.WriteLine("\nNieprawildlowa liczba");
                        } 
                        if (u == 1 )
                        {
                            Console.WriteLine("Usuwamy Burgery");
                            int g = -1;
                            try {
                                string c = Console.ReadLine();
                                g = Convert.ToInt32(c) - 1;
                            }
                            catch (System.OverflowException)
                            { }
                            catch (System.FormatException) { }
                            if (g >= 0 && g < order.MyBurgers.Count)
                            {
                                order.MyBurgers.RemoveAt(g);
                                Console.Clear();
                                order.ShowFinalOrder();
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("\n#Niema takiej pozycji#\n#Sprobuj ponownie#\n");
                                order.ShowFinalOrder();
                            }
                        }
                        if (u == 2)
                        {
                            Console.WriteLine("Usuwamy Pizzy ");
                            int g = -1;
                            try {
                                string c = Console.ReadLine();
                                g = Convert.ToInt32(c) - 1;
                            }
                            catch (System.OverflowException) 
                            {
                                Console.Clear();
                                Console.WriteLine("\nNieprawildlowa liczba");
                            }
                            catch (System.FormatException) 
                            {
                                Console.Clear();
                                Console.WriteLine("\nNieprawildlowa liczba");
                            }
                            if (g >= 0 && g < order.MyPizzas.Count)
                            {
                                order.MyPizzas.RemoveAt(g);
                                Console.Clear();
                                order.ShowFinalOrder();
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("\n#Niema takiej pozycji#\n#Sprobuj ponownie#\n");
                                order.ShowFinalOrder();
                            }
                        }
                        if (u == 3)
                        {
                            Console.WriteLine("Usuwamy Napoj");
                                int g = -1;
                                try {
                                    string c = Console.ReadLine();
                                     g = Convert.ToInt32(c) - 1;
                                }
                                catch (System.OverflowException) 
                            {
                                Console.Clear();
                                Console.WriteLine("\nNieprawildlowa liczba");
                            }
                                catch (System.FormatException) 
                            {
                                Console.Clear();
                                Console.WriteLine("\nNieprawildlowa liczba");
                            }
                            if (g>=0 && g < order.MyDrinks.Count)
                            {
                                Drinks.drinksItemsList.RemoveAt(g);
                                Console.Clear();
                                order.ShowFinalOrder();
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("\n#Niema takiej pozycji#\n#Sprobuj ponownie#\n");
                                order.ShowFinalOrder();
                            }
                        }
                        break;
                    default:
                            char oops;  // Funkcja jest uruchamiana, gdy zapomnisz zapłacić
                        if (input == 0 && payed == false && (order.MyBurgers.Count + order.MyDrinks.Count + order.MyPizzas.Count) > 0)
                            {
                                Console.WriteLine($"\noops zapomniałeś zapłacić, did you mean to Checkout and pay instead? Press Y for yes.");
                                while (!char.TryParse(Console.ReadLine(), out oops))
                                {
                                    Console.WriteLine($"\nOops you forgot to pay, did you mean to Checkout and pay instead? Press Y for yes.");
                                }
                                if (oops == 'y' || oops == 'Y')
                                {
                                    Console.WriteLine("\nDziękujemy za wprowadzenie poprawki.!!\n**** Twój Paragon ****\n");
                                    order.ShowBurgerOrder();
                                    order.ShowPizzaOrder();
                                    order.ShowDrinksOrder();

                                    order.CheckOut();
                                    Console.WriteLine("\nZapraszamy ponownie\n Wybież 0 zeby opósić....\n");
                                    Console.ReadLine();
                                    Console.Clear();
                                    order.ClearAllOrdersAndList();
                                    payed = true;
                                }
                                else
                                {
                                    input = 0;
                                    payed = false;
                                    Console.WriteLine($"HEJ,WYSZEDŁEŚ BEZ PŁACENIA " + "\nWSTYDŹ SIĘ!!!!!");
                                    Console.WriteLine("\n\nNaciśnij Enter, aby wyjść z programu....");
                                    Console.ReadLine();
                                    continue;
                                }
                            }
                            else
                            {
                                Console.WriteLine("\n\nNaciśnij Enter, aby wyjść z programu....");
                                Console.ReadLine();
                            }
                            break;
                    }
                }
            }
        }
    }
