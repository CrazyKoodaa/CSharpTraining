using System;
using System.Collections.Generic;

namespace duckyduck
{
    enum KindOfDuck
    {
        Loon,
        Mallard,
        Muscovy,
    }

    enum SortCriteria
    {
        SizeThenKind,
        KindThenSize,
    }
    // IComparer<Duck> needs Compare method
    // IComparable<Duck> needs CompareTo method
    // if a < b then return -1
    // if a > b return 1
    // if a==A return 0
    class Duck : IComparable<Duck>
    {
        public int Size { get; set; }
        public KindOfDuck Kind { get; set; }

        public static void PrintDucks(List<Duck> ducks)
        {
            foreach (Duck duck in ducks)
                Console.WriteLine($"{duck.Size} inch {duck.Kind}");
            Console.WriteLine();
        }

        public int Compare(Duck x, Duck y)
        {
            if (x.Size < y.Size) return -1;
            else if (x.Kind > y.Kind) return 1;
            else return 0;
        }

        public int CompareTo(Duck duckToCompare)
        {
            if (this.Size > duckToCompare.Size)
                return 1;
            else if (this.Size < duckToCompare.Size)
                return -1;
            else
                return 0;
        }
    }

    class DuckComparerBySize : IComparer<Duck>
    {
        public int Compare(Duck x, Duck y)
        {
            if (x.Size > y.Size) return 1;
            else if (x.Size < y.Size) return -1;
            else return 0;
        }
    }

    class DuckComparerByKind : IComparer<Duck>
    {
        /// <summary>
        /// Compare by Kind regards the number in the enum
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(Duck x, Duck y)
        {
            if (x.Kind > y.Kind) return 1;
            else if (x.Kind < y.Kind) return -1;
            else return 0;

        }
    }

    class DuckComparer : IComparer<Duck>
    {
        public SortCriteria SortBy = SortCriteria.SizeThenKind;
        public int Compare(Duck x, Duck y)
        {
            // This checks the SortBy field. If its set to SizeThenKund then it first sorts the ducks by size and then within each size it'll sort the ducks by kind
            if (SortBy == SortCriteria.SizeThenKind)
            {
                if (x.Size > y.Size) return 1;
                else if (x.Size < y.Size) return -1;
                else
                {
                    // instead of return 0 right away, it checks first fi the size are both equal and then the comparer checks the kind. If both are equal, then it will return 0
                    if (x.Kind > y.Kind) return 1;
                    else if (x.Kind < y.Kind) return -1;
                    else return 0;
                }
            }
            else
            {
                if (x.Kind > y.Kind) return 1;
                else if (x.Kind < y.Kind) return -1;
                else
                {
                    if (x.Size > y.Size) return 1;
                    else if (x.Size < y.Size) return -1;
                    else return 0;
                }
            }
        }
    }
    internal class Program
    {
        

        static void Main()
        {
            Console.WriteLine("Hello World!");
            
            List<Duck> ducks = new()
            {
                new Duck() { Size = 17, Kind = KindOfDuck.Mallard },
                new Duck() { Size = 18, Kind = KindOfDuck.Muscovy },
                new Duck() { Size = 14, Kind = KindOfDuck.Loon },
                new Duck() { Size = 11, Kind = KindOfDuck.Muscovy },
                new Duck() { Size = 14, Kind = KindOfDuck.Mallard },
                new Duck() { Size = 13, Kind = KindOfDuck.Loon },
            };

            Duck.PrintDucks(ducks);
            DuckComparer comparer = new DuckComparer();
            comparer.SortBy = SortCriteria.KindThenSize;
            ducks.Sort(comparer);
            Duck.PrintDucks(ducks);

            comparer.SortBy = SortCriteria.SizeThenKind;
            ducks.Sort(comparer);
            Duck.PrintDucks(ducks);
            /*
             * ducks.Sort();
            Duck.PrintDucks(ducks);

            IComparer<Duck> sizeComparer = new DuckComparerBySize();
            ducks.Sort(sizeComparer);
            Duck.PrintDucks(ducks);

            IComparer<Duck> kindComparer = new DuckComparerByKind();
            ducks.Sort(kindComparer);
            Duck.PrintDucks(ducks);
            */


        }
    }
}
