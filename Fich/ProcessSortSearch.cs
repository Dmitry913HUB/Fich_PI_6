using System;
using System.ComponentModel;

namespace Fich
{
    internal class ProcessSortSearch
    {
        const int N = 10;

        //------------SortAsc
        internal static void SortAsc(BindingList<CoTrigonometric> bList) 
        {
            CoTrigonometric ct;
            for (int j = 0; j < N; j++)
            {
                for (int i = 0; i < N - 1; i++) 
                {
                    if (bList[i].abs > bList[i + 1].abs)
                    {
                        ct = bList[i];
                        bList[i] = bList[i + 1];
                        bList[i + 1] = ct;
                    }

                }

                for (int i = 0; i < N - 1; i++) 
                {
                    if (bList[i].abs == bList[i + 1].abs && bList[i].fi > bList[i + 1].fi)
                    {
                        ct = bList[i];
                        bList[i] = bList[i + 1];
                        bList[i + 1] = ct;
                    }

                }

            }

        }
        //------------SearchLinear
        internal static bool SearchLinear(BindingList<CoTrigonometric> bList, double abs, double fi, double eps) 
        {
            foreach (CoTrigonometric c in bList)
            {
                if (Math.Abs(c.abs - abs) < eps && Math.Abs(c.fi - fi) < eps)
                {
                    return true;
                }
            }
            return false;
        }

        internal static bool SearchLinear(BindingList<CoTrigonometric> bList, CoTrigonometric ct , double eps)
        {
            foreach (CoTrigonometric c in bList)
            {
                if (Math.Abs(c.abs - ct.abs) < eps && Math.Abs(c.fi - ct.fi) < eps)
                {
                    return true;
                }
            }
            return false;
        }
        //------------------SearchBinary

        internal static bool SearchBinary(BindingList<CoTrigonometric> bList, double abs, double fi, double eps, int l, int r) 
        {

            if (r >= l)
            {
                int mid = l + (r - l) / 2;

                if (Math.Abs(bList[mid].abs - abs) < eps && Math.Abs(bList[mid].fi - fi) < eps)
                    return true;

                if (bList[mid].abs > abs || bList[mid].fi > fi)
                    return SearchBinary(bList, abs, fi, eps, l, mid - 1);

                return SearchBinary(bList, abs, fi, eps, mid + 1, r);
            }

            return false;
        }

        internal static bool SearchBinary(BindingList<CoTrigonometric> bList, CoTrigonometric ct, double eps, int l, int r)
        {

            if (r >= l)
            {
                int mid = l + (r - l) / 2;

                if (Math.Abs(bList[mid].abs - ct.abs) < eps && Math.Abs(bList[mid].fi - ct.fi) < eps)
                    return true;

                if (bList[mid].abs > ct.abs || bList[mid].fi > ct.fi)
                    return SearchBinary(bList, ct, eps, l, mid - 1);

                return SearchBinary(bList, ct, eps, mid + 1, r);
            }

            return false;
        }
    }
}
