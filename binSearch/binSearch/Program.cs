using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace binSearch
{
    class MainClass
    {
        public static int Naive_search(int[] l, int target)
        {
            for (int i = 0; i < l.Length; i++)
            {
                if (l[i] == target)
                    return i;
            }
            return -1;
        }

        public static int Binary_search(int[] l, int target, object low = null, object high = null)
        {
            if (low == null)
                low = 0;
            if (high == null)
                high = l.Length - 1;

            if ((int)high < (int)low)
                return -1;

            int midpoint = (int)Math.Floor((decimal)((int)low + (int)high) / 2);

            if (l[midpoint] == target)
                return midpoint;
            else if (target < l[midpoint])
                return Binary_search(l, target, low, midpoint - 1);
            else
                return Binary_search(l, target, midpoint + 1, high); // target > midpoint
        }

        static void Main(string[] args)
        {
            var timer = new Stopwatch();

            int[] list = { 1, 3, 5, 12, 78, 90 };
            int target = 12;
            Console.WriteLine("Naive search output = {0}", Naive_search(list, target));
            Console.WriteLine("Binary search output = {0}", Binary_search(list, target));

            int len = 10000;
            var arr = new SortedSet<int>();

            do
            {
                arr.Add(new Random().Next(-3 * len, 3 *len));
              
            } while (arr.Count < len);

            int[] sorted = new int[len];
            arr.CopyTo(sorted);

            timer.Start();
            foreach (int i in sorted)
                Naive_search(sorted, i);
            timer.Stop();
            Console.WriteLine("\nNaive search time: {0:F10}ms", (double)(timer.ElapsedTicks / TimeSpan.TicksPerMillisecond) / len);

            timer.Start();
            foreach (int i in sorted)
                Binary_search(sorted, i);
            timer.Stop();
            Console.WriteLine("Binary search time: {0:F10}ms", (double)(timer.ElapsedTicks / TimeSpan.TicksPerMillisecond) / len);
        }
    }
}
