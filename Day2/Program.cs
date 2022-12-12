/* 
 * Oponent:
 * 
 *  A=Rock, B=Paper, C=Scissors 
 * 
 * Me:
 * 
 *  X = Rock = 1 Point
 *  Y = Paper = 2 Points
 *  Z = Scissors = 3 Points
 * 
 * Punctuation:
 * 
 *  Draw = 3 Points
 *  Win = 6 Points
 * 
 * If second column: 
 * 
 *  X = I must lose
 *  Y = Draw
 *  Z = I must win
 * 
 * Result 1: 12794
 * 
 * Result 2: 14979
 */
Console.WriteLine("Advent of Code - Day 2");

var rounds = File.ReadAllLines(@"..\..\..\data.txt").ToList();
Console.WriteLine($"{rounds.Count} lines read.");

/* Tuple<Combination, Punctuation 1, Punctuation 2> */
Tuple<string, int, int>[] results = new Tuple<string, int, int>[]
{
    Tuple.Create("A X", (1 + 3), (3 + 0)),
    Tuple.Create("A Y", (2 + 6), (1 + 3)),
    Tuple.Create("A Z", (3 + 0), (2 + 6)),
    Tuple.Create("B X", (1 + 0), (1 + 0)),
    Tuple.Create("B Y", (2 + 3), (2 + 3)),
    Tuple.Create("B Z", (3 + 6), (3 + 6)),
    Tuple.Create("C X", (1 + 6), (2 + 0)),
    Tuple.Create("C Y", (2 + 0), (3 + 3)),
    Tuple.Create("C Z", (3 + 3), (1 + 6)),
};

int firstScore = 0;
int secondScore = 0;

rounds.ForEach(round =>
{
    var item = results.First(x => x.Item1 == round);
    firstScore += item.Item2;
    secondScore += item.Item3;
});

Console.WriteLine($"Exercise 1: {firstScore}");
Console.WriteLine($"Exercise 2: {secondScore}");
