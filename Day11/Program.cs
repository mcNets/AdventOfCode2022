/*
 * Figure out which monkeys to chase by counting how many items they inspect over 20 rounds. 
 * What is the level of monkey business after 20 rounds of stuff-slinging simian shenanigans?
 * 
 * Result exercise 1: 113232
 * 
 * What eight capital letters appear on your CRT?
 * 
 * Result exercise 2: 2713310158
 */

//using Day11;

//ClassDay11 c = new ClassDay11();
//ClassDay11.Solve();

using System.Numerics;

Console.WriteLine("Advent of Code - Day 11\n");

Exercise.GetData();
Exercise.Execute(20, 1);
Console.WriteLine($"Level of monkey bussines 20 rounds: {Exercise.LevelOfMonkeyBussines}\n");

Exercise.GetData();
Exercise.Execute(10000, 2);
Console.WriteLine($"Level of monkey bussines 10000 rounds: {Exercise.LevelOfMonkeyBussines}\n");


static class Exercise
{
    public static List<string> Orders = new();
    public static long LevelOfMonkeyBussines = 0;
    public static List<Monkey> Monkeys = new();
    public static BigInteger ProductOfDivisors = 0;


    public static void GetData()
    {
        Orders = File.ReadAllLines(@"..\..\..\data0.txt").ToList();

        Monkeys.Clear();

        int index = 0;
        do
        {
            Monkey m = new Monkey();
            m.Items = Orders[index + 1].Split(':')[1].Split(',').ToList();
            m.Operation = Orders[index + 2].Split("=")[1].Trim();
            m.Test = int.Parse(Orders[index + 3].Split("by")[1]);
            m.TrueValue = int.Parse(Orders[index + 4].Split("monkey")[1]);
            m.FalseValue = int.Parse(Orders[index + 5].Split("monkey")[1]);
            Monkeys.Add(m);
            index += 7;
        }
        while (index < Orders.Count);

        ProductOfDivisors = Monkeys.Select(x => x.Test).Aggregate((x, y) => x * y);
    }

    public static void Execute(int rounds, int level)
    {
        for (int round = 0; round < rounds; round++)
        {
            Monkeys.ForEach((monkey) =>
            {
                monkey.Items.ForEach((item) =>
                {
                    int index = monkey.Calculate(BigInteger.Parse(item), level);
                    Monkeys[index].Items.Add(monkey.WorryLevel.ToString());
                });
                monkey.Items.Clear();
                GC.Collect();
            });
        }

        foreach (var i in Monkeys)
            Console.WriteLine($"{i.Inspections}");

        LevelOfMonkeyBussines = Monkeys.OrderByDescending(x => x.Inspections)
                                       .Take(2)
                                       .Select(x => x.Inspections)
                                       .Aggregate((x, y) => x * y);
    }
}

class Monkey
{
    public List<string> Items = new();
    public string Operation = string.Empty;
    public int Test = 0;
    public int TrueValue = 0;
    public int FalseValue = 0;
    public BigInteger WorryLevel = 0;
    public long Inspections = 0;

    public int Calculate(BigInteger value, int level)
    {
        Inspections++;
        var param = Operation.Split(' ');
        BigInteger mult = (param[2] == "old") ? value : BigInteger.Parse(param[2]);
        WorryLevel = (param[1] == "+") ? value + mult : value * mult;
        if (level == 1)
        {
            WorryLevel = (long)Math.Floor((int)WorryLevel / 3.0);
        }
        else
        {
            WorryLevel = WorryLevel % Exercise.ProductOfDivisors;
        }
        int index = (WorryLevel % Test == 0) ? TrueValue : FalseValue;
        return index;
    }
}