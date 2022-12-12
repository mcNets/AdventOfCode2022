/*
 * Find the signal strength during the 20th, 60th, 100th, 140th, 180th, and 220th cycles. 
 * What is the sum of these six signal strengths?
 * 
 * Result exercise 1: 14220
 * 
 * What eight capital letters appear on your CRT?
 * 
 * Result exercise 2: 
 */

Console.WriteLine("Advent of Code - Day 10\n");

Exercise.GetData();
Exercise.Execute();
Console.WriteLine($"Sum Signal Stregth: {Exercise.SignalStrength}\n");
Exercise.PaintCRT();


static class Exercise
{
    public static List<string> Orders = new();
    public static int[] Landmarks = new int[] {20,60,100,140,180,220};
    public static int SignalStrength = 0;
    public static char[,] CRT = new char[6,40];

    public static void GetData()
    {
        Orders = File.ReadAllLines(@"..\..\..\data.txt").ToList();
    }

    public static void Execute()
    {
        int crtLine = 0;
        int crtPixel = 0;
        int currentCicle = 0;
        int x = 1;

        Orders.ForEach((order) =>
        {
            var data = order.Split(' ');

            CRT[crtLine, crtPixel] = (crtPixel >= x - 1 && crtPixel <= x + 1) ? '#' : ' ';
            SignalStrength += Landmarks.Contains(++currentCicle) ? currentCicle * x : 0;
            
            if (++crtPixel >= 40)
            {
                crtPixel = 0;
                crtLine++;
            }

            if (data[0] == "addx")
            {
                CRT[crtLine, crtPixel] = (crtPixel >= x - 1 && crtPixel <= x + 1) ? '#' : ' ';
                SignalStrength += Landmarks.Contains(++currentCicle) ? currentCicle * x : 0;

                if (++crtPixel >= 40)
                {
                    crtPixel = 0;
                    crtLine++;
                }
                
                x += int.Parse(data[1]);
            }
        });

        Console.WriteLine($"Cicles: {currentCicle}\n");
    }

    public static void PaintCRT()
    {
        for(int x = 0; x < 6; x++)
        {
            for (int y = 0; y < 40; y++)
            {
                Console.Write(CRT[x,y]);
            }
            Console.WriteLine();
        }
    }
}