using Ramadhan_Discount_System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ramadhan_Discount_System
{
    public class UserDirectory
    {
        private bool isAdminRegistered = false;
        private Admin adminUser;
        private Dictionary<int, User> _localUserAccounts;
       // private Dictionary<string, User> _adminAccount;

        public UserDirectory()
        {
            _localUserAccounts = new Dictionary<int, User>();
          //  _adminAccount = new Dictionary<string, User>();
        }

        public bool SignUp(string usertype,int accountNumb,User user)
        {
            if (usertype == "user")
            {
               // LocalUser localuser= new LocalUser();
                user.TypeofUser = usertype;
                user.UserAccount__Number = accountNumb;

                if (IsValidEmail(user.Email)&& IsValidUserAccountNumber(accountNumb))
                {
                    _localUserAccounts[user.UserAccount__Number] = user; // Add user to dictionary
                    Console.WriteLine($"Successfully registered user against Account Number: {user.UserAccount__Number}");
                    return true;
                }
                else
                {
                    Console.WriteLine("Email format is incorrect or Account Number Already Exist ");
                    return false;
                }
            }

            else if (usertype == "admin")
            {
                if (!isAdminRegistered)
                {
                    // Assuming Admin is the user type for administrators
                    user.TypeofUser = usertype;
                    user.UserAccount__Number = accountNumb;

                    if (IsValidEmail(user.Email))
                    {
                        adminUser = user as Admin;
                        isAdminRegistered = true;
                        Console.WriteLine($"Successfully registered admin against Account Number: {user.UserAccount__Number}");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Email format is incorrect");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("Admin are already registered");
                    return false;
                }
            }

            else
            {
                Console.WriteLine(" Invalid Type of User ");
            }
            return false;
        }

        public bool IsValidUserAccountNumber(int accountNumber)
        {
            return !_localUserAccounts.ContainsKey(accountNumber);
        }

        public User GetUserByAccountNumber(int accountNumb)
        {
            if (_localUserAccounts.ContainsKey(accountNumb))
            {
                return _localUserAccounts[accountNumb]; // Return the user associated with the account number
            }
            else
            {
                Console.WriteLine($"User with Account Number {accountNumb} not found");
                return null;
            }
        }


        // Method to login a user

        public bool Login(string email, int userAccountNumber,string type)
        {
            if (type == "user")
            {
                // Check if the provided email and user account number match any user or admin records
                foreach (var user in _localUserAccounts.Values)
                {
                    if (user.Email == email && user.UserAccount__Number == userAccountNumber)
                    {
                        Console.WriteLine($"User with email '{email}' logged in successfully!");
                        return true; // user Login successful
                    }
                    else
                    {
                        Console.WriteLine($"User against Account Number: {userAccountNumber} Not Found ");
                        return false;
                    }
                }
            }

            else if (type == "admin")
            {
                // Check if the provided credentials belong to the admin
                if (adminUser != null && adminUser.Email == email && adminUser.UserAccount__Number == userAccountNumber)
                {
                    Console.WriteLine($"Admin with email '{email}' logged in successfully!");
                    return true; // Admin login successful
                }
                else
                {
                    Console.WriteLine($"Admin against Account Number: {userAccountNumber} Not Found ");
                    return false;
                }
            }
            else
            {
            // If no matching user or admin found, login fails
            Console.WriteLine("Invalid email or user account number. Login failed.");
            return false;
            }
         return false;
        }

        public Items CheckOutItems(Dictionary<string, List<Items>> itemsByCategory, string c, string name)
        {
            if (itemsByCategory.ContainsKey(c))
            {
                foreach (var item in itemsByCategory[c])
                {
                    if (item.ItemName.ToLower() == name.ToLower())
                    {
                        return item;
                    }
                }
            }
            return null;
        }

        public Items CheckOutOrderItems( List <Items> items, string name)
        {
            if (items != null)
            {
                foreach (var item in items)
                {
                    if (item.ItemName.ToLower() == name.ToLower())
                    {
                        return item;
                    }
                }
            }
            return null;
        }

        public void AddItemToCart(int accountNumber, string name, string c, Dictionary<string, List<Items>> itemsByCategory, int quantity)
        {
            // Retrieve the user by account number
            User user = GetUserByAccountNumber(accountNumber);
            // Check if the user exists
            if (user != null)
            {
                // Check if the user is a local user
                if (user is LocalUser localUser && localUser != null)
                {
                    Items item = CheckOutItems(itemsByCategory, c, name);
                    // Check if the item is found
                    if (item != null)
                    {
                        // Check if the quantity is valid (positive)
                        if (quantity > 0)
                        {
                            // Check if there's enough stock available
                            if (item.Stock >= quantity)
                            {                                
                                  localUser.AddItemToOrder(item,quantity);

                                // Deduct the quantity ordered from the item's stock
                                item.Stock -= quantity;

                                Console.WriteLine($"{quantity} '{item.ItemName}' ordered successfully for user with account number '{accountNumber}'");
                            }
                            else
                            {
                                Console.WriteLine($"Not enough stock available for '{item.ItemName}'. Available stock: {item.Stock}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Quantity should be a positive number.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Item not found in the specified category.");
                    }
                }
                else
                {
                    Console.WriteLine("Only local users can order items.");
                }
            }
            else
            {
                Console.WriteLine($"User with account number '{accountNumber}' not found.");
            }
        }


        public void RemoveItemFromCart(int accountNumber, string ItemName, int quantity)
        {
            // Retrieve the user by account number
            User user = GetUserByAccountNumber(accountNumber);

            if (user != null && user is LocalUser localUser)
            {
                // Check if quantity is valid
                if (quantity <= 0)
                {
                    Console.WriteLine("Invalid quantity. Quantity should be a positive number.");
                    return;
                }

                Items item = CheckOutOrderItems(localUser.OrderItems.Keys.ToList(), ItemName);

                // Check if the item exists in the user's order
                if (item != null)
                {
                    if (localUser.OrderItems.ContainsKey(item))
                    {
                        // Check if the requested quantity is less than or equal to the quantity of the item in the user's order
                        int itemQuantityInOrder = localUser.OrderItems[item];
                        if (quantity <= itemQuantityInOrder)
                        {
                            // Decrease the quantity of the item in the order
                            localUser.OrderItems[item] -= quantity;

                            // If the quantity becomes zero, remove the item from the order
                            if (localUser.OrderItems[item] <= 0)
                            {
                                localUser.OrderItems.Remove(item);
                            }

                            // Adjust the stock of the removed items
                            item.Stock += quantity;

                            Console.WriteLine($"{quantity} '{item.ItemName}' removed from the cart successfully for user with account number '{accountNumber}'");
                        }
                        else
                        {
                            Console.WriteLine($"Requested quantity exceeds the available quantity in the cart for '{item.ItemName}'.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Item '{item.ItemName}' not found in the user's cart.");
                    }
                }
                else
                {
                    Console.WriteLine($"Item '{ItemName}' not found in the user's cart.");
                }
            }
            else
            {
                Console.WriteLine($"User with account number '{accountNumber}' not found or is not a local user.");
            }
        }


        public void DisplayUserAccount(int accountNumber)
        {
            if (_localUserAccounts.Count > 0 &&_localUserAccounts.ContainsKey(accountNumber))
            {
                var i = _localUserAccounts[accountNumber];
               // {
                    Console.WriteLine("\nAccount Number: " + i.UserAccount__Number);
                    Console.WriteLine("Name: " + i.Name);
                    Console.WriteLine("Email: " + i.Email);
                    Console.WriteLine();
               // }
            }
            else
            {
                Console.WriteLine("No user Found against this Account Number: "+accountNumber);
            }
        }

        public void DisplayAdminInfo(Admin admin)
        {
            if (isAdminRegistered)
            {
                admin.DisplayAdmin();
            }
            else
            {
                Console.WriteLine("No admin Registered ");
            }
        }
        public void DisplayAllUserAccount()
        {
            if (_localUserAccounts.Count > 0)
            {
                foreach (var account in _localUserAccounts.Values)
                {
                    Console.WriteLine("\nAccount Number: " + account.UserAccount__Number);
                    Console.WriteLine("Name: " + account.Name);
                    Console.WriteLine("Email: " + account.Email);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No User Found");
            }
        }

            public void DisplayCartItems(int accountNumber)
            {
                User user = GetUserByAccountNumber(accountNumber);

                if (user != null)
                {
                    // Check if the user is a local user
                    if (user is LocalUser localUser && localUser != null)
                    {
                    localUser.DisplayAllOrderItems();
                    
                    }
                }
            }

        public void GenerateUserBill(int accountNumber)
        {
            User user = GetUserByAccountNumber(accountNumber);

            if (user != null)
            {
                // Check if the user is a local user
                if (user is LocalUser localUser && localUser != null)
                {
                 //       Console.WriteLine("\n             CASH    RECEIPT         ");
                        Console.WriteLine("\n\n        RAMADHAN DISCOUNT SYSTEM     ");
                        Console.WriteLine("           johar town lahore          ");
                        Console.WriteLine("            +92 111 222 333            ");
                        Console.WriteLine();
                        Console.WriteLine("{0,-20} {1,-50}", "Cashier: Muaz", "Customer Name: " + user.Name);

                    //  Console.WriteLine("{0,-20} {1,-30}", "Email:muaz@example.com", "Email:ali@example.com");


                    Console.WriteLine("___________________________________________________");
                        Console.WriteLine();
                        localUser.GenerateItemBill();

                }
            }
        }

        // public void DisplayAllOrderItems()
        // {

        // }

        static bool IsValidEmail(string email)
        {
            if (email == null)
            {
                return false; // Return false if the email is null
            }
            // Regular expression pattern for validating email format
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            // Create Regex object
            Regex regex = new Regex(pattern);

            // Check if email matches the pattern
            return regex.IsMatch(email);
        }

        public void DisplayAllOrders()
        {
            foreach (int accountNumber in _localUserAccounts.Keys)
            {
                Console.WriteLine($"Account Number: {accountNumber}");
                Console.WriteLine("Orders:");

                if (_localUserAccounts.TryGetValue(accountNumber, out User user) && user is LocalUser localUser)
                {
                    localUser.DisplayAllOrderItems();
                }
                else
                {
                    Console.WriteLine("No orders found for this account number.");
                }

                Console.WriteLine(); // Add an empty line for separation
            }
        }
    }

}

/*
            else if (usertype == "admin")
{
    Admin admin = new Admin();
    admin.GetType = usertype;
    localuser.UserAccount__Number = accountNumb;

    if (IsValidEmail(localuser.Email))
    {
        _localUserAccounts[localuser.UserAccount__Number] = localuser; // Add user to dictionary
        Console.WriteLine($"Successfully registered user against Account Number: {localuser.UserAccount__Number}");
        return true;
    }
    else
    {
        Console.WriteLine("Email format is incorrect");
        return false;
    }
}
*/
