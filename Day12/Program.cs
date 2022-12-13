/*
 * { = 123
 * 
 * - What is the fewest steps required to move from your current position to the location that should get the best signal?
 * 
 * Result exercise 1: 440
 * 
 * - What is the fewest steps required to move starting from any square with elevation a to the location that should get the best signal?
 * 
 * Result exercise 2: 439
 */

Exercise.Solve(0,0);
Console.WriteLine($"Total moves 1: {Exercise.MovesCount}\n");

int minCount = 0;
for (int row = 0; row < Exercise.Map.Count; row++)
{
    for (int col = 0; col < Exercise.Map[row].Length; col++)
    {
        if (row == 0 || row == Exercise.Map.Count - 1 || col == 0 || col == Exercise.Map[row].Length - 1)
        {
            if (Exercise.Map[row][col] == 'a')
            {
                if (Exercise.Solve(row, col))
                {
                    if (minCount == 0 || Exercise.MovesCount < minCount)
                        minCount = Exercise.MovesCount;
                }
            }
        }
    }
}
Console.WriteLine($"Total moves 2: {minCount}\n");

static class Exercise
{
    public static List<string> Map = new();
    public static int Rows = 0;
    public static int Cols = 0;
    public static bool[,] Visited;
    public static int MovesCount = 0;
    public static Queue<(int r, int c)> Q = new Queue<(int r, int c)>();
    public static int NodesLeftInLayer = 0;
    public static int NodesInNextLayer = 0;
    public static int[] DeltaRow = { -1, +1, 0, 0 };
    public static int[] DeltaCol = { 0, 0, +1, -1 };

    public static void GetData()
    {
        if (Map.Count== 0)
        {
            Map = File.ReadAllLines(@"..\..\..\data.txt").ToList();
        }
    }

    public static bool Solve(int startingRow, int startingCol)
    {
        GetData();

        Q.Clear();
        Rows = Map.Count;
        Cols = Map[0].Length;
        Visited = new bool[Rows, Cols];
        Q.Enqueue((startingRow, startingCol));
        Visited[startingRow, startingCol] = true;
        NodesLeftInLayer = 1;
        NodesInNextLayer = 0;
        MovesCount = 0;

        while (Q.Count > 0)
        {
            (int row, int col) = Q.Dequeue();

            // Solved
            if (Map[row][col] == 'E')
            {
                return true;
            }

            GetNeighbours(row, col);

            NodesLeftInLayer--;

            if (NodesLeftInLayer == 0)
            {
                NodesLeftInLayer = NodesInNextLayer;
                NodesInNextLayer = 0;
                MovesCount++;
            }
        }

        return false;
    }

    public static void GetNeighbours(int row, int col)
    {
        for (int x = 0; x < 4; x++)
        {
            int r = row + DeltaRow[x];
            int c = col + DeltaCol[x];

            if (r < 0 || r >= Rows || c < 0 || c >= Cols || Visited[r, c]) continue;

            // Constraints:
            // - Destination square can be at most one higher than the current.
            // - 'E' can only be selected if the previous one is a 'z' => '{' = 'z' + 1
            char newItem = Map[r][c] == 'E' ? '{' : Map[r][c];
            if (newItem - Map[row][col] > 1) continue;

            Visited[r, c] = true;
            Q.Enqueue((r, c));
            NodesInNextLayer++;
        }
    }
}