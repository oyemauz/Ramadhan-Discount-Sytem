using System.Net.Mail;
using System.Net;
using System.Runtime.CompilerServices;

namespace Ramadhan_Discount_System
{
    public class Program
    {
        static void Main(string[] args)
        {
            ItemDirectory item=new ItemDirectory();
            UserDirectory user=new UserDirectory();
            Dictionary<string, List<Items>> _itemsByCategory = item.GetItemsByCategory();

            // Fruit Category.
            Fruits fruit1 = new Fruits("1", "Apple", 150, 0.05,(new Date(1, 3, 2004)), (new Date(3, 12, 2007)), "Ripe",12);
            Fruits fruit2 = new Fruits("2", "Peach", 200, 0.05, (new Date(1, 3, 2004)), (new Date(3, 12, 2007)), "Ripe",15);
            Fruits fruit3 = new Fruits("3", "Grapes", 250, 0.05, (new Date(1, 3, 2004)), (new Date(3, 12, 2007)), "Ripe",10);

            item.AddItemToCategory("fruits", fruit1);
            item.AddItemToCategory("fruits", fruit2);
            item.AddItemToCategory("fruits", fruit3);

            // Drinks Category.
            Drinks drink1 = new Drinks("4", "Rooh Afza", 420, 0.05, (new Date(3, 6, 2004)), (new Date(13, 5, 2007)), "Moderate",50);
            Drinks drink2 = new Drinks("5", "Coca Cola", 150, 0.05, (new Date(3, 6, 2004)), (new Date(13, 5, 2007)), "Cold", 50);
            Drinks drink3 = new Drinks("6", "Nestle Water", 80, 0.05, (new Date(3, 6, 2004)), (new Date(13, 5, 2007)), "Cold", 100);

            item.AddItemToCategory("drinks", drink1);
            item.AddItemToCategory("drinks", drink2);
            item.AddItemToCategory("drinks", drink3);

            // Meat Category.
            Meat meat1 = new Meat("7", "Chicken", 600, 0.05, (new Date(3, 6, 2004)), (new Date(13, 5, 2007)), "Fresh", 50);
            Meat meat2 = new Meat("8", "Beef", 1200, 0.05, (new Date(3, 6, 2004)), (new Date(13, 5, 2007)), "Fresh", 30);
            Meat meat3 = new Meat("9", "Mutton", 2000, 0.05, (new Date(3, 6, 2004)), (new Date(13, 5, 2007)), "Fresh", 20);

            item.AddItemToCategory("meat", meat1);
            item.AddItemToCategory("meat", meat2);
            item.AddItemToCategory("meat", meat3);


            LocalUser user1 = new LocalUser("Muaz","oyemauz@gmail.com");
            LocalUser user2 = new LocalUser("Ahmad", "muazch287@gmail.com");
            LocalUser user3 = new LocalUser("Ali", "ali@gmail.com");
            Customer customer = new Customer();

           
            customer.RunApplication(item, user, _itemsByCategory);

        }
    }
}

/*
  if (user.SignUp("user", 110, user3))
            {
            }

            item.DisplayAllItemsByCategory(false);

            if (user.Login("ali@gmail.com", 110, "user"))
            {
                user.AddItemToCart(110, "apple", "fruits", _itemsByCategory, 2);
                user.AddItemToCart(110, "coca cola", "drinks", _itemsByCategory, 3);
                user.AddItemToCart(110, "mutton", "meat", _itemsByCategory, 3);

                // user.DisplayCartItems(110);

                // user.GenerateUserBill(110);

                item.DisplayAllItemsByCategory(false);

                //  user.DisplayAllOrders();

            }

*/