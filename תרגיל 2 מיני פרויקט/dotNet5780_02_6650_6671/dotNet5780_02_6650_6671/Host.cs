using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5780_02_6650_6671
{
    class Host : IEnumerable<Host> 
    {
        public int HostKey { get; set; }
        public List<HostingUnit> HostingUnitCollection { get; set; }

        public Host(int hostid, int numberOfUnits)
        {
            for (int n = 0; n < numberOfUnits; n++)
            {
                HostingUnitCollection.Add(new HostingUnit());
                for (int i = 0; i < 12; i++)
                {
                    for (int j = 0; j < 31; j++)
                    {
                        HostingUnitCollection[n].Diary[i, j].Avilibility = false; 
                    }
                }
            }
        }

        /// <summary>
        /// for arie to solve to much for me right now 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.ToString();
        }

        /// <summary>
        /// gets the guest request and return the hosting unit key that avilable for hosting 
        /// or -1 n case there isnt any 
        /// </summary>
        /// <param name="guestReq"></param>
        /// <returns></returns>
        private long SubmitRequest(GuestRequest guestReq)
        {
            foreach (HostingUnit units in HostingUnitCollection)
            {
                
                if (units.ApproveRequest(guestReq))
                         return units.HostingUnitKey;
            }

            return -1;
        }

        /// <summary>
        /// gets sum of occupied dates in all of the collection
        /// </summary>
        /// <returns></returns>
        public int GetHostAnnualBusyDays()
        {
            int  sumOfAnuualOccupiedBeds = 0;
            
            foreach(HostingUnit units in HostingUnitCollection)
            {
                sumOfAnuualOccupiedBeds += units.GetAnnualBusyDays();
            }

            return sumOfAnuualOccupiedBeds;
        }

        /// <summary>
        /// sorting the list according to the amount of busy days 
        /// </summary>
        public void SortUnits()
        {
            HostingUnitCollection.Sort();
        }

        public bool AssignRequests(params GuestRequest [] requestlist)
        {
            bool deniedRequest = true;
            long [] approvalArray = new long[requestlist.Length];
            for (int  i = 0; i < requestlist.Length; i++)
            {
                approvalArray[i] = SubmitRequest(requestlist[i]);
                if (approvalArray[i] == -1)
                    deniedRequest = false; 
            }

            return deniedRequest;
        }

        ///todo:
        ///iplement indexer for arie im not familiar with that 

        IEnumerator<Host> IEnumerable<Host>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
