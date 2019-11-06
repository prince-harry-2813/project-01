using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part2
{
    class Program
    {
        static class RandomNumbers
        {
           //
        }
        
        static void Main(string[] args)
        {
            Random r = new Random(DateTime.Now.Millisecond);
            Int32 [] arrayA = new Int32 [20];
            Int32 [] arrayB = new Int32 [20];
            Int32 [] arrayC = new Int32 [20];

            for(int i = 0; i < 20 ; i++)
            {
                arrayA[i] = r.Next(18, 123);
                arrayB[i] = r.Next(18, 123);
                arrayC[i] = arrayA[i] - arrayB[i];
                if (arrayC[i] < 0)
                {
                    arrayC[i] = arrayC[i] * -1;
                }

                
            }

            for (int i = 0; i < 20; i++)
            {
                Console.Write("{0 , -5 }", arrayA[i]);
            }

            Console.WriteLine();

            for (int i = 0; i < 20; i++)
            {
                Console.Write("{0 , -5 }", arrayB[i]);
            }

            Console.WriteLine();

            for (int i = 0; i < 20; i++)
            {
                Console.Write("{0,-5}", arrayC[i]  );
            }

            Console.WriteLine();
        }
    }
}
