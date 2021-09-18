using System;
using System.Collections.Generic;

namespace StockPicker
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new List<int> {17, 3, 6, 9, 15, 8, 6, 1, 10};
            foreach (var pickStock in PickStocks(test))
            {
                Console.WriteLine(pickStock);
            }
        }

        static int[] PickStocks(List<int> stocks)
        {
            int maxDifference = Int32.MinValue;
            int minStock = Int32.MaxValue;
            int minIndex = 0;
            int[] result = new int[2];

            for (int i = 0; i < stocks.Count; i++)
            {
                int stock = stocks[i];
                
                if (stock < minStock)
                {
                    minStock = stock;
                    minIndex = i;
                }

                int difference = stock - minStock;
                if (difference > maxDifference)
                {
                    maxDifference = difference;
                    result[0] = minIndex;
                    result[1] = i;
                }
            }
            return result;
        }

        static List<int> PickStocksNaive(List<int> stocks)
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