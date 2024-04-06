using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramadhan_Discount_System
{
    public class Date
    {
        private int _day;
        private int _month;
        private int _year;

        public Date(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }

        public string GetDate(string format)
        {
            return $"{Day.ToString("00")}/{Month.ToString("00")}/{Year.ToString("0000")}";
        }

        public int Day { get => _day; set => _day = value; }
        public int Month { get => _month; set => _month = value; }
        public int Year { get => _year; set => _year = value; }
    }
}
