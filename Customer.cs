using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramadhan_Discount_System
{
    public class Customer
    {
        private Admin admin;
      //  private List <LocalUser> _user;

        public Customer()
        {
          //  _user = new List <LocalUser>();
        }

        public void displayApplicationName()
        {
            Console.WriteLine("\n       ########################################");
            Console.WriteLine("       ####### Ramadhan Discount System #######");
            Console.WriteLine("       ########################################\n");
        }

        public string getRandomId()
        {
            Guid uniqueId = Guid.NewGuid();
            string shortId = uniqueId.ToString().Substring(0, 10);
            return shortId;
        } 

        public string ItemName()
        {
            Console.WriteLine("Item Name: ");
            string name=Console.ReadLine();
            return name;
        }
        public double ItemPrice()
        {
            Console.WriteLine("Item Price: ");
            double price = double.Parse(Console.ReadLine());
            return price;
        }

        public double ItemDiscount()
        {
            Console.WriteLine("Item Discount: ");
            double discount = double.Parse(Console.ReadLine());
            return discount;
        }

        public double ItemSpecialDiscount()
        {
            Console.WriteLine("Item Special Discount: ");
            double speacial_discount = double.Parse(Console.ReadLine());
            return speacial_discount;
        }

        public int ItemQuantity()
        {
            Console.WriteLine("Item Quantity: ");
            int quantity = int.Parse(Console.ReadLine());
            return quantity;
        }

        public int ItemStock()
        {
            Console.WriteLine("Item Stock: ");
            int speacial_discount = int.Parse(Console.ReadLine());
            return speacial_discount;
        }
        
        public Date ItemDate()
        {
            Console.WriteLine("Enter Date... ");
            Console.WriteLine("Enter day: ");
            int day= int.Parse(Console.ReadLine());
            Console.WriteLine("Enter month: ");
            int month = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Year: ");
            int year = int.Parse(Console.ReadLine());

            return new Date(day, month, year);

        }

    
       
        public void RunApplication(ItemDirectory item,UserDirectory user, Dictionary<string, List<Items>> _itemsByCategory)
        {
            bool oloop=true;

            while (oloop)
            {
                displayApplicationName();
                Console.WriteLine("\n1. for Admin mode ");
                Console.WriteLine("2. for User mode ");
                Console.WriteLine("3. for Exit Program\n");

                Console.WriteLine("Choose an option");
                int mode=int.Parse(Console.ReadLine());

                switch (mode)
                {
                    case 1:
                        {
                            bool iloop = true;
                            while (iloop)
                            {
                                Console.WriteLine("1. for SignUp ");
                                Console.WriteLine("2. for Login ");
                                Console.WriteLine("3. for Go back ");

                                Console.WriteLine("Choose an option ");
                                int adminopt=int.Parse(Console.ReadLine());
                                switch (adminopt)
                                {
                                    case 1: 
                                        {
                                            Console.WriteLine("Enter Account Number ");
                                            int accNumb=int.Parse(Console.ReadLine());
                                            Console.WriteLine(" Enter Name ");
                                            string name =Console.ReadLine();
                                            Console.WriteLine(" Enter Email ");
                                            string email = Console.ReadLine();
                                            string type = "admin";

                                            admin = new Admin(name, email);

                                            user.SignUp(type,accNumb,admin);

                                            break; 
                                        }
                                    case 2:
                                        {
                                            Console.WriteLine("Enter Account Number ");
                                            int accNumb = int.Parse(Console.ReadLine());
                                            Console.WriteLine(" Enter Email ");
                                            string email = Console.ReadLine();
                                           
                                            if(user.Login(email, accNumb,"admin"))
                                            {
                                                bool cloop = true;
                                                while (cloop)
                                                {
                                                    Console.WriteLine("\n1. for Add new Item ");
                                                    Console.WriteLine("2. for Remove any Items ");
                                                    Console.WriteLine("3. for Display All Items ");
                                                    Console.WriteLine("4. for Display All Users ");
                                                    Console.WriteLine("5. for See Profile ");
                                                    Console.WriteLine("6. for See Total Sale ");
                                                    Console.WriteLine("7. for Go back ");

                                                    Console.WriteLine("Choose an option... ");
                                                    int opt=int.Parse(Console.ReadLine());

                                                    switch(opt)
                                                    {
                                                        case 1:
                                                            {
                                                                bool categoryloop = true;

                                                                while (categoryloop)
                                                                {
                                                                    Console.WriteLine("\n1 for Fruits");
                                                                    Console.WriteLine("2 for Drinks");
                                                                    Console.WriteLine("3 for Meat");
                                                                    Console.WriteLine("4 for Go back");

                                                                    Console.WriteLine("Choose an option ");
                                                                    int categoryopt=int.Parse(Console.ReadLine());

                                                                    switch (categoryopt)
                                                                    {
                                                                        case 1:
                                                                            {
                                                                                string itemId = (getRandomId());
                                                                                string name = ItemName();
                                                                                int stock = ItemStock();
                                                                                double price = ItemPrice();
                                                                                double discount = ItemDiscount();
                                                                                Date ManufactureDate = ItemDate();
                                                                                Date ExpiryDate = ItemDate();
                                                                                string category = "fruits";
                                                                                Fruits fruit=new Fruits(itemId,name,price,discount,ManufactureDate,ExpiryDate,"is Ripe", stock);
                                                                                item.AddItemToCategory(category,fruit);
                                                                                break;
                                                                            }
                                                                        case 2:
                                                                            {
                                                                                string itemId = (getRandomId());
                                                                                string name = ItemName();
                                                                                int stock = ItemStock();
                                                                                double price = ItemPrice();
                                                                                double discount = ItemDiscount();
                                                                                Date ManufactureDate = ItemDate();
                                                                                Date ExpiryDate = ItemDate();
                                                                                string category = "drinks";
                                                                                Fruits fruit = new Fruits(itemId, name, price, discount, ManufactureDate, ExpiryDate, "is Ripe", stock);
                                                                                item.AddItemToCategory(category, fruit);
                                                                                break;
                                                                            }
                                                                        case 3:
                                                                            {
                                                                                string itemId = (getRandomId());
                                                                                string name = ItemName();
                                                                                int stock = ItemStock();
                                                                                double price = ItemPrice();
                                                                                double discount = ItemDiscount();
                                                                                Date ManufactureDate = ItemDate();
                                                                                Date ExpiryDate = ItemDate();
                                                                                string category = "meat";
                                                                                Fruits fruit = new Fruits(itemId, name, price, discount,ManufactureDate, ExpiryDate, "is Ripe", stock);
                                                                                item.AddItemToCategory(category, fruit);
                                                                                break;
                                                                            }
                                                                        case 4:
                                                                            {
                                                                                Console.WriteLine("Have a nice day!");
                                                                                categoryloop = false;
                                                                                break;
                                                                            }
                                                                        default:
                                                                            {
                                                                                Console.WriteLine("Invalid Input");
                                                                                break;
                                                                            }
                                                                    }


                                                                }
                                                                break;
                                                            }
                                                        case 2:
                                                            {
                                                                bool rloop = true;

                                                                while (rloop)
                                                                {
                                                                    Console.WriteLine("\n1 for Fruits");
                                                                    Console.WriteLine("2 for Drinks");
                                                                    Console.WriteLine("3 for Meat");
                                                                    Console.WriteLine("4 for Go back");

                                                                    Console.WriteLine("Choose an option ");
                                                                    int RemoveOpt=int.Parse(Console.ReadLine());

                                                                    switch(RemoveOpt)
                                                                    {
                                                                        case 1:
                                                                            {
                                                                                Console.WriteLine("Enter Item Id: ");
                                                                                string id=Console.ReadLine();
                                                                                item.RemoveItemFromCategory("fruits", id);

                                                                                break;
                                                                            }
                                                                        case 2:
                                                                            {
                                                                                Console.WriteLine("Enter Item Id: ");
                                                                                string id = Console.ReadLine();
                                                                                item.RemoveItemFromCategory("drinks", id);
                                                                                break;
                                                                            }
                                                                        case 3:
                                                                            {
                                                                                Console.WriteLine("Enter Item Id: ");
                                                                                string id = Console.ReadLine();
                                                                                item.RemoveItemFromCategory("meat", id);
                                                                                break;
                                                                            }
                                                                        case 4:
                                                                            {
                                                                                Console.WriteLine("Have a nice Day!");
                                                                                rloop = false;
                                                                                break;
                                                                            }
                                                                        default:
                                                                            {
                                                                                Console.WriteLine("Invalid Input");
                                                                                break;
                                                                            }
                                                                    }

                                                                }

                                                                break;
                                                            }
                                                        case 3:
                                                            {
                                                                bool dlopp=true;
                                                                while (dlopp)
                                                                {
                                                                    Console.WriteLine("\n1. for Fruits");
                                                                    Console.WriteLine("2. for Drinks");
                                                                    Console.WriteLine("3. for Meat");
                                                                    Console.WriteLine("4. for Display All Categories");
                                                                    Console.WriteLine("5. for Go back");

                                                                    Console.WriteLine("Chhose an option ");
                                                                    int RemoveOpt = int.Parse(Console.ReadLine());

                                                                    switch (RemoveOpt)
                                                                    {
                                                                        case 1:
                                                                            {
                                                                                item.DisplayItemsOfCategory(true,"fruits");

                                                                                break;
                                                                            }
                                                                        case 2:
                                                                            {
                                                                                item.DisplayItemsOfCategory(true, "drinks");

                                                                                break;
                                                                            }
                                                                        case 3:
                                                                            {
                                                                                item.DisplayItemsOfCategory(true, "meat");

                                                                                break;
                                                                            }
                                                                        case 4:
                                                                            {
                                                                                item.DisplayAllItemsByCategory(true);
                                                                                break;
                                                                            }
                                                                        case 5:
                                                                            {
                                                                                Console.WriteLine("Have a nice Day!");
                                                                                dlopp = false;
                                                                                break;
                                                                            }
                                                                        default:
                                                                            {
                                                                                Console.WriteLine("Invalid Input");
                                                                                break;
                                                                            }
                                                                    }

                                                                }

                                                                break;
                                                            }
                                                        case 4:
                                                            {
                                                                user.DisplayAllUserAccount();

                                                                break;
                                                            }
                                                      
                                                        case 5:
                                                            {

                                                                if (admin != null)
                                                                {
                                                                    user.DisplayAdminInfo(admin);
                                                                }
                                                                else
                                                                {
                                                                    Console.WriteLine("No admin found ");
                                                                }
                                                                break;
                                                            }
                                                        case 6:
                                                            {
                                                                // See taotal sales. 
                                                                user.DisplayAllOrders();
                                                                break;
                                                            }
                                                        case 7:
                                                            {
                                                                Console.WriteLine("Have a nice day!");
                                                                cloop = false;
                                                                break;
                                                            }

                                                        default:
                                                            {
                                                                Console.WriteLine("Invalid Input ");
                                                                break;
                                                            }
                                                    }

                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine($"Admin against Account Number: {accNumb} || Email Not Found ");
                                            }

                                            break;
                                        }
                                    case 3:
                                        {
                                            Console.WriteLine("Have a nice Day!");
                                            iloop = false;
                                            break;
                                        }
                                    default:
                                        {
                                            Console.WriteLine(" Invalid Input ");
                                            break;
                                        }
                                }

                            }

                            break;
                        }

                    case 2:
                        {
                            bool uloop = true;
                            while (uloop)
                            {
                                Console.WriteLine("1. for SignUp ");
                                Console.WriteLine("2. for Login ");
                                Console.WriteLine("3. for Go back ");

                                Console.WriteLine("Choose an option ");
                                int useropt = int.Parse(Console.ReadLine());
                                switch (useropt)
                                {
                                    case 1:
                                        {
                                            Console.WriteLine("Enter Account Number ");
                                            int accNumb = int.Parse(Console.ReadLine());
                                            Console.WriteLine(" Enter Name ");
                                            string name = Console.ReadLine();
                                            Console.WriteLine(" Enter Email ");
                                            string email = Console.ReadLine();
                                            string UserType = "user";

                                            LocalUser Localuser = new LocalUser(name, email);

                                            user.SignUp(UserType, accNumb, Localuser);

                                            break;
                                        }
                                    case 2:
                                        {
                                            Console.WriteLine("Enter Account Number ");
                                            int accNumb = int.Parse(Console.ReadLine());
                                            Console.WriteLine(" Enter Email ");
                                            string email = Console.ReadLine();

                                            if (user.Login(email, accNumb,"user"))
                                            {
                                                bool cloop = true;
                                                while (cloop)
                                                {
                                                    Console.WriteLine("\n1. for Add Items to Cart ");
                                                    Console.WriteLine("2. for Remove Items from cart ");
                                                    Console.WriteLine("3. for Display All Items ");
                                                    Console.WriteLine("4. for Display Cart Items ");
                                                    Console.WriteLine("5. for See Profile ");
                                                    Console.WriteLine("6. for Generate Bill ");
                                                    Console.WriteLine("7. for Go back ");

                                                    Console.WriteLine("Choose an option... ");
                                                    int opt = int.Parse(Console.ReadLine());

                                                    // this is user mode.

                                                    switch (opt)
                                                    {
                                                        case 1:
                                                            {
                                                                bool cartloop = true;

                                                                while (cartloop)
                                                                {
                                                                    Console.WriteLine("\n1 for Fruits");
                                                                    Console.WriteLine("2 for Drinks");
                                                                    Console.WriteLine("3 for Meat");
                                                                    Console.WriteLine("4 for Go back");

                                                                    Console.WriteLine("Choose an option ");
                                                                    int cartOpt = int.Parse(Console.ReadLine());

                                                                    switch (cartOpt)
                                                                    {
                                                                        case 1:
                                                                            {
                                                                                string name = ItemName();
                                                                                int quantity = ItemQuantity();
                                                                                user.AddItemToCart(accNumb, name,"fruits",_itemsByCategory, quantity);

                                                                                break;
                                                                            }
                                                                        case 2:
                                                                            {
                                                                                string name = ItemName();
                                                                                int quantity = ItemQuantity();
                                                                                user.AddItemToCart(accNumb, name, "drinks", _itemsByCategory, quantity);

                                                                                break;
                                                                            }
                                                                        case 3:
                                                                            {
                                                                                string name = ItemName();
                                                                                int quantity = ItemQuantity();
                                                                                user.AddItemToCart(accNumb, name, "meat", _itemsByCategory, quantity);
                                                                                break;
                                                                            }
                                                                        case 4:
                                                                            {
                                                                                Console.WriteLine("Have a nice Day!");
                                                                                cartloop = false;
                                                                                break;
                                                                            }
                                                                        default:
                                                                            {
                                                                                Console.WriteLine("Invalid Input");
                                                                                break;
                                                                            }
                                                                    }

                                                                }

                                                                break;
                                                            }
                                                        case 2:
                                                            {
                                                                string name= ItemName();
                                                                int quantity = ItemQuantity();

                                                                user.RemoveItemFromCart(accNumb, name, quantity);

                                                                break;
                                                            }
                                                        case 3:
                                                            {
                                                                bool dlopp = true;
                                                                while (dlopp)
                                                                {
                                                                    Console.WriteLine("\n1. for Fruits");
                                                                    Console.WriteLine("2. for Drinks");
                                                                    Console.WriteLine("3. for Meat");
                                                                    Console.WriteLine("4. for Display All Categories");
                                                                    Console.WriteLine("5. for Go back");

                                                                    Console.WriteLine("Chhose an option ");
                                                                    int RemoveOpt = int.Parse(Console.ReadLine());

                                                                    switch (RemoveOpt)
                                                                    {
                                                                        case 1:
                                                                            {
                                                                                item.DisplayItemsOfCategory(false, "fruits");

                                                                                break;
                                                                            }
                                                                        case 2:
                                                                            {
                                                                                item.DisplayItemsOfCategory(false, "drinks");

                                                                                break;
                                                                            }
                                                                        case 3:
                                                                            {
                                                                                item.DisplayItemsOfCategory(false, "meat");

                                                                                break;
                                                                            }
                                                                        case 4:
                                                                            {
                                                                                item.DisplayAllItemsByCategory(false);
                                                                                break;
                                                                            }
                                                                        case 5:
                                                                            {
                                                                                Console.WriteLine("SuccessFully GO back!");
                                                                                dlopp = false;
                                                                                break;
                                                                            }
                                                                        default:
                                                                            {
                                                                                Console.WriteLine("Invalid Input");
                                                                                break;
                                                                            }
                                                                    }

                                                                }

                                                                break;
                                                            }
                                                        case 4:
                                                            {
                                                                user.DisplayCartItems(accNumb);

                                                                break;
                                                            }
                                                        case 5:
                                                            {
                                                                user.DisplayUserAccount(accNumb);
                                                                break;
                                                            }
                                                        case 6:
                                                            {
                                                                user.GenerateUserBill(accNumb);
                                                                break;
                                                            }
                                                       
                                                        case 7:
                                                            {
                                                                Console.WriteLine("Successfully Loged Out ");
                                                                cloop = false;
                                                                break;
                                                            }
                                                        default:
                                                            {
                                                                break;
                                                            }
                                                    }

                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine($"User against Account Number: {accNumb} || Email Not Found ");
                                            }

                                            break;
                                        }
                                        case 3:
                                        {
                                            Console.WriteLine(" Thanks for shopping here ");
                                            uloop = false;
                                            break;
                                        }
                                        default:
                                        {
                                            Console.WriteLine("Invalid Input ");
                                            break;
                                        }
                                }
                            }
                            break;
                        }
                           
                                
                    case 3:
                        {
                            Console.WriteLine("Have a nice Day!");
                            oloop = false;
                            break;
                        }

                    default:
                    {
                            Console.WriteLine(" Invalid Input ");
                            break;
                    }
                }
            }

        }
    }
}

/*
  Console.WriteLine("1. for Buy an Item ");
                                                    Console.WriteLine("2. for Display All Items ");
                                                    Console.WriteLine("3. for Drop any Items ");
                                                    Console.WriteLine("4. for Bundles ");
                                                    Console.WriteLine("5. for Generate Receipt ");
                                                    Console.WriteLine("6. for See Profile ");
 
 */
