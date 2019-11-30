using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5780_02_6650_6671
{

    public struct Date
    {
        public int Day;
        public int Month;
        public int Year;
        public bool Avilibility;
       
        public Date( Date date)
        {
            this.Day = date.Day;
            this.Month = date.Month;
            this.Year = date.Year;
            this.Avilibility = date.Avilibility;
        }

        public Date(int day , int month , int year)
        {
            this.Day = day;
            this.Month = month;
            this.Year = year;
            this.Avilibility = false;
        }
    }
    public class GuestRequest
    {
        public Date  EnteryDate { get; set; }
        public Date ReleaseDate { get; set; }
        public bool IsApproved { get; set; }
        public int Duration { get; set; }

        public override string ToString()
        {
            return "Entery Date: " + EnteryDate + 
                " ReleaseDate: " + ReleaseDate +
                " IsApproved: " + IsApproved;
        }
        
        public int OrderDuration(Date enteyDate , Date releaseDate)
        {
            int daysInYear = (releaseDate.Year - enteyDate.Year) * 372; 
            int daysInMonth = (ReleaseDate.Month - enteyDate.Month) * 31;
            int daysInDays = (releaseDate.Day - enteyDate.Day);
            return daysInYear + daysInMonth + daysInDays; 
        }
        
    }
}
