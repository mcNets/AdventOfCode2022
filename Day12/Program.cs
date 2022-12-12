/*
 * - What is the fewest steps required to move from your current position to the location that should get the best signal?
 * 
 * Result exercise 1: 
 * 
 * - 
 * 
 * Result exercise 2: 
 */

using System.Collections.Immutable;
using System.ComponentModel;
using System.Drawing;
using System.Numerics;

Console.WriteLine("Advent of Code - Day 12\n");

Exercise.GetData();
Exercise.Solve();

static class Exercise
{
    public static List<string> Orders = new();
    
    public static int Rows;
    public static int Columns;
    public static Queue<int> RQueue = new Queue<int>();
    public static Queue<int> CQueue = new Queue<int>(); 
    public static int StartingRow = 0;
    public static int StartingCol = 0;
    public static int MoveCount = 0;

    public static void GetData()
    {
        Orders = File.ReadAllLines(@"..\..\..\data0.txt").ToList();
        Rows = Orders.Count;
        Columns = Orders[0].Length;
        Console.WriteLine($"Rows:{Rows}  Columns:{Columns}");
    }

    public static void Solve()
    {
        RQueue.Append( StartingRow );
        CQueue.Append( StartingCol );

    }
}
