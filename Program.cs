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
            //Guid uniqueId = Guid.NewGuid();
            //string shortId = uniqueId.ToString().Substring(0, 10);

            Fruits fruit1 = new Fruits("1", "Apple", 100, 0.1,(new Date(1, 3, 2004)), (new Date(3, 12, 2007)), "Ripe",10);
            Fruits fruit2 = new Fruits("2", "Apple", 100, 0.1, (new Date(1, 3, 2004)), (new Date(3, 12, 2007)), "Ripe",20);

            Fruits fruit3 = new Fruits("3", "Grapes", 300, 0.1, (new Date(1, 3, 2004)), (new Date(3, 12, 2007)), "Ripe",100);
           // Drinks drink1 = new Drinks("3", "Rooh Afza", 420, 0.2, 0.2, 20, (new Date(3, 6, 2004)), (new Date(13, 5, 2007)), "Cold");
            // Fruit Category.
            item.AddItemToCategory("fruits", fruit1);
            item.AddItemToCategory("fruits", fruit2);
            item.AddItemToCategory("fruits", fruit3);

            // Drinks Category.
           // item.AddItemToCategory("Drinks", drink1);
            //item.AddItemToCategory("Drinks", new Fruits(4, "Juice", 180, 0.2,0.2,(new Date(1, 3, 2004)), (new Date(3, 12, 2007)), "Ripe"));

            LocalUser user1 = new LocalUser("Muaz","oyemauz@gmail.com");
            LocalUser user2 = new LocalUser("Ahmad", "muazch287@gmail.com");
            LocalUser user3 = new LocalUser("Ali", "ali@gmail.com");
            Customer customer = new Customer();

            //customer.RunApplication(item, user);

          //  Admin admin1 = new Admin("Patu","f@umt.edu.pk");
            // Admin admin2 = new Admin("mandjenj", "f25252@umt.edu.pk");

            //  if (user.SignUp("admin", 110, admin1))
            //  {
            // admin.DisplayAdmin();

            //  }

            Dictionary<string, List<Items>> _itemsByCategory = item.GetItemsByCategory();




             customer.RunApplication(item, user, _itemsByCategory);

            //LocalUser localUser = new LocalUser();
            //List <Items> localitem= localUser.OrderedItems();





            /*

        if (user.SignUp("user", 110, user3))
        {
        }


        if (user.Login("ali@gmail.com", 110))
        {
            user.AddItemToCart(110, "apple", "fruits", _itemsByCategory, 2);
            user.AddItemToCart(110, "grapes", "fruits", _itemsByCategory, 5);
            user.DisplayCartItems(110);

            user.GenerateUserBill(110);

            user.DisplayAllOrders();

        }

             item.DisplayAllItemsByCategory(false);


            if (user.SignUp("user", 110, user1))
            {
            }


            if (user.Login("oyemauz@gmail.com", 110))
            {
                user.AddItemToCart(110, "apple", "fruit", _itemsByCategory, 2);
                user.DisplayCartItems(110);

                 user.RemoveItemFromCart(110, "apple",3);
                user.DisplayCartItems(110);

            }

            if (user.SignUp("admin", 110, admin2))
            {
                admin2.DisplayAdmin();

            }

            if (user.Login("muazch287@gmail.com", 110))
            {
                user.AddItemToCart(110, fruit1, 2);
                user.DisplayCartItems(110);
            }


            if (user.SignUp("user", 100,user1))
            {
                 // user.DisplayUserAccount(100);

            }

            if (user.SignUp("user", 110, user2))
            {
               // user.DisplayUserAccount(110);
            }

            if (user.SignUp("user", 120, user3))
            {
               // user.DisplayUserAccount(120);
            }



            {
                  user.AddItemToCart(100, fruit1, 2);
                  user.RemoveItemFromCart(100, fruit1, 1);
                  user.DisplayCartItems(100);
            }
            if (user.Login("oyemauz@gmail.com", 100))


            if (user.Login("muazch287@gmail.com", 110))
            {
                user.AddItemToCart(110, drink1, 2);
                user.DisplayCartItems(110);
            }

            // item.DisplayAllItemsByCategory();
            // Items i=(item.FindItem("Fruit", fruit2));
            // i.DisplayItemsInformation();
            */
        }
    }
}



// Console.WriteLine(localUser.OrderedItems().Count);




//  customer.AddItemtoCategory(item);
// customer.AddItemtoCategory(item);

// customer.AddtoCart(user, fruit);

//            item.DisplayItemsOfCategory(true, "fruits");


//  if (user.Login("muazch287@gmail.com", 110))
// {
//  user.AddItemToCart(110, customer, 2);
//  user.DisplayCartItems(110);
//  }



// Guid uniqueId = Guid.NewGuid();
// string shortId = uniqueId.ToString().Substring(0, 10);

//  customer.RunApplication(item, user);