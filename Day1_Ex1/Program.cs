/*
 * 1 - Find the Elf carrying the most Calories. How many total Calories is that Elf carrying?
 * 
 * Result 1: 70374
 * 
 * 2 - Find the top three Elves carrying the most Calories. How many Calories are those Elves carrying in total?
 * 
 * Result 2: 204610
 */

Console.WriteLine("Advent of Code - Day 1");

var lines = File.ReadAllLines(@"..\..\..\data.txt").ToList();
Console.WriteLine($"{lines.Count} lines read.");

int[] elves = new int[lines.Count(x => string.IsNullOrEmpty(x)) + 1];
int index = 0;

lines.ForEach(line =>
{
    if (string.IsNullOrEmpty(line))
    {
        index++;
    }
    else
    {
        elves[index] += int.Parse(line);
    }
});

Console.WriteLine($"Answer exercise 1 = {elves.Max()}");
Console.WriteLine($"Answer exercise 2 = {elves.OrderByDescending(x => x).Take(3).Sum()}");
