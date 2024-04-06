using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramadhan_Discount_System
{
    public abstract class Items
    {
        private string _itemId;
        private string _itemName;
        private double _itemPrice;
        private int _stock;
        private double _ItemDiscountRate;
        private Date _itemManufactureDate;
        private Date _itemExpiryDate;

        public Items(string itemId, string itemName, double itemPrice,double discount,Date itemManufactureDate, Date itemExpiryDate, int stock = 0)
        {
                ItemId = itemId;
                ItemName = itemName;
                ItemPrice = itemPrice;
                ItemExpiryDate = itemExpiryDate;
                ItemManufactureDate = itemManufactureDate;
                ItemDiscountRate = discount;
                Stock = stock;
        }

        public virtual double CalculateDiscountedPrice(int quantity)
        {
            return (ItemPrice - ((this.ItemPrice * quantity) * this.ItemDiscountRate));
        }

        public abstract void DisplayItemsInformation(bool includeStockInfo);
       

        public string ItemId { get => _itemId; set => _itemId = value; }
        public string ItemName { get => _itemName; set => _itemName = value; }
        public double ItemPrice { get => _itemPrice; set => _itemPrice = value; }
        public Date ItemManufactureDate { get => _itemManufactureDate; set => _itemManufactureDate = value; }
        public Date ItemExpiryDate { get => _itemExpiryDate; set => _itemExpiryDate = value; }
        public int Stock { get => _stock; set => _stock = value; }
        public double ItemDiscountRate { get => _ItemDiscountRate; set => _ItemDiscountRate = value; }
    }
}
