using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5780_02_6650_6671
{
    public class HostingUnit : IComparable
    {
        public int StSerialKey { get; set; }
        public int HostingUnitKey { get; set; }
        public Date[,] Diary { get; set; } = new Date[12,31];

        public HostingUnit()
        {
            //for (int i = 0; i < 12; i ++ )
            //    for (int j = 0; j < 31; j++)
            //     Diary[i,j].Avilibility = false ;
        }
        public override string ToString()
        {
            return "StSerialKey: " + StSerialKey +
                " HostingUnitKey: " + HostingUnitKey +
                " Diary: " + Diary;
        }
        
        public bool ApproveRequest(GuestRequest guestReq)
        {
            int temp = 0;
            int j = guestReq.EnteryDate.Day;
            int i = guestReq.EnteryDate.Month;
            int duration = guestReq.OrderDuration(guestReq.ReleaseDate, guestReq.EnteryDate);
            
            for (; i < 12 && temp < duration; i++) //checking possibility loop
            {
                for (; j < 31 && temp < duration; j++, temp++)
                {
                    if (Diary[i, j].Avilibility) // in case that terhe is other hosting on this dates
                    {
                        Console.WriteLine("the request denied");
                        guestReq.IsApproved = false;
                        return false ;
                    }
                    if (j == 30)
                    {
                        i++;
                        j = -1;

                    }
                }
            }
            guestReq.IsApproved = true;
            return true; 
        }

        public int GetAnnualBusyDays()
        {
            int busyDays = 0;
            for (int i = 0; i < 12; i++)
                for (int j = 0; j < 31; j++)
                    busyDays += (Diary[i, j].Avilibility) ? 1 : 0;
            return busyDays;
        }
        
        public float GetAnnualBusyPrecentege()
        {
            return (GetAnnualBusyDays() / 372) * 100;
        }
        public int CompareTo(HostingUnit other)
        {
            int tonnage = this.GetAnnualBusyDays() - other.GetAnnualBusyDays();
            if (tonnage > 0)
                return -1;
            if (tonnage < 0)
                return 1;
            return 0;
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
