/*
 * [P]     [C]         [M]            
 * [D]     [P] [B]     [V] [S]        
 * [Q] [V] [R] [V]     [G] [B]        
 * [R] [W] [G] [J]     [T] [M]     [V]
 * [V] [Q] [Q] [F] [C] [N] [V]     [W]
 * [B] [Z] [Z] [H] [L] [P] [L] [J] [N]
 * [H] [D] [L] [D] [W] [R] [R] [P] [C]
 * [F] [L] [H] [R] [Z] [J] [J] [D] [D]
 * 1   2   3   4   5   6   7   8   9
 * 
 * After the rearrangement procedure completes, what crate ends up on top of each stack?
 * 
 * Result Exercice 1 is JDTMRWCQJ
 * 
 * After the rearrangement procedure completes, what crate ends up on top of each stack?
 * 
 * Result Exercice 2 is VHJDDCWRD
*/
Console.WriteLine("Advent of Code - Day 5");

var lines = File.ReadAllLines(@"..\..\..\data.txt").ToList();

var cratesInfo = lines.Take(8).Reverse().ToList();
var movementsInfo = lines.Skip(10).ToList();

List<Stack<char>> stacks1 = new List<Stack<char>>();
List<List<string>> stacks2 = new List<List<string>>();

for (int x = 0; x < cratesInfo.Count; x++)
{
    for (int y = 0; y < 9; y++)
    {
        if (x == 0)
        {
            stacks1.Add(new Stack<char>());
            stacks2.Add(new List<string>());
        }

        if (cratesInfo[x][1 + (y * 4)] != ' ')
        {
            stacks1[y].Push(cratesInfo[x][1 + (y * 4)]);
            stacks2[y].Add(cratesInfo[x][1 + (y * 4)].ToString());
        }
    }
};

foreach (var line in movementsInfo)
{
    var l = line.Split(' ');
    int movements = int.Parse(l[1]);
    int from = int.Parse(l[3]) - 1;
    int to = int.Parse(l[5]) - 1;

    for (int x = 0; x < movements; x++)
    {
        stacks1[to].Push(stacks1[from].Pop());
    }

    var s = stacks2[from].TakeLast(movements);
    stacks2[to].AddRange(s);
    stacks2[from].RemoveRange(stacks2[from].Count - movements, movements);
}

string result = string.Empty;
string result2 = string.Empty;
for (int x = 0; x < 9; x++)
{
    result += stacks1[x].Peek();
    result2 += stacks2[x].TakeLast(1).FirstOrDefault();
}

Console.WriteLine($"Result Exercice 1 is {result}");
Console.WriteLine($"Result Exercice 2 is {result2}");

