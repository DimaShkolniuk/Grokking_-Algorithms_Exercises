using System.ComponentModel.DataAnnotations;
using System.Net.WebSockets;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        int searchItem = 8;
        int[] testArray = [1,3,2,4,6,5,7,9,8,10];
        var result = string.Join(",", testArray);
        System.Console.WriteLine(result + " our search Item: " + searchItem);

        //4.1 Function Sum
        System.Console.WriteLine("4.1 Sum all numbers in array: " + Sum(testArray));
        System.Console.WriteLine("O(n)");

        //4.1 RecursiveSum
        System.Console.WriteLine("4.1 RecursiveSum all numbers in array: " + RecursiveSum(testArray));
        System.Console.WriteLine("O(n)");

        //4.2 RecursiveCount
        System.Console.WriteLine("4.2 RecursiveCount. Our array has: " + RecursiveCount(testArray) + " items");
        System.Console.WriteLine("O(n)");

        //4.3 RecursiveMax
        System.Console.WriteLine("4.3 Max item it is " + RecursiveMax(testArray));
        System.Console.WriteLine("O(n^2)");

        //4.4 RecursiveBinarySearch
        System.Console.WriteLine("4.4 I fined number " + RecursiveBinarySearch(testArray,searchItem) + " in array");
        System.Console.WriteLine("O(log n)");

        //4.8 
        System.Console.WriteLine(MultipleNumbersOfArray(testArray));
    }

    public static int Sum(int[] array)
    {
        int resultSum = 0;
        foreach (var item in array)
        {
            resultSum += item;
        }

        return resultSum;
    }

    public static int RecursiveSum(IEnumerable<int> list)
    {
        if(!list.Any()) return 0;

        return list.Take(1).First() + RecursiveSum(list.Skip(1));
    }

    public static int RecursiveCount(IEnumerable<int> list)
    {
        if(!list.Any()) return 0;

        return 1 + RecursiveCount(list.Skip(1));
    }

    public static int RecursiveMax(IEnumerable<int> list)
    {
        if(!list.Any()) throw new ArgumentException(nameof(list));
        if(list.Count() == 1) return list.First();
        if(list.Count() == 2) return list.First() > list.Skip(1).Take(1).First() ? list.First() : list.Skip(1).Take(1).First(); 

        var sub_max = RecursiveMax(list.Skip(1));
        return list.First() > sub_max ? list.First() : sub_max;
    }

    public static int RecursiveBinarySearch(IEnumerable<int> list, int searchItem)
    {   
        if(!list.Any()) return -1;
        int midIndex = list.Count() / 2;
        int midItem = list.ElementAt(midIndex);

        if(searchItem == midItem) return midItem;
        if(searchItem < midItem) return RecursiveBinarySearch(list.Take(midIndex), searchItem);
        if(searchItem > midItem) return RecursiveBinarySearch(list.Skip(midIndex + 1), searchItem);

        return -1;
    } 

    public static List<int> MultipleNumbersOfArray(IEnumerable<int> list)
    {
    var newList = new List<int>();
    for(int i = 0; i < list.Count(); i++)
    {
        int multiplier = i + 1;
        foreach (int item in list)
        {
            newList.Add(item * multiplier);
        }
    }
    return newList;
    }
}