/*
 * How many positions does the tail of the rope visit at least once?
 * 
 * Result exercise 1: 5902
 * 
 * Simulate your complete series of motions on a larger rope with ten knots. 
 * How many positions does the tail of the rope visit at least once?
 * 
 * Result exercise 2: 2445
 */

using System.Net.NetworkInformation;

Console.WriteLine("Advent of Code - Day 8");

Exercise.GetData(@"..\..\..\data.txt");
Console.WriteLine($"Result exercise 1: {Exercise.Result(1)}");
Console.WriteLine($"Result exercise 2: {Exercise.Result(2)}");


static class Exercise
{
    public static List<string> Orders = new();
    public static int NumberOfLines => Orders.Count;
    public static List<(int X, int Y)> PosVisited = new();
    public static (int X, int Y)[] Knot = new (int X, int Y)[10];
    public static int MaxKnots = 0;

    public static void GetData(string filePath)
    {
        Orders.Clear();
        Orders = File.ReadAllLines(filePath).ToList();
    }

    public static int Result(int exercise)
    {
        MaxKnots = (exercise == 1) ? 2 : 10;
        PosVisited.Clear();
        for (int x = 0; x < Knot.Length; Knot[x++] = new(0, 0)) ;
        PosVisited.Add(Knot[MaxKnots - 1]);

        ExecuteOrders();

        return PosVisited.Count;
    }

    private static void ExecuteOrders()
    {
        foreach (var order in Orders)
        {
            var param = order.Split(' ');
            string direction = param[0];
            int steps = int.Parse(param[1]);

            (direction switch
            {
                "R" => new Action(() => MoveHead(steps, 1, 0)),
                "L" => new Action(() => MoveHead(steps, -1, 0)),
                "U" => new Action(() => MoveHead(steps, 0, -1)),
                "D" => new Action(() => MoveHead(steps, 0, 1)),
                _ => throw new Exception($"Unknown movment {direction}")
            })();
        }
    }

    public static void MoveHead(int steps, int deltaX, int deltaY)
    {
        for (int i = 0; i < steps; i++)
        {
            Knot[0].X += deltaX;
            Knot[0].Y += deltaY;
            MoveTail();
        }
    }

    public static void MoveTail()
    {
        for (int x = 0; x < MaxKnots - 1; x++)
        {
            if (Math.Abs(Knot[x].X - Knot[x + 1].X) <= 1 && Math.Abs(Knot[x].Y - Knot[x + 1].Y) <= 1)
            {
                return;
            }
            Knot[x + 1].X += Math.Sign(Knot[x].X - Knot[x + 1].X);
            Knot[x + 1].Y += Math.Sign(Knot[x].Y - Knot[x + 1].Y);
        }

        if (PosVisited.Contains(Knot[MaxKnots - 1]) == false)
        {
            PosVisited.Add(Knot[MaxKnots - 1]);
        }
    }
}

