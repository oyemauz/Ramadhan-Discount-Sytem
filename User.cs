using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramadhan_Discount_System
{
    public class User
    {
        private string _name;
        private string _email;
        private int _userAccount__Number;
        private string _typeofUser;

        public User()
        {
            _name = string.Empty;
            _email = string.Empty;
            _userAccount__Number = -1;
            _typeofUser = string.Empty;
        }

        public string Name { get => _name; set => _name = value; }
        public string Email { get => _email; set => _email = value; }
        public int UserAccount__Number { get => _userAccount__Number; set => _userAccount__Number = value; }
        public string TypeofUser { get => _typeofUser; set => _typeofUser = value; }
    }
}
