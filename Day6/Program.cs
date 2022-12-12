/*
 * How many characters need to be processed before the first start-of-packet marker is detected?
 * 
 * Result 1: 1287
 * 
 * How many characters need to be processed before the first start-of-message marker is detected?
 * 
 * Result 2: 3716
 */

Console.WriteLine("Advent of Code - Day 6");

var items = File.ReadAllText(@"..\..\..\data.txt");

for (int i = 0; i < items.Length - 4; i++)
{
    var chunk = items.Substring(i, 4);
    if (chunk.Distinct().Count() == 4)
    {
        Console.WriteLine($"Result exercise 1: {i + 4}  {chunk}");
        break;
    }
}

for (int i = 0; i < items.Length - 14; i++)
{
    var chunk = items.Substring(i, 14);
    if (chunk.Distinct().Count() == 14)
    {
        Console.WriteLine($"Result exercise 2: {i + 14}  {chunk}");
        break;
    }
}
