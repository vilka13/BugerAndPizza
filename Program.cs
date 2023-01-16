using Microsoft.VisualBasic.FileIO; //Potrzebne Biblioteki
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;


namespace Restauracja_FasbiersPizza //
{

    class Program //Dodawanie klasy
    {
 
        
        static void Main(string[] args) //funkcija Main 
            {


                Console.Clear();
                Order order = new Order();


                decimal personMoney = 100m;  //Dodawanie pieniędzy do użytkownika w formie przykładowej
                bool payed = false;

                int input = 1;
                while (input != 0)         //Funkcja, która przetwarza dane użytkownika
            {
                    Console.WriteLine("_____Zapraszamy do naszego resoranu_____");
                    Console.WriteLine("___________________MENU___________________");
                    MenuItems.CreateMenu(MenuItems.MainMenuItems.mainMenuItemsList); //Bierze list który jest w ItemList
                Console.WriteLine("[0] Wyjż z Restauranu");
                    Console.Write("Wybież opcje: ");

                    while (!int.TryParse(Console.ReadLine(), out input))  //Bierze list który jest w ItemList
                {
                        Console.Clear();
                        Console.WriteLine("Wybież dania");
                        MenuItems.CreateMenu(MenuItems.MainMenuItems.mainMenuItemsList);
                        Console.WriteLine("[0] Powrót do MENU");
                        Console.WriteLine("Wpisałeś nieprawidłowe znaczenie");
                        Console.Write("Wpisz ponownie");
                    }

                    Console.WriteLine("");

                switch (input)  //6 przypadków, które dodają i usuwają wybrane elementy do czeku
                {
                    case 1:

                        Burger burger = new Burger();
                        int choice = 1;
                        order.BuildBurgerOrder(order, choice, burger);
                        Console.Clear();
                        order.ShowBurgersOrder();
                        order.ShowPizzasOrder();
                        order.ShowDrinkssOrder();
                        break;
                    case 2:

                        Pizza pizza = new Pizza();
                        choice = 1;
                        order.BuildPizzaOrder(order, choice, pizza);
                        Console.Clear();
                        order.ShowBurgersOrder();
                        order.ShowPizzasOrder();
                        order.ShowDrinkssOrder();
                        break;
                    case 3:
                       
                        Drinks drinks = new Drinks();
                        int choiceItem = 1;
                        int choiceSize = 1;
                        order.BuildDrinksOrder(choiceItem, choiceSize, order, drinks);
                        Console.Clear();
                        order.ShowBurgersOrder();
                        order.ShowPizzasOrder();
                        order.ShowDrinkssOrder();
                        break;
                    case 4:    //Sumowanie zamówienia
                      
                        Console.Clear();
                        order.TopCheck();
                        order.ShowBurgerOrder();
                        order.ShowPizzaOrder();
                        order.ShowDrinksOrder();
                        order.CheckOut(personMoney);
                        Console.WriteLine("\nZapraszamy ponownie\n Naciśnij 0, aby wyjść....\n");
                        Console.ReadLine();
                        Console.Clear();
                        order.ClearAllOrdersAndList();
                        payed = true;
                        break;
                    case 5:  //Wyszukaj zamówienie według ID

                        Console.Clear();
                        order.loadFileAndSelectID();
                        //order.SearchID();
                        break;

                    case 6:
                        Console.WriteLine($"Podaj co\n1:Bubger\n2:Pizzy\n3:Napoj "); //Walizka, która usuwa niepotrzebne
                        string f = Console.ReadLine();
                        int u = Convert.ToInt32(f);
                        
                        if (u == 1)
                        {
                            Console.WriteLine("Usuwamy Burgery"); //usuwanie Burgerow
                            string c = Console.ReadLine();
                            int g = Convert.ToInt32(c)-1;
                            order.MyBurgers.RemoveAt(g);
                            order.ShowBurgersOrder();
                            order.ShowPizzasOrder();
                            order.ShowDrinkssOrder();

                        }

                        if (u == 2)
                        {
                            Console.WriteLine("Usuwamy Pizzy "); //usuwanie Pizze
                            string c = Console.ReadLine();
                            int g = Convert.ToInt32(c) - 1;
                            order.MyPizzas.RemoveAt(g);
                            order.ShowBurgersOrder();
                            order.ShowPizzasOrder();
                            order.ShowDrinkssOrder();
                            
                        }

                        if (u == 3)
                        {
                            Console.WriteLine("Usuwamy Napoj"); //usuwanie Napojow
                            string c = Console.ReadLine();
                            int g = Convert.ToInt32(c) -1;
                            Drinks.drinksItemsList.RemoveAt(g);
                            order.ShowBurgersOrder();
                            order.ShowPizzasOrder();
                            order.ShowDrinkssOrder();
                           
                        }
                        
                        
                        break;

                    default:
                            char oops;
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
                                    
                                    order.CheckOut(personMoney);
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

