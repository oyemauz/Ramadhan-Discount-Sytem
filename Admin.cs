using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramadhan_Discount_System
{
    public class Admin:User
    {
        public Admin(string name,string email) 
        {
            Name = name;
            Email = email;
        }

        public void DisplayAdmin()
        {
            if (!IsAdmin())
            {
                Console.WriteLine("\nAccount Number: " + UserAccount__Number);
                Console.WriteLine("Name: " + Name);
                Console.WriteLine("Email: " + Email);
                Console.WriteLine("Type = Admin ");
                Console.WriteLine();

            }
            else
            {
                Console.WriteLine("There's no any Admin registered ");
            }
        }

        public bool IsAdmin()
        { 
            if(UserAccount__Number == -1)
            {
                return true;
            }
            return false;
        }
    }
}
