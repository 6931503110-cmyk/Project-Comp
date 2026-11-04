using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{

    internal class Program
    {
        static int orderType, menuType;
        static int totalPrice = 0;
        static int getMoney;
        static Menu[] FoodMenu = new Menu[]
        {
            new Menu("Pork Larb with Pork Offal", 60),
            new Menu("Chicken Larb", 50),
            new Menu("Fish Larb", 50),
            new Menu("Spicy Grilled Pork Salad", 55),
            new Menu("Spicy and Sour Pork Soup", 60),
            new Menu("Spicy Pork Bone Soup ", 55)
        };
        static Menu[] DrinkMenu = new Menu[]
        {
            new Menu("Watermelon Smoothie", 35),
            new Menu("Drinking Water", 7),
            new Menu("Chrysanthemum", 30),
            new Menu("Pepsi", 17)
        };
        static Menu[] SideDishMenu = new Menu[]
        {
            new Menu("Sticky Rice", 10),
            new Menu("Steamed Rice", 10),
            new Menu("Fried Red Sausages", 20)
        };
        static void Main(string[] args)
        {   
            do
            {
                OrderType();
                if (orderType < 4)
                {
                    do
                    {
                        SelectMenu();
                    }
                    while (menuType != 4);
                    Payment();
                    break;
                }
            }
            while (orderType != 4 );
           
        }

        static int OrderType()
        {    
            Console.WriteLine("");
            Console.WriteLine("Select Order Type (Select only 1-3):");
            Console.WriteLine("1. Dine In");
            Console.WriteLine("2. Take Out");
            Console.WriteLine("3. Delivery (+15 baht)");
            Console.WriteLine("4. Exit");
            Console.WriteLine();
            Console.WriteLine("==================================");
            Console.WriteLine("");
            Console.Write("Enter your choice: ");
            orderType = int.Parse(Console.ReadLine());
            Console.WriteLine("");
            switch (orderType)
            {
                case 1: Console.WriteLine("You selected Dine In."); break;
                case 2: Console.WriteLine("You selected Take Out."); break;
                case 3: Console.WriteLine("You selected Delivery."); break;
                case 4: Console.WriteLine("Exiting the program."); break;
                default: Console.WriteLine("Invalid selection. Please try again."); break;
            }
            Console.WriteLine("");
            Console.WriteLine("==================================");
            Console.WriteLine("");
            return orderType;
        }

        static void SelectMenu()
        {    
            Console.WriteLine("Select Menu Type (Select only 1-3):");
            Console.WriteLine("1. Food");
            Console.WriteLine("2. Drink");
            Console.WriteLine("3. Side Dish");
            Console.WriteLine("4. Continue to Payment");
            Console.WriteLine("");
            Console.Write("Enter your choice: ");
            menuType = int.Parse(Console.ReadLine());
            switch (menuType)
            {
                case 1:              
                    uint foodChoice;
                    Console.WriteLine("");
                    Console.WriteLine("==================================");
                    foreach (Menu foodMenu in FoodMenu)
                    {
                        foodMenu.ShowMenu();
                    }
                    Console.WriteLine("");
                    Console.Write("Select Food Menu (1-6): ");
                    foodChoice = uint.Parse(Console.ReadLine());
                    Console.WriteLine("");
                    Console.WriteLine("==================================");
                    Console.WriteLine("");
                    foodChoice -=1;
                    totalPrice += FoodMenu[foodChoice].Price;
                    Console.Write("Your selection: ");
                    FoodMenu[foodChoice].ShowMenu();
                    Console.WriteLine("");
                    Console.WriteLine("==================================");
                    break;
                case 2:
                    uint drinkChoice;
                    Console.WriteLine("");
                    Console.WriteLine("==================================");
                    foreach (Menu drinking in DrinkMenu)
                    {
                        drinking.ShowMenu();
                    }
                    Console.WriteLine("");
                    Console.Write("Select Drink Menu (1-4): ");
                    drinkChoice = uint.Parse(Console.ReadLine());
                    Console.WriteLine("");
                    Console.WriteLine("==================================");
                    Console.WriteLine("");
                    drinkChoice -=1;
                    totalPrice += DrinkMenu[drinkChoice].Price;
                    Console.Write("Your selection: ");
                    DrinkMenu[drinkChoice].ShowMenu();
                    Console.WriteLine("");
                    Console.WriteLine("==================================");
                    break;
                case 3:
                    uint sidedishChoice;
                    Console.WriteLine("");
                    Console.WriteLine("==================================");
                    foreach (Menu sidedish in SideDishMenu)
                    {
                        sidedish.ShowMenu();
                    }
                    Console.WriteLine("");
                    Console.Write("Select Side Dish Menu (1-3): ");
                    sidedishChoice = uint.Parse(Console.ReadLine());
                    Console.WriteLine("");
                    Console.WriteLine("==================================");
                    Console.WriteLine("");
                    sidedishChoice -=1;
                    totalPrice += SideDishMenu[sidedishChoice].Price;
                    Console.Write("Your selection: ");
                    SideDishMenu[sidedishChoice].ShowMenu();
                    Console.WriteLine("");
                    Console.WriteLine("==================================");
                    break;
                case 4:
                    Console.WriteLine("");
                    Console.WriteLine("==================================");
                    Console.WriteLine("");
                    Console.WriteLine("Proceeding to payment...");
                    Console.WriteLine("");
                    Console.WriteLine("==================================");
                    return ;
                default:
                    Console.WriteLine("");
                    Console.WriteLine("==================================");
                    Console.WriteLine("");
                    Console.WriteLine("Invalid selection. Please try again.");
                    Console.WriteLine("");
                    Console.WriteLine("==================================");
                    break;
            }
            Console.WriteLine("");

        }
        static void Payment()
        {
            if (orderType == 3)
            {
                totalPrice += 15;
            }a
            Console.WriteLine("");
            Console.WriteLine($"Total Price: {totalPrice} baht");
            Console.Write("Enter the amount of money you are paying: ");
            getMoney = int.Parse(Console.ReadLine());
            if (getMoney < totalPrice)
            {
                Console.WriteLine("Insufficient funds. Please try again.");
                Payment();
            }
            else
            {
                int change = getMoney - totalPrice;
                Console.WriteLine($"Change: {change} baht");
                Console.WriteLine("Thank you for your order!");
            }
        }
    }
    // Menu class to represent menu items
    public class Menu
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public Menu(string name, int price)
        {
            Name = name;
            Price = price;
        }
        public void ShowMenu()
        {
            Console.WriteLine($"{Name} : {Price} baht");
        }
    }
}