/*
 * - Determine which pairs of packets are already in the right order. What is the sum of the indices of those pairs?
 * 
 * Result exercise 1: 6070
 * 
 * - Organize all of the packets into the correct order. What is the decoder key for the distress signal?
 * 
 * Result exercise 2: 20758
 */

using System.Collections.Immutable;
using System.Text.Json.Nodes;

Exercise.Solve1();
Exercise.Solve2();

static class Exercise
{
    public static List<JsonNode?> Map = new();

    public static void GetData()
    {
        if (Map.Count <= 0)
            Map = File.ReadAllLines(@"..\..\..\data.txt")
                      .Where(line => string.IsNullOrEmpty(line) == false)
                      .Select(x => JsonNode.Parse(x))
                      .ToList();
    }

    public static void Solve1()
    {
        GetData();

        var result = 0;
        for (int index = 0; index < Map.Count / 2; index++) 
        {
            var items = Map.Skip(index * 2).Take(2).ToArray();
            result += Compare(items[0], items[1]) < 0 ? index + 1 : 0;
        }

        Console.WriteLine($"Exercise 1: {result}");
    }

    public static void Solve2()
    {
        GetData();

        var j1 = JsonNode.Parse("[[2]]");
        var j2 = JsonNode.Parse("[[6]]");

        Map.Add(j1);
        Map.Add(j2);
        Map.Sort(Compare);

        int ix1 = Map.FindIndex(x => x == j1) + 1;
        int ix2 = Map.FindIndex(x => x == j2) + 1;

        Console.WriteLine($"Exercise 2: {ix1 * ix2}");
    }

    public static int Compare(JsonNode n1, JsonNode n2)
    {
        if (n1 is JsonValue && n2 is JsonValue) return (int)n1 - (int)n2;

        var j1 = n1 as JsonArray ?? new JsonArray((int)n1);
        var j2 = n2 as JsonArray ?? new JsonArray((int)n2);

        return Enumerable.Zip(j1, j2)
                         .Select(p => Compare(p.First!, p.Second!))
                         .FirstOrDefault(c => c != 0, j1.Count - j2.Count);
    }
}

