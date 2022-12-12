using System.Linq;

/*
 * a-z Priority 1 through 26
 * A-Z Priority 27 through 52
 * 
 * Find the item type that appears in both compartments of each rucksack. 
 * What is the sum of the priorities of those item types?
 * 
 * Result 1: 7875
 * 
 * Find the item type that corresponds to the badges of each three-Elf group. 
 * What is the sum of the priorities of those item types?
 * 
 * Result 2: 2479
 */

Console.WriteLine("Advent of Code - Day 3");

var packs = File.ReadAllLines(@"..\..\..\data.txt").ToList();
Console.WriteLine($"{packs.Count} lines read.");

int priority1 = 0;

packs.ForEach(pack =>
{
    priority1 += pack.Take(pack.Length / 2)
                     .Intersect(pack.TakeLast(pack.Length / 2))
                     .Sum(c => c >= 'a' && c <= 'z' ? (c - 'a') + 1 : (c - 'A') + 27);
});

Console.WriteLine($"Result exercise 1 {priority1}");

int priority2 = 0;

for (int x = 0; x < packs.Count / 3; x++)
{
    var items = packs.Skip(x * 3).Take(3).ToArray();

    priority2 += items[0].Intersect(items[1].Intersect(items[2]))
                         .Sum(c => c >= 'a' && c <= 'z' ? (c - 'a') + 1 : (c - 'A') + 27);
}

Console.WriteLine($"Result exercise 2 {priority2}");
