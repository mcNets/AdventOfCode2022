Console.WriteLine("Advent of Code - Day 4");

/*
 * In how many assignment pairs does one range fully contain the other?
 * 
 * Result 1: 487
 * 
 * In how many assignment pairs do the ranges overlap?
 * 
 * Result 2: 849
 */

var lines = File.ReadAllLines(@"..\..\..\data.txt").ToList();

Console.WriteLine($"{lines.Count} lines read.");

/* Exercice 1 */

int pairsIncluded1 = 0;
int pairsIncluded2 = 0;

foreach (var line in lines)
{
    string [] pair = line.Split(',');
    string [] elem1 = pair[0].Split("-");
    string [] elem2 = pair[1].Split("-");

    if ((int.Parse(elem1[0]) >= int.Parse(elem2[0]) && int.Parse(elem1[1]) <= int.Parse(elem2[1]))
        ||
        (int.Parse(elem2[0]) >= int.Parse(elem1[0]) && int.Parse(elem2[1]) <= int.Parse(elem1[1])))
    {
        pairsIncluded1++;
    }

    if (
        (int.Parse(elem1[0]) >= int.Parse(elem2[0]) && int.Parse(elem1[0]) <= int.Parse(elem2[1]))
        ||
        (int.Parse(elem1[1]) >= int.Parse(elem2[0]) && int.Parse(elem1[1]) <= int.Parse(elem2[1]))
        ||
        (int.Parse(elem2[0]) >= int.Parse(elem1[0]) && int.Parse(elem2[0]) <= int.Parse(elem1[1]))
        ||
        (int.Parse(elem2[1]) >= int.Parse(elem1[0]) && int.Parse(elem2[1]) <= int.Parse(elem1[1]))
        )
    {
        pairsIncluded2++;
    }
}

Console.WriteLine($"Result exercise 1: {pairsIncluded1}");
Console.WriteLine($"Result exercise 2: {pairsIncluded2}");
