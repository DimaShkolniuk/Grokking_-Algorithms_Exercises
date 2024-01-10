using System.Net.WebSockets;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] testArray = [1,3,2,4,6,5,7,9,8,10];
        var result = string.Join(",", testArray);
        System.Console.WriteLine(result);

        //4.1 Function Sum
        System.Console.WriteLine("4.1 Sum all numbers in array: " + Sum(testArray));
        System.Console.WriteLine("O(n)");

        //4.1 RecursiveSum
        System.Console.WriteLine("4.1 RecursiveSum all numbers in array: " + RecursiveSum(testArray));
        System.Console.WriteLine("O(n)");

        //4.2 RecursiveCount
        System.Console.WriteLine("4.2 RecursiveCount. Our array has: " + RecursiveCount(testArray) + " items");
        System.Console.WriteLine("O(n)");
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
        if(list.Count() == 0) return list.First();
    }
}