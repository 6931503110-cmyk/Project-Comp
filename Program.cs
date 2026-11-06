
using System;
using System.Collections.Generic;
using System.IO;

namespace project
{
    internal class Program
    {
        static int orderType, menuType;
        static int totalPrice = 0;
        static int getMoney;

        
        static List<OrderItem> orderList = new List<OrderItem>();

        
        static int[,] salesData = new int[3, 2];

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

                if (orderType >= 1 && orderType <= 3)
                {
                    do
                    {
                        SelectMenu();
                    }
                    while (menuType != 4);

                    // แสดงรายการอาหารก่อนจ่ายเงิน
                    OrderSummary();

                    Payment();

                    break;
                }

            }
            while (orderType != 4);
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
                case 1:
                    Console.WriteLine("You selected Dine In.");
                    break;

                case 2:
                    Console.WriteLine("You selected Take Out.");
                    break;

                case 3:
                    Console.WriteLine("You selected Delivery.");
                    break;

                case 4:
                    Console.WriteLine("Exiting the program.");
                    break;

                default:
                    Console.WriteLine("Invalid selection. Please try again.");
                    break;
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

                    if (foodChoice >= 1 && foodChoice <= FoodMenu.Length)
                    {
                        Console.Write("Enter quantity: ");
                        int quantity = int.Parse(Console.ReadLine());

                        if (quantity > 0)
                        {
                            foodChoice--;

                            Menu selectedFood = FoodMenu[foodChoice];

                            totalPrice += selectedFood.Price * quantity;

                            orderList.Add(new OrderItem(
                                selectedFood.Name,
                                selectedFood.Price,
                                quantity
                            ));

                            // บันทึกลง 2D Array
                            salesData[0, 0] += quantity;
                            salesData[0, 1] += selectedFood.Price * quantity;

                            Console.WriteLine("Your selection:");
                            selectedFood.ShowMenu();
                        }
                        else
                        {
                            Console.WriteLine("Invalid quantity!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid food selection!");
                    }

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

                    if (drinkChoice >= 1 && drinkChoice <= DrinkMenu.Length)
                    {
                        Console.Write("Enter quantity: ");
                        int quantity = int.Parse(Console.ReadLine());

                        if (quantity > 0)
                        {
                            drinkChoice--;

                            Menu selectedDrink = DrinkMenu[drinkChoice];

                            totalPrice += selectedDrink.Price * quantity;

                            orderList.Add(new OrderItem(
                                selectedDrink.Name,
                                selectedDrink.Price,
                                quantity
                            ));

                            
                            salesData[1, 0] += quantity;
                            salesData[1, 1] += selectedDrink.Price * quantity;

                            Console.WriteLine("Your selection:");
                            selectedDrink.ShowMenu();
                        }
                        else
                        {
                            Console.WriteLine("Invalid quantity!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid drink selection!");
                    }

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

                    if (sidedishChoice >= 1 && sidedishChoice <= SideDishMenu.Length)
                    {
                        Console.Write("Enter quantity: ");
                        int quantity = int.Parse(Console.ReadLine());

                        if (quantity > 0)
                        {
                            sidedishChoice--;

                            Menu selectedSideDish = SideDishMenu[sidedishChoice];

                            totalPrice += selectedSideDish.Price * quantity;

                            orderList.Add(new OrderItem(
                                selectedSideDish.Name,
                                selectedSideDish.Price,
                                quantity
                            ));

                            
                            salesData[2, 0] += quantity;
                            salesData[2, 1] += selectedSideDish.Price * quantity;

                            Console.WriteLine("Your selection:");
                            selectedSideDish.ShowMenu();
                        }
                        else
                        {
                            Console.WriteLine("Invalid quantity!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid side dish selection!");
                    }

                    break;

                case 4:
                    Console.WriteLine("");
                    Console.WriteLine("==================================");
                    Console.WriteLine("Proceeding to payment...");
                    Console.WriteLine("==================================");
                    return;

                default:
                    Console.WriteLine("Invalid selection. Please try again.");
                    break;
            }

            Console.WriteLine("");
        }

        
        static void OrderSummary()
        {
            Console.WriteLine("");
            Console.WriteLine("========== ORDER SUMMARY ==========");

            foreach (OrderItem item in orderList)
            {
                item.ShowOrder();
            }

            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"Total Price: {totalPrice} baht");
            Console.WriteLine("===================================");
        }

       
        static void Payment()
        {
            if (orderType == 3)
            {
                totalPrice += 15;
            }

            Console.WriteLine("");
            Console.WriteLine($"Total Price: {totalPrice} baht");

            Console.Write("Enter the amount of money you are paying: ");
            getMoney = int.Parse(Console.ReadLine());

            while (getMoney < totalPrice)
            {
                Console.WriteLine("Insufficient funds. Please try again.");
                Console.Write("Enter the amount of money: ");
                getMoney = int.Parse(Console.ReadLine());
            }

            int change = getMoney - totalPrice;

            Console.WriteLine($"Change: {change} baht");
            Console.WriteLine("Thank you for your order!");

            SaveOrder(change);

            
            SalesReport();
        }

      
        static void SaveOrder(int change)
        {
            string fileName = "OrderHistory.txt";

            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine("========== NEW ORDER ==========");
                writer.WriteLine($"Order Type: {orderType}");
                writer.WriteLine($"Date: {DateTime.Now}");

                foreach (OrderItem item in orderList)
                {
                    writer.WriteLine(
                        $"{item.Name} x {item.Quantity} = {item.Price * item.Quantity} baht"
                    );
                }

                writer.WriteLine($"Total: {totalPrice} baht");
                writer.WriteLine($"Paid: {getMoney} baht");
                writer.WriteLine($"Change: {change} baht");
                writer.WriteLine("===============================");
                writer.WriteLine("");
            }

            Console.WriteLine("Order saved successfully!");
        }

       
        static void SalesReport()
        {
            Console.WriteLine("");
            Console.WriteLine("========== SALES REPORT ==========");

            string[] categories = { "Food", "Drink", "Side Dish" };

            int totalSales = 0;
            int totalQuantity = 0;

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(
                    $"{categories[i]}: {salesData[i, 0]} items | {salesData[i, 1]} baht"
                );

                totalQuantity += salesData[i, 0];
                totalSales += salesData[i, 1];
            }

            Console.WriteLine("----------------------------------");
            Console.WriteLine($"Total Quantity: {totalQuantity}");
            Console.WriteLine($"Total Sales: {totalSales} baht");
            Console.WriteLine("==================================");
        }
    }

   
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

    
    public class OrderItem
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        public OrderItem(string name, int price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public void ShowOrder()
        {
            Console.WriteLine(
                $"{Name} x {Quantity} = {Price * Quantity} baht"
            );
        }
    }
}
