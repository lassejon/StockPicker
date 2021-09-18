using System;
using System.Collections.Generic;

namespace StockPicker
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new List<int> {17, 3, 6, 9, 15, 8, 6, 1, 10};
            PickStocks(test).ForEach(Console.WriteLine);
            Console.WriteLine(PickStocks(test).ToString());
        }

        static List<int> PickStocks(List<int> stocks)
        {
            int maxDifference = Int32.MinValue;
            int minIndex = 0;
            int maxIndex = 0;

            for (int i = 0; i < stocks.Count; i++)
            {
                for (int j = i + 1; j < stocks.Count; j++)
                {
                    int difference = stocks[j] - stocks[i];

                    if (difference > maxDifference)
                    {
                        maxDifference = difference;
                        maxIndex = j;
                        minIndex = i;
                    }
                }
            }

            return new List<int> { minIndex, maxIndex };
        }
    }
}