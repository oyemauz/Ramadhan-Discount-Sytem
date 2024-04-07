using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramadhan_Discount_System
{
    public class Meat : Items
    {
        private string _freshness;

        public Meat(string id, string name, double price, double discount, Date manufacture, Date expiry, string f, int stock = 0) : base(id, name, price, discount, manufacture, expiry, stock)
        {
            _freshness = f;
        }

        public override void DisplayItemsInformation(bool includeStockInfo)
        {
            Console.WriteLine("Item ID: " + this.ItemId);
            Console.WriteLine("Item Name: " + this.ItemName);
            Console.WriteLine("Item Price: " + this.ItemPrice);
            Console.WriteLine(ItemDiscountRate * 100 + "% discount on Each Item ");
            Console.WriteLine("Item Manufacture Date: " + ItemManufactureDate.GetDate("dd/MM/yyyy"));
            Console.WriteLine("Item Expiry Date: " + ItemExpiryDate.GetDate("dd/MM/yyyy"));
            Console.WriteLine("is Freshness: " + _freshness);

            // Check if stock information should be displayed
            if (includeStockInfo)
            {
                Console.WriteLine("Item Stock: " + Stock);
            }

            Console.WriteLine(); // Add a newline for separation
        }
        public string Freshness { get => _freshness; set => _freshness = value; }
    }
}