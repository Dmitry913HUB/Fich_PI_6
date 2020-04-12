using System;
using System.ComponentModel;

namespace Fich
{
    class Program
    {
        const int N = 10;
        static void Main(string[] args)
        {
            BindingList<CoTrigonometric> bList = new BindingList<CoTrigonometric>();

            CoTrigonometric ct;
            Random x = new Random();
            for (int i = 0; i < N; i++)
            {
                ct = new CoTrigonometric(x.Next(10), x.Next(10));
                bList.Add(ct);
            }
            //ct = new CoTrigonometric(1, 1);
            //bList.Add(ct);

            foreach (CoTrigonometric c in bList)
            {
                Console.WriteLine(c.abs + " " + c.fi);
            }
            Console.WriteLine();

            //------------------input data

            double eps = 0.1;
            double abs = 1;
            double fi = 1;
            ct = new CoTrigonometric(1, 1);

            //------------------sort

            ProcessSortSearch.SortAsc(bList);

            foreach (CoTrigonometric c in bList)
            {
                Console.WriteLine(c.abs + " " + c.fi);
            }
            Console.WriteLine();

            //------------SearchLinear

            if (ProcessSortSearch.SearchLinear(bList, abs, fi, eps))
            {
                Console.WriteLine("YES");
            }
            else { Console.WriteLine("NO"); }

            if (ProcessSortSearch.SearchLinear(bList, ct, eps))
            {
                Console.WriteLine("YES");
            }
            else { Console.WriteLine("NO"); }

            //------------SearchBinary

            int length = bList.Count;

            if (ProcessSortSearch.SearchBinary(bList, abs, fi, eps, 0, length - 1)) 
            {
                Console.WriteLine("YES");
            }
            else { Console.WriteLine("NO"); }

            if (ProcessSortSearch.SearchBinary(bList, ct, eps, 0, length - 1))
            {
                Console.WriteLine("YES");
            }
            else { Console.WriteLine("NO"); }

        }
    }
}
