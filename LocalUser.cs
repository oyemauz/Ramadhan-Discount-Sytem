using System;
using System.Collections.Generic;
using System.Linq;

namespace Ramadhan_Discount_System
{
    public class LocalUser : User
    {
        private Dictionary<Items, int> _orderItems;

        public Dictionary<Items, int> OrderItems { get => _orderItems; set => _orderItems = value; }

        public LocalUser()
        {
            OrderItems = new Dictionary<Items, int>();
        }

        public LocalUser(string name, string email)
        {
            Name = name;
            Email = email;
            OrderItems = new Dictionary<Items, int>();
        }

        public void AddItemToOrder(Items item, int quantity)
        {
            Console.WriteLine("muaz order -> "+quantity);
            if (item == null)
            {
                Console.WriteLine("Cannot add a null item to the order.");
                return;
            }

            if (OrderItems.ContainsKey(item))
            {
                // Item already exists in the order, increase the quantity
                OrderItems[item] += quantity;
            }
            else
            {
                // Item does not exist in the order, add it with the specified quantity
                OrderItems[item] = quantity;
            }
        }

        public void RemoveItemFromOrder(Items item, int quantity)
        {
            if (item == null)
            {
                Console.WriteLine("Cannot remove a null item from the order.");
                return;
            }

            if (OrderItems.ContainsKey(item))
            {
                // Decrease the item's quantity by the specified amount
                OrderItems[item] -= quantity;

                // If the quantity becomes zero or less, remove the item from the order
                if (OrderItems[item] <= 0)
                {
                    OrderItems.Remove(item);
                }
            }
            else
            {
                Console.WriteLine("Item not found in the order.");
            }
        }

        public  double CalculateDiscountedPrice(Items item,int quantity)
        {
            //return (item.ItemPrice - ((item.ItemPrice * quantity) * item.ItemDiscountRate));
            return (item.ItemPrice * quantity) * item.ItemDiscountRate;
        }

        public void GenerateItemBill()
        {
            if (OrderItems.Count > 0)
            {
                Console.WriteLine("{0,-5} {1,-20} {2,-10} {3,-10}", "Qty", "Item Name", "Price", "Total");
                Console.WriteLine("---------------------------------------------------");

                double totalPrice = 0;
                double TotaldiscountPrice = 0;
                foreach (var kvp in OrderItems)
                {
                    Items item = kvp.Key;
                    int quantity = kvp.Value;

                    // Calculate total price for this item based on quantity
                     TotaldiscountPrice = ((item.ItemPrice * quantity) * item.ItemDiscountRate);
                    double totalItemPrice = ((item.ItemPrice * quantity));
                    // Update total price for the bill
                    totalPrice += totalItemPrice;

                    // Display item details in the bill
                    Console.WriteLine("{0,-5} {1,-20} {2,-10} {3,-10}", quantity, item.ItemName, item.ItemPrice.ToString("C"), totalItemPrice.ToString("C"));
                }

                Console.WriteLine(" --------------------------------------------------");
                Console.WriteLine(" {0,-35} {1,-10:C}", "Sub Total:", totalPrice.ToString("C"));
                Console.WriteLine(" {0,-35} {1,-10:C}", "Taxes:",10);
                Console.WriteLine(" {0,-35} {1,-10:C}", "Discount:", TotaldiscountPrice);
                Console.WriteLine();
                Console.WriteLine(" {0,-35} {1,-10:C}", "Total:", totalPrice-TotaldiscountPrice-10);
                Console.WriteLine(" --------------------------------------------------");
                Console.WriteLine(" |  ||   | |    |||  |  |||    | |  | ||  |");
                Console.WriteLine(" |  ||   | |    |||  |  |||    | |  | ||  |");
                Console.WriteLine(" |  ||   | |    |||  |  |||    | |  | ||  |");
                Console.WriteLine(" |  ||   | |    |||  |  |||    | |  | ||  |");
                Console.WriteLine("                 abc-8892-rds          ");
                Console.WriteLine(" --------------------------------------------------");
                Console.WriteLine(" --------------------------------------------------");
                Console.WriteLine("\n");
                Console.WriteLine("          * THANK YOU FOR SHOPING HERE *      ");
                Console.WriteLine("\n\n");


            }
            else
            {
                Console.WriteLine("No items in User Cart.");
            }
        }

        public void DisplayAllOrderItems()
        {
            if (OrderItems.Count > 0)
            {
                Console.WriteLine("Items in the Order:");
                foreach (var kvp in OrderItems)
                {
                    Items item = kvp.Key;
                    int quantity = kvp.Value;

                    Console.WriteLine($"\nItem ID: {item.ItemId}");
                    Console.WriteLine($"Item Name: {item.ItemName}");
                    Console.WriteLine($"Item Price: {item.ItemPrice:C}");
                    Console.WriteLine($"Quantity: {quantity}");
                }
            }
            else
            {
                Console.WriteLine("No items in the order.");
            }
        }
    }
}
