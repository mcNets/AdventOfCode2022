/*
 * Consider your map; how many trees are visible from outside the grid?
 * 
 * Result exercise 1: 1719
 * 
 * Consider each tree on your map. What is the highest scenic score possible for any tree?
 * 
 * Result exercise 2: 590824
 */

Console.WriteLine("Advent of Code - Day 8");

Trees.lines = File.ReadAllLines(@"..\..\..\data.txt").ToList();
Console.WriteLine($"Rows: {Trees.Rows}   Cols: {Trees.Cols}");

Console.WriteLine($"Result exercise 1: {Trees.VisibleTrees()}");

Console.WriteLine($"Result exercise 2: {Trees.HighScore()}");

public static class Trees
{
    public static List<string> lines = new();

    public static int Rows => lines.Count;
    public static int Cols => lines[0].Length;

    public static int HighScore()
    {
        int highScore = 0;

        for (int row = 1; row < Rows - 1; row++)
        {
            for (int col = 1; col < Cols - 1; col++)
            {
                var score = ScoreLeft(row, col) * ScoreRight(row, col) * ScoreTop(row, col) * ScoreBottom(row, col);

                if (score > highScore)
                {
                    highScore = score;
                }
            }
        }

        return highScore;
    }

    static int ScoreLeft(int row, int col)
    {
        int score = 0;
        for (int c = col - 1; c >= 0; c--)
        {
            score++;
            if (lines[row][col] <= lines[row][c])
            {
                break;
            }
        }
        return score;
    }

    static int ScoreRight(int row, int col)
    {
        int score = 0;
        for (int c = col + 1; c < Cols; c++)
        {
            score++;
            if (lines[row][col] <= lines[row][c])
            {
                break;
            }
        }
        return score;
    }

    static int ScoreTop(int row, int col)
    {
        int score = 0;
        for (int r = row - 1; r >= 0; r--)
        {
            score++;
            if (lines[row][col] <= lines[r][col])
            {
                break;
            }
        }
        return score;
    }

    static int ScoreBottom(int row, int col)
    {
        int score = 0;
        for (int r = row + 1; r < Rows; r++)
        {
            score++;
            if (lines[row][col] <= lines[r][col])
            {
                break;
            }
        }
        return score;
    }

    public static int VisibleTrees()
    {
        int visibles = (Rows * 2) + (Cols * 2) - 4;

        for (int row = 1; row < Rows - 1; row++)
        {
            for (int col = 1; col < Cols - 1; col++)
            {
                if (VisibleToLeft(row, col)
                    || VisibleToRight(row, col)
                    || VisibleToTop(row, col)
                    || VisibleToBottom(row, col))
                {
                    visibles++;
                }
            }
        }

        return visibles;
    }

    static bool VisibleToLeft(int row, int col)
    {
        for (int c = col - 1; c >= 0; c--)
        {
            if (lines[row][col] <= lines[row][c])
            {
                return false;
            }
        }
        return true;
    }

    static bool VisibleToRight(int row, int col)
    {
        for (int c = col + 1; c < Cols; c++)
        {
            if (lines[row][col] <= lines[row][c])
            {
                return false;
            }
        }
        return true;
    }

    static bool VisibleToTop(int row, int col)
    {
        for (int r = row - 1; r >= 0; r--)
        {
            if (lines[row][col] <= lines[r][col])
            {
                return false;
            }
        }
        return true;
    }

    static bool VisibleToBottom(int row, int col)
    {
        for (int r = row + 1; r < Rows; r++)
        {
            if (lines[row][col] <= lines[r][col])
            {
                return false;
            }
        }
        return true;
    }
}
